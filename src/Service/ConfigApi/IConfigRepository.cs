using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.ConfigApi
{
    public interface IConfigRepository
    {
        void Add(ConfigItem item);
        IEnumerable<ConfigItem> GetAll();
        ConfigItem Find(string key);
        ConfigItem Remove(string key);
        void Update(ConfigItem item);
    }
}
