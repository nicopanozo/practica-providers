using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.Managers;
using Logic.Entities;
using Serilog;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace ProveedoresGrupoD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProvidersController : ControllerBase
    {
        private ProviderManager _providerManager;
        private IConfiguration config;
        
        public ProvidersController(ProviderManager providerManager, IConfiguration config)
        {
            //se inyectan muchos managers los que se desee en el parentesis de este constructor
            _providerManager = providerManager;
            this.config = config;
        }

        [HttpGet]
        [Route("/search-providers")]
        public IActionResult GetProviders()
        {
            List<Provider> jsonlistprov = JsonConvert.DeserializeObject<List<Provider>>(System.IO.File.ReadAllText(config.GetSection("jsonPATH").Value));
            _providerManager.SetListJson(jsonlistprov);
            Log.Information("Antes de pedir companys");
            return Ok(_providerManager.GetProviders());
        }


        [HttpGet]
        [Route("find")]
        public IActionResult FindProvider(int id)
        {
            return Ok(_providerManager.FindProvider(id));
        }
        
        [HttpPost]
        public IActionResult CreateProviders(int id, string name, string lastname, string num, string direccion, string cat, string fecha)
        {
            Provider createdProvider = _providerManager.CreateProviders(id, name, lastname, num, direccion, cat, fecha);
            string json = JsonConvert.SerializeObject(_providerManager.GetProviders());
            System.IO.File.WriteAllText(config.GetSection("jsonPATH").Value, json);//path config
            return Ok(createdProvider);
        }

        [HttpPut]
        public IActionResult UpdateProviders(int id, string name, string lastname, string num, string direccion, string cat, string fecha, Boolean status)
        {
            Provider modifiedProvider = _providerManager.UpdateProvider(id, name, lastname, num, direccion, cat, fecha, status);
            string json = JsonConvert.SerializeObject(_providerManager.GetProviders());
            System.IO.File.WriteAllText(config.GetSection("jsonPATH").Value, json);//path config
            return Ok(modifiedProvider);
        }

        [HttpDelete]
        public IActionResult DeleteProviders(int id)
        {
            Provider deletedProvider = _providerManager.DeleteProvider(id);
            string json = JsonConvert.SerializeObject(_providerManager.GetProviders());
            System.IO.File.WriteAllText(config.GetSection("jsonPATH").Value, json);//path config
            return Ok(deletedProvider);
        }

        
    }
}

