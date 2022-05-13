using System;
using System.Collections.Generic;
using System.IO;
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
            _providers.Add(new Provider() { Id = 1, Name = "Nicolas", LastName = "Panozo", Numero = "6500000", Direccion = "Av Siempre Viva #1005", Categoria = "SOCCER", Fecha = "2022-05-13" , Status = false });
            _providers.Add(new Provider() {Id = 2, Name = "Michael", LastName = "Jordan", Numero = "4578209", Direccion = "Av Circunvalación #892", Categoria = "BASKET", Fecha = "2022-05-01",Status = false });
            _providers.Add(new Provider() {Id = 3, Name = "Adam", LastName = "Sandler", Numero = "438294", Direccion = "c/ Pedro de Valdivia #4678", Categoria = "BASKET", Fecha = "2022-06-12",Status = false });
        }

        public List<Provider> GetProviders()
        {
            var ingreso = new DateTime();
            List<Provider> _list = new List<Provider>();
            foreach (Provider p in _providers)
            {
                if (p.Company == null)
                {
                    company = _companyService.GetCompany().Result;
                    p.Company = company;
                }
                ingreso = DateTime.Parse(p.Fecha);
                p.ContractExpiration = (ingreso.Date - DateTime.Today).Days;
                p.Contract = p.ContractExpiration>0?true:false;
                _list.Add(p);
            }
            _providers = _list;
            return _list;
        }

        public int FindProvider(int id)
        {
            int dias = 0;
            Provider _provider = new Provider();
            foreach( Provider p in _providers)
            {
                if (p.Id == id)
                    _provider = p;
            }
            var ingreso = DateTime.Parse(_provider.Fecha);
            dias =  (ingreso.Date - DateTime.Today).Days; 
            return dias;
        }

        public List<Provider> GetProviderStatus()
        {
            List<Provider> _list = new List<Provider>();
            foreach (Provider prov in _list)
            {
                if (prov.Status == true)
                    _list.Add(prov);
            }
            return _list;
        }

        public Provider CreateProviders(int id, string name, string lastname, string num, string direccion, string cat, string fecha)
        {
            Provider createdProvider = new Provider() {Id = id, Name = name, LastName = lastname, Numero = num, Direccion = direccion, Categoria = cat, Fecha = fecha, Company = null };
            _providers.Add(createdProvider);
            return createdProvider;
        }

        public Provider UpdateProvider(int id, string name, string lastname, string num, string direccion, string cat, string fecha, Boolean status)
        {
            Provider _provider = new Provider();
            foreach (Provider p in _providers)
            {
                if (p.Id == id)
                    _provider = p;
            }
            string _fecha = fecha == null ? _provider.Fecha : fecha;
            DateTime dt;

            var isValidDate = DateTime.TryParse(_fecha, out dt);
            if (isValidDate)
                Console.WriteLine(dt);
            else
                Console.WriteLine($"{_fecha} no es una cadena de fecha");

            _providers[id-1].Name = name==null?_provider.Name:name;
            _providers[id-1].LastName = lastname == null ? _provider.LastName : lastname; 
            _providers[id-1].Numero =  num == null ? _provider.Numero : num;
            _providers[id-1].Direccion =  direccion == null ? _provider.Direccion : direccion;
            _providers[id-1].Categoria =  cat == null ? _provider.Categoria : cat;
            _providers[id - 1].Fecha = _fecha;
            _providers[id - 1].Status =  status;

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
            _providers[id].Status = true;
        }
    }
}
