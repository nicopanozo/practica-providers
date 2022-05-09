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
        public IActionResult CreateProviders(string name, string lastname, string ci)
        {
            ProviderManager providerManager = new ProviderManager();
            Provider createdProvider = providerManager.CreateProviders(name, lastname, ci);
            return Ok(createdProvider);
        }
        [HttpPut]
        public IActionResult UpdateProviders()
        {
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteProviders()
        {
            return Ok();
        }
    }
}

