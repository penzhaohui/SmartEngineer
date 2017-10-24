﻿#region copyright info
//------------------------------------------------------------------------------
// <copyright company="ChaosStudio">
//     Copyright (c) 2002-2015 巧思工作室.  All rights reserved.
//     Contact:		MSN:atwind@cszi.com , QQ:3329091
//		Home:		 http://www.cszi.com
// </copyright>
//------------------------------------------------------------------------------
#endregion

using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;

namespace SmartTask
{
    /// <summary>
    ///   任务配置[反序列化时使用]
    /// </summary>
    [Serializable,
    XmlRoot(ElementName = "configuration")]
    public sealed class TaskConfig : ConfigBase
    {
        #region 相关属性

        private const string FILE_NAME = "Tasks.config";

        /// <summary>
        /// 文件名
        /// </summary>
        protected override string FileName
        {
            get
            {
                return FILE_NAME;
            }
        }

        private ExecutionStatus _execution;
        /// <summary>
        /// 运行状态引用
        /// </summary>
        public ExecutionStatus Execution
        {
            get { return _execution; }
            set { _execution = value; }
        }

        /// <summary>
        /// 监视工作主计时器配置
        /// 与文件变动事件OnConfigChanged一起可以自动载入更改后的配置
        /// </summary>
        [XmlElement(ElementName = "WatchTimer")]
        public TimerConfig WatchTimer { get; set; }

        /// <summary>
        /// 任务配置
        /// </summary>
        [XmlArray(ElementName = "tasks"), XmlArrayItem(ElementName = "task")]
        public TaskCollection Tasks { get; set; }

        /// <summary>
        /// 公有资源信息
        /// </summary>
        [XmlArray(ElementName = "resources"), XmlArrayItem(ElementName = "resource")]
        public ResourceCollection Resources { get; set; }

        #endregion

        #region 单例模式

        static TaskConfig _instance;
        ////定义一个只读静态对象 , 且这个对象是在程序运行时创建的 
        private static readonly object syncObject = new object();
        /// <summary>
        /// 配置实例
        /// </summary>
        /// <returns></returns>
        public static TaskConfig GetInstance(bool isReload= false)
        {
            if (_instance == null)
            {
                lock (syncObject)
                {
                    if(isReload) _instance = null;
                    if (_instance != null) return _instance;

                    Logger.Debug("TaskConfig实例化");
                    _instance = new TaskConfig();
                    _instance.Initialize();
                }
            }
            else
            {
                Logger.Debug("返回缓存的的TaskConfig实例");
            }
            return _instance;
        }

        #endregion
        
        private TaskConfig()
        {
            AddFileWatcher();        //Note:启用配置变更监视
        }

