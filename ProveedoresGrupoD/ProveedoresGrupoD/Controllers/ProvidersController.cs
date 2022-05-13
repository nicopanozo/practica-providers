using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.Managers;
using Logic.Entities;

namespace ProveedoresGrupoD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProvidersController : ControllerBase
    {
        private ProviderManager _providerManager;
        public ProvidersController(ProviderManager providerManager)
        {
            //se inyectan muchos managers los que se desee en el parentesis de este constructor
            _providerManager = providerManager;
        }

        [HttpGet]
        public IActionResult GetProviders()
        {
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

            return Ok(createdProvider);
        }

        [HttpPut]
        public IActionResult UpdateProviders(int id, string name, string lastname, string num, string direccion, string cat, string fecha, Boolean status)
        {
            Provider modifiedProvider = _providerManager.UpdateProvider(id, name, lastname, num, direccion, cat, fecha, status);
            return Ok(modifiedProvider);
        }

        [HttpDelete]
        public IActionResult DeleteProviders(int id)
        {
            Provider deletedProvider = _providerManager.DeleteProvider(id);
            return Ok(deletedProvider);
        }


        [HttpPost]
        [Route("json")]
        public IActionResult createJsonFile(string path)
        {
            string jsonProvider = _providerManager.createJsonFile(path);
            return Ok(jsonProvider);
        }
    }
}

