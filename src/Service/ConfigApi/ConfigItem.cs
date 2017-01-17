using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.ConfigApi
{
    public class ConfigItem
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public object Value { get; set; }

    }
}