        /// <summary>
        /// Note:序列化，从配置中获取所有数据
        /// </summary>
        /// <returns></returns>
        public void Initialize()
        {
            using (var reader = XmlReader.Create(GetFullPath(FILE_NAME)))
            {
                Logger.Debug("任务配置实例初始化开始...");
                var slz = new XmlSerializer(typeof(TaskConfig));
                var rst = slz.Deserialize(reader) as TaskConfig;
                reader.Close();
                _instance = rst; //获得实例
                if (_instance != null && _instance.Tasks.Count > 0)
                {
                    foreach (var task in _instance.Tasks)
                    {
                        //相关配置初始化，保持默认值的合法性
                        if (task.WorkSetting == null) task.WorkSetting = new TaskWorkSettingInfo();

                        //锁定超时至少5秒
                        if (task.WorkSetting.Timeout < 5) task.WorkSetting.Timeout = 5;
                        var taskId = task.Meta.Id;
                        //1. 任务Id唯一性检测
                        var tmpJobs = _instance.Tasks.FindAll(x => x.Meta.Id == taskId);
                        //logRun.Debug($"jobs[{taskId}]={tmpJobs.Count}");
                        if (tmpJobs.Count < 2)
                        {
                            //没有重复的任务Id
                            task.Meta.TaskHash = task.Type.GetHashCode();
                            Logger.Debug("{0}的任务Hash:{1}", task, task.Meta.TaskHash);
                        }
                        else
                        {
                            var msg = String.Format("Task.Id={0}重复，{1}里每一个Job的Id必须是与其它任务的Id不同的数字。", taskId, FILE_NAME);
                            Logger.Error(msg);
                            throw new ConfigurationErrorsException(msg);
                        }
                    }
                }
            }


            if (_instance == null)
            {
                var msg = String.Format("请查检{0}配置文件是否存在并且配置正确。", FILE_NAME);
                Logger.Error(msg);
                throw new ConfigurationErrorsException(msg);
            }

            //计时器初始化
            if (_instance.WatchTimer == null) _instance.WatchTimer = new TimerConfig();

            //初始化运行状态            
            Logger.Debug("初始化一个新的XML运行状态实例");
            _execution = ExecutionStatus.Instance();
            
            //将上次运行状态恢复至本实例中
            foreach (var task in _instance.Tasks)
            {
                var jobId = task.Meta.Id;
                //任务状态初始化或匹配
                var job = _execution.Tasks[jobId]; //查询Job的运行情况
                if (job == null)
                {
                    Logger.Debug("开始初始化任务({0})运行状态[新的]。", task.Meta.Name);
                    task.Execution = new ExecutionInfo();  //初始化新执行状态
                    _execution.Tasks.Add(task.Meta);     //工作运行状态增加
                }
                else
                {
                    Logger.Debug("开始读取任务({0})运行状态[已有的]。", task.Meta.Name);
                    //Note:序列化时将状态置为默认，因为有些异常会奖Runing记下使得该任务再也无法运行了。
                    task.Execution.RunStatus = TaskRunStatus.Default;
                }

                task.Execution.IsExsit = true;
            }

            Logger.Debug("任务配置实例化完成。");
            _instance.Execution = _execution;
        }

       
        #region 配置变动事件

        public event FileSystemEventHandler Changed;

        /// <summary>
        /// 配置文件监视器
        /// </summary>
        private  FileSystemWatcher _fileWatcher;
        /// <summary>
        /// 增加文件变更监视
        /// </summary>
        void AddFileWatcher()
        {
            if(_fileWatcher != null) return;
            _fileWatcher = new FileSystemWatcher
                              {
                                  Path = AppDomain.CurrentDomain.BaseDirectory.Trim(),
                                  Filter = FILE_NAME,
                                  NotifyFilter = NotifyFilters.LastWrite,
                                  EnableRaisingEvents = true
                              };
            _fileWatcher.Changed += ConfigChanged;
            Logger.Debug("添加配置文件变更事件完成");
        }

        //配置变更延时计时器
        private Timer _fileTimer;
        /// <summary>
        /// 文件变动引发的事件
        /// Note:变动配置时有2秒的缓冲时间，2秒内的变更视为同一次变动
        /// </summary>
        private void ConfigChanged(object sender, FileSystemEventArgs e)
        {
            const int delayTime = 2000;
            if (_fileTimer == null)
            {
                _fileTimer = new Timer(ConfigChangeTimerCallback, e, delayTime, Timeout.Infinite);
            }
            else
            {
                _fileTimer.Change(delayTime, Timeout.Infinite);
            }
        }

        /// <summary>
        /// 配置变更 线程回调
        /// </summary>
        void ConfigChangeTimerCallback(object state)
        {
            Changed.Invoke(this, (FileSystemEventArgs)state);

            _fileWatcher.Changed -= ConfigChanged;
            _fileWatcher = null;
            _instance = null;    //文件变更时应该重新反序列化配置信息
        }

        #endregion

        public override void Save()
        {
            return; //只读配置禁止写入任何内容。
        }
    }
}
