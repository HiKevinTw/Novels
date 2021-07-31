using Novels.Repository.Interface.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Novels.Repository.Utility
{
	sealed class Config : IConfig
	{
        private const string ConfigKey = "NovelsConfig";

        private static Config instance = null;
        private static object configLock = new object();
        private static object cacheLock = new object();
        private static ObjectCache configCache = MemoryCache.Default;

        private static IEnumerable<XElement> GetDatabaseCollections()
        {
            return ConfigDocument.Root.Element("DatabaseCollections").Elements("Database");
        }

        public string Novels_SqlConnection
		{
            get
            {
                //var database = GetDatabaseCollections().Single(d => "NewsProducer".Equals(d.Attribute("Name").Value));

                //return
                //    string.Format(
                //        @"Data Source={0};Initial Catalog={1};User Id={2};Password={3};",
                //        database.Element("ServerName").Value,
                //        database.Element("DataBaseName").Value,
                //        database.Element("User").Value,
                //        database.Element("Password").Value);

                return string.Empty;
            }

        }

        public string ActionQueueUri<TAction>(TAction action) where TAction : struct
        {
            //var actionQueueUri = GetActionQueueUriCollection(action);

            //return
            //    string.Format(
            //        @"FormatName:DIRECT=OS:{0}\private$\{1}",
            //        actionQueueUri.Element("ServerName").Value,
            //        actionQueueUri.Element("QueueName").Value);

            return string.Empty;
        }

        private static XDocument ConfigDocument
        {
            // Singleton Pattern：獨體模式，由屬性取得唯一 Instance
            get
            {
                if (configCache[ConfigKey] == null)
                {
                    lock (cacheLock)
                    {
                        if (configCache[ConfigKey] == null)
                        {
                            // Singleton Pattern：獨體模式，Double Check Instance，避免多個執行緒同時進入，Lock 後重複讀取產生多個 Instance
                            LoadConfig();
                        }
                    }
                }

                return (XDocument)configCache[ConfigKey];
            }
        }

        private static void LoadConfig()
        {
            string configPath = ConfigurationManager.AppSettings[ConfigKey];

            // 監控檔案，實體檔案變更時會自動更新
            CacheItemPolicy cachePolicy = new CacheItemPolicy();
            cachePolicy.ChangeMonitors.Add(new HostFileChangeMonitor(new List<string>() { configPath }));

            configCache.Set(ConfigKey, XDocument.Load(configPath), cachePolicy);
        }

        internal static Config Instance
        {
            // Singleton Pattern：獨體模式，由屬性取得唯一 Instance
            get
            {
                if (instance == null)
                {
                    lock (configLock)
                    {
                        if (instance == null)
                        {
                            // Singleton Pattern：獨體模式，Double Check Instance，避免多個執行緒同時進入，Lock 後重複讀取產生多個 Instance
                            instance = new Config();
                        }
                    }
                }

                return instance;
            }
        }

    }
}
