﻿using System;
using System.Collections.Generic;
using System.IO;

namespace SmartSql.Common
{
    /// <summary>
    /// 文件监控加载器
    /// </summary>
    public class FileWatcherLoader
    {
        private IList<FileSystemWatcher> _fileWatchers = new List<FileSystemWatcher>();
        private FileWatcherLoader() { }
        public static FileWatcherLoader Instance = new FileWatcherLoader();
        public void Watch(FileInfo fileInfo, Action onFileChanged)
        {
            if (onFileChanged != null)
            {
                WatchFileChange(fileInfo, onFileChanged);
            }
        }

        private void WatchFileChange(FileInfo fileInfo, Action onFileChanged)
        {
            FileSystemWatcher fileWatcher = new FileSystemWatcher(fileInfo.DirectoryName)
            {
                Filter = fileInfo.Name,
                NotifyFilter = NotifyFilters.LastWrite
            };
            #region OnChanged
            DateTime lastChangedTime = DateTime.Now;
            int twoTimeInterval = 1000;
            fileWatcher.Changed += (sender, e) =>
            {
                var timerInterval = (DateTime.Now - lastChangedTime).TotalMilliseconds;
                if (timerInterval < twoTimeInterval) { return; }
                onFileChanged?.Invoke();
                lastChangedTime = DateTime.Now;
            };
            #endregion
            fileWatcher.EnableRaisingEvents = true;
            _fileWatchers.Add(fileWatcher);
        }

        public void Clear()
        {
            for (int i = 0; i < _fileWatchers.Count; i++)
            {
                FileSystemWatcher fileWatcher = (FileSystemWatcher)_fileWatchers[i];
                fileWatcher.EnableRaisingEvents = false;
                fileWatcher.Dispose();
            }
        }
    }
}
