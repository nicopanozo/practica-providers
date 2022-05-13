using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Entities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Services;

namespace Logic.Managers
{
    public class ProviderManager
    {
        private List<Provider> _providers;
        private IConfiguration _configuration;
        private CompanyService _companyService;
        Company company;
        public ProviderManager(IConfiguration configuration, CompanyService companyService)
        {
            _configuration = configuration;
            _companyService = companyService;
            _providers = new List<Provider>();
            _providers.Add(new Provider() { Id = 1, Name = "Nicolas", LastName = "Panozo", Numero = "6500000", Direccion = "Av Siempre Viva #1005", Categoria = "Fútbol", Fecha = DateTime.Today, Status = "Disabled" });
            _providers.Add(new Provider() {Id = 2, Name = "Michael", LastName = "Jordan", Numero = "4578209", Direccion = "Av Circunvalación #892", Categoria = "Basquet", Fecha = DateTime.Today,Status = "Disabled" });
            _providers.Add(new Provider() {Id = 3, Name = "Adam", LastName = "Sandler", Numero = "438294", Direccion = "c/ Pedro de Valdivia #4678", Categoria = "Fútbol", Fecha = DateTime.Today,Status = "Disabled" });
        }

        public List<Provider> GetProviders()
        {
            foreach (Provider prov in _providers)
            {
                if (prov.Company == null)
                {
                    company = _companyService.GetCompany().Result;
                    prov.Company = company;
                }
            }
            return _providers;
        }

        public Provider CreateProviders(int id, string name, string lastname, string num, string direccion, string cat, DateTime fecha)
        {
            Provider createdProvider = new Provider() {Id = id, Name = name, LastName = lastname, Numero = num, Direccion = direccion, Categoria = cat, Fecha = fecha, Company = null };
            _providers.Add(createdProvider);
            return createdProvider;
        }

        public Provider UpdateProvider(int id, string name, string lastname, string num, string direccion, string cat, DateTime fecha, String status)
        {
            _providers[id-1].Name = name;
            _providers[id-1].LastName = lastname;
            _providers[id-1].Numero = num;
            _providers[id-1].Direccion = direccion;
            _providers[id-1].Categoria = cat;
            _providers[id-1].Fecha = fecha;
            _providers[id - 1].Status = status;
            return _providers[id-1];
        }

        public Provider DeleteProvider(int id)
        {
            Provider deletedProduct = _providers[id-1];
            _providers.Remove(_providers[id-1]);
            return deletedProduct;
        }

        public void EnableProvider(int id)
        {
            Provider providerFound = _providers.Find(provider => provider.Id == id);
            _providers[id].Status = "Enable";
        }
    }
}
