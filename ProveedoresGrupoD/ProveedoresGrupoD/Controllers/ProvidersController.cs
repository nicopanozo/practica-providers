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
    [Route("/[controller]")]
    public class ProvidersController : ControllerBase
    {
        public ProvidersController()
        {
            //Darle Http methods, GET, POST, PUT, DELETE
        }

        [HttpGet]
        public IActionResult GetProviders()
        {
            ProviderManager providerManager = new ProviderManager();
            return Ok(providerManager.GetProviders());
        }

        [HttpPost]
        public IActionResult CreateProviders(int id, string name, string lastname, string num, string direccion, string cat, DateTime fecha)
        {
            ProviderManager providerManager = new ProviderManager();
            Provider createdProvider = providerManager.CreateProviders(id, name, lastname, num, direccion, cat, fecha);
            return Ok(createdProvider);
        }
        [HttpPut]
        public IActionResult UpdateProviders(int id, string name, string lastname, string num, string direccion, string cat, DateTime fecha)
        {
            ProviderManager providerManager = new ProviderManager();
            Provider modifiedProvider = providerManager.UpdateProvider(id, name, lastname, num, direccion, cat, fecha);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteProviders(int id)
        {
            ProviderManager providerManager = new ProviderManager();
            Provider deletedProvider = providerManager.DeleteProvider(id);
            return Ok(deletedProvider);
        }

    }
}

