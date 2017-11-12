using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEngineer.Framework.IoC
{
    // https://insightfulcoder.wordpress.com/2011/08/08/c-generic-object-factory-8/
    public sealed class ObjectFactory
    {
        private readonly static SortedList<string, object> _factories = new SortedList<string, object>();

        /// <summary>
        /// 注册不带参数的类工厂函数变量
        /// </summary>
        /// <typeparam name="TR">目标类实例类型</typeparam>
        /// <param name="factory">工厂函数变量</param>
        public static void RegisterFactory<TR>(Func<TR> factory)
        {
            Add<TR>(factory);
        }

        /// <summary>
        /// 带1个参数的类工厂函数变量
        /// </summary>
        /// <typeparam name="T1">参数类型</typeparam>
        /// <typeparam name="TR">目标类实例类型</typeparam>
        /// <param name="factory">工厂函数变量</param>
        public static void RegisterFactory<T1, TR>(Func<T1, TR> factory)
        {
            Add<TR>(factory);
        }

        /// <summary>
        /// 私有函数
        /// </summary>
        /// <typeparam name="TR">目标类实例类型</typeparam>
        /// <param name="factory">工厂函数变量</param>
        private static void Add<TR>(object factory)
        {
            if (!_factories.ContainsKey(typeof(TR).FullName))
                _factories.Add(typeof(TR).FullName, factory);
        }

        /// <summary>
        /// 生成目标类型的类实例
        /// </summary>
        /// <typeparam name="TR">目标类实例类型</typeparam>
        /// <returns>目标类型的类实例</returns>
        public TR Create<TR>() where TR : new()
        {
            return new TR();
        }

        /// <summary>
        /// 生成目标类型的类实例
        /// </summary>
        /// <typeparam name="T1">参数类型</typeparam>
        /// <typeparam name="TR">目标类实例类型</typeparam>
        /// <param name="t1"></param>
        /// <returns>目标类型的类实例</returns>
        public TR Create<T1, TR>(T1 t1)
        {
            object factory;
            if (_factories.TryGetValue(typeof(TR).FullName, out factory))
            {
                ((Func<T1, TR>)factory).Invoke(t1);
            }

            return default(TR);
        }
    }

    // 委托、事件与匿名方法 - http://www.cnblogs.com/r01cn/archive/2012/11/30/2795977.html#!comments
    // 在现有条件下,建议尽量用Func和lambda解决函数变量问题,用var, dynamic来解决动态变量问题.以减少混用引起的混乱.

    /*
    public class ObjectFactory
    {
        #region Fields

        /// <summary>
        /// admin suffix
        /// </summary>
        private const string ADMIN_SUFFIX = "_Admin";

        /// <summary>
        /// logger info.
        /// </summary>
        private static readonly ILog Logger = LogFactory.Instance.GetLogger("ObjectFactory");

        /// <summary>
        /// context information.
        /// </summary>
        private static IApplicationContext _context;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets object context.
        /// </summary>
        private static IApplicationContext ObjectContext
        {
            get
            {
                if (_context == null)
                {
                    _context = ContextRegistry.GetContext();

                    if (_context == null)
                    {
                        Logger.Fatal("The object context can't be found, please check the configuration for spring.net whether is configurated correctly.");
                    }
                }

                return _context;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Gets an object implement by the interface type.
        /// </summary>
        /// <param name="interfaceType">interface type, which name is used as object id to retrieve the according object.</param>
        /// <returns>an object.</returns>
        public static object GetObject(Type interfaceType)
        {
            return GetObject(interfaceType, IsAdminMode());
        }

        /// <summary>
        /// Gets an object implement by the interface type.
        /// </summary>
        /// <param name="interfaceType">interface type, which name is used as object id to retrieve the according object.</param>
        /// <param name="context">Http context</param>
        /// <returns>an object.</returns>
        public static object GetObject(Type interfaceType, HttpContextBase context)
        {
            return GetObject(interfaceType, IsAdminMode(context));
        }

        /// <summary>
        /// Gets the object implement by the interface type.
        /// </summary>
        /// <typeparam name="T">target type</typeparam>
        /// <returns>the object with target type</returns>
        public static T GetObject<T>() where T : class
        {
            return (T)GetObject(typeof(T), IsAdminMode());
        }

        /// <summary>
        /// Gets an object by name that implements interface. This allows having multiple implementations and get instance of a particular type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T GetObject<T>(string name) where T : class
        {
            return (T)GetObject(name);
        }

        /// <summary>
        /// Gets an object implement by the interface type.
        /// </summary>
        /// <param name="interfaceType">interface type, which name is used as object id to retrieve the according object.</param>
        /// <param name="isAdmin">indicates whether need to get an admin implement object</param>
        /// <returns>an object.</returns>
        public static object GetObject(Type interfaceType, bool isAdmin)
        {
            string objectId = interfaceType.Name;

            // all of admin mode, the object id is required to end with "_Admin", it is contract in ACA.
            if (isAdmin)
            {
                // if there have been configurated the admin implement,It will get admin implement.
                // if not, system will use the daily implement.
                if (ObjectContext.ContainsObject(objectId + ADMIN_SUFFIX))
                {
                    objectId += ADMIN_SUFFIX;
                }
            }

            return GetObject(objectId);
        }

        /// <summary>
        /// Gets an object by unique object id 
        /// </summary>
        /// <param name="objectId">unique object id.</param>
        /// <returns>an object.</returns>
        public static object GetObject(string objectId)
        {
            try
            {
                object obj = ObjectContext.GetObject(objectId);

                if (obj == null)
                {
                    throw new ACAException(string.Format("The object {0} can't be found from object container.", objectId));
                }

                if (Logger.IsDebugEnabled)
                {
                    if ((objectId != "IBizDomainBll" && objectId != "IGviewBll" && objectId != "IViewBll" && objectId != "II18nSettingsBll" && objectId != "IXPolicyBll" && objectId != "ICapTypeFilterBll") && (objectId.EndsWith("Bll") || objectId.EndsWith("Bll_Admin")))
                    {
                        ProxyFactory factory = new ProxyFactory(obj);

                        factory.AddAdvice(new AroundAdvise());
                        ////factory.AddAdvice(new BeforeAdvise());
                        ////factory.AddAdvice(new AfterReturningAdvise());
                        factory.AddAdvice(new ThrowsAdvise());

                        obj = factory.GetProxy();
                    }
                }

                return obj;
            }
            catch (Exception e)
            {
                throw new ACAException(e);
            }
        }

        /// <summary>
        /// Gets the object by configuration.
        /// </summary>
        /// <typeparam name="T">The generic type.</typeparam>
        /// <param name="configPath">The config file path.</param>
        /// <param name="interfaceKey">The interface key specified in the config file's node.</param>
        /// <returns>Return the generic type's object.</returns>
        public static T GetObjectByConfiguration<T>(string configPath, string interfaceKey) where T : class
        {
            if (!File.Exists(configPath))
            {
                return null;
            }

            T result = null;
            XmlDocument doc = new XmlDocument();

            // load the xml config file
            try
            {
                doc.Load(configPath);
            }
            catch (Exception ex)
            {
                // NOT throw exception
                Logger.Error(ex.Message);
                return null;
            }

            if (doc.DocumentElement == null || doc.DocumentElement.ChildNodes == null)
            {
                return null;
            }

            // parse the xml config file to search the <object id="IGrantPermission"> node
            int allNodeNum = 0;
            int correctNodeNum = 0;

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                if (node.NodeType == XmlNodeType.Element)
                {
                    allNodeNum++;
                }

                // search the <object id="IGrantPermission"> node
                if (node.NodeType == XmlNodeType.Element &&
                    string.Equals(node.Name, "object", StringComparison.InvariantCultureIgnoreCase) &&
                    node.Attributes != null &&
                    string.Equals(node.Attributes["id"].Value, interfaceKey, StringComparison.InvariantCultureIgnoreCase))
                {
                    string typeDescrption = node.Attributes["type"].Value;
                    result = GetObjectByTypeDesc<T>(typeDescrption, configPath);
                    correctNodeNum++;
                    break;
                }
            }

            if (correctNodeNum != allNodeNum && allNodeNum > 0)
            {
                Logger.ErrorFormat("The configuration file \"{0}\" is incorrect.", configPath);
            }

            return result;
        }

        /// <summary>
        /// Gets the object by the type description string that format as "Namespace, AssemblyName".
        /// </summary>
        /// <typeparam name="T">The generic type.</typeparam>
        /// <param name="typeDescription">The type description.</param>
        /// <param name="configPath">The config path.</param>
        /// <returns>Return the generic type's object.</returns>
        private static T GetObjectByTypeDesc<T>(string typeDescription, string configPath) where T : class
        {
            if (string.IsNullOrEmpty(typeDescription))
            {
                Logger.ErrorFormat("The configuration file \"{0}\" is incorrect.", configPath);
                return null;
            }

            // parse the type string that format as "Namespace, AssemblyName"
            string[] typeArray = typeDescription.Split(',');

            if (typeArray.Length != 2 || string.IsNullOrEmpty(typeArray[0].Trim()) || string.IsNullOrEmpty(typeArray[1].Trim()))
            {
                Logger.ErrorFormat("The type \"{0}\" format is incorrect in the file \"{1}\", please use the format type=\"Namespace, AssemblyName\"", typeDescription, configPath);
                return null;
            }

            T result = null;
            string custNamespace = typeArray[0].Trim();
            string custAssemblyName = typeArray[1].Trim();

            try
            {
                Assembly assembly = Assembly.Load(custAssemblyName);
                Type type = assembly.GetType(custNamespace);

                result = Activator.CreateInstance(type) as T;
            }
            catch (Exception ex)
            {
                // NOT throw exception
                Logger.Error(ex.Message);
            }

            return result;
        }

        /// <summary>
        /// Indicates the current page whether need to be presented as admin.
        /// </summary>
        /// <returns>true - admin mode,false-daily mode.</returns>
        private static bool IsAdminMode()
        {
            if (HttpContext.Current == null || HttpContext.Current.Session == null)
            {
                return false;
            }

            return IsAdminMode(new HttpContextWrapper(HttpContext.Current));
        }

        /// <summary>
        /// Indicates the current page whether need to be presented as admin.
        /// </summary>
        /// <param name="context">Http context</param>
        /// <returns>true - admin mode,false-daily mode.</returns>
        private static bool IsAdminMode(HttpContextBase context)
        {
            if (context == null || context.ApplicationInstance == null || context.ApplicationInstance.Context == null)
                return false;

            var currentContext = context.ApplicationInstance.Context;

            if (currentContext.Session == null)
                return false;

            object isAdmin = currentContext.Session[SessionConstant.SESSION_ADMIN_MODE];

            if (isAdmin != null && isAdmin.ToString() == ACAConstant.COMMON_Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion Methods
    }

    */
}
