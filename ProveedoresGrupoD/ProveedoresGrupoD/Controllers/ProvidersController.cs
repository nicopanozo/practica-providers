using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.Managers;
using Logic.Entities;
using ActiveDirectoryService;

namespace ProveedoresGrupoD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProvidersController : ControllerBase
    {
        private ProviderManager _providerManager;
        private List<Provider> _listProviders;

        public ProvidersController(ProviderManager providerManager)
        {
            _providerManager = providerManager;
        }

        [HttpGet]
        [Route("/search-providers")]
        public IActionResult GetProviders([FromHeader] string filtro)
        {
            if (filtro == "All" | filtro == null)
            {
                _listProviders = _providerManager.GetProviders();
            }else if(filtro == "only enable")
            {
                _listProviders = _providerManager.GetProviderStatus();
            }
            return Ok(_listProviders);
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
    }
}

