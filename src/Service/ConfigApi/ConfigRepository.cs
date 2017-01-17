using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.ConfigApi
{
    public class ConfigRepository : IConfigRepository
    {
        private static ConcurrentDictionary<string, ConfigItem> _configs = new ConcurrentDictionary<string, ConfigItem>();

        public ConfigRepository()
        {
            Add(new ConfigItem { Name = "DatabaseConnectionAdmin" });
            Add(new ConfigItem { Name = "DatabaseConnectionLive" });
            Add(new ConfigItem { Name = "DatabaseConnectionDW" });
        }

        public IEnumerable<ConfigItem> GetAll()
        {
            return _configs.Values;
        }

        public void Add(ConfigItem item)
        {
            item.Key = Guid.NewGuid().ToString();
            _configs[item.Key] = item;
        }

        public ConfigItem Find(string key)
        {
            ConfigItem result;
             _configs.TryGetValue(key, out result);
            return result;
        }
        

        public ConfigItem Remove(string key)
        {
            ConfigItem result;
            _configs.TryRemove(key, out result);
            return result;
        }

        public void Update(ConfigItem item)
        {
            _configs[item.Key] = item;
        }
    }
}
