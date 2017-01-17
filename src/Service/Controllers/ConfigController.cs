using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.ConfigApi;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Service.Controllers
{
    [Route("api/[controller]")]
    public class ConfigController : Controller
    {
        /// <summary>
        /// http://localhost:5000/api/Config/
        /// </summary>
        /// <param name="configItems"></param>
        public ConfigController(IConfigRepository configItems)
        {
            ConfigItems = configItems;
        }
        [HttpGet]
        public IEnumerable<ConfigItem> GetAll()
        {
            return ConfigItems.GetAll();
        }

        /// <summary>
        /// http://localhost:5000/api/Config/f7700485-5bc0-4fd3-b7c3-e060521a21bb - sampleguid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{Id}", Name = "GetConfig")]
        public IActionResult GetById(string id)
        {
            var config = ConfigItems.Find(id);
            if (config == null) return NotFound();
            return new ObjectResult(config);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ConfigItem config)
        {
            if (config == null)
            {
                return BadRequest();
            }

            ConfigItems.Add(config);
            return CreatedAtRoute("GetConfig", new { id = config.Key }, config);
        }

        [HttpPost]
        public IActionResult Update([FromBody] ConfigItem config)
        {
            if (config == null) return BadRequest();
            ConfigItems.Update(config);
            return CreatedAtRoute("GetConfig", new { id = config.Key }, config);
        }
        [HttpPost]
        public IActionResult Delete([FromBody] ConfigItem config)
        {
            if (config == null) return BadRequest();
            ConfigItems.Remove(config.Key);
            return CreatedAtRoute("GetConfig", new { id = config.Key }, config);
        }
        public IConfigRepository ConfigItems;
    }
}
