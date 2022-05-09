using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Entities;

namespace Logic.Managers
{
    public class ProviderManager
    {
        private List<Provider> _providers;
        public ProviderManager()
        {
            _providers = new List<Provider>();
            _providers.Add(new Provider() { Name = "Nicolas", LastName = "Panozo", CI = "6500000" });
            _providers.Add(new Provider() { Name = "Michael", LastName = "Jordan", CI = "4578209" });
            _providers.Add(new Provider() { Name = "Adam", LastName = "Sandler", CI = "438294" });
        }

        public List<Provider> GetProviders()
        {

            return _providers;
        }

        public Provider CreateProviders(string name, string lastname, string ci)
        {
            Provider createdProvider = new Provider() { Name = name, LastName = lastname, CI = ci };
            _providers.Add(createdProvider);
            return createdProvider;
        }




    }
}
