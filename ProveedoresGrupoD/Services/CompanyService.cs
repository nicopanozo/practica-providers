using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Services
{
    public class CompanyService
    {
        private IConfiguration _configuration;
        public CompanyService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<Company> GetCompany()
        {
            string companyURL = _configuration.GetSection("companyURL").Value;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(companyURL);
            Company company;
            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                company = JsonConvert.DeserializeObject<Company>(responseData);
            }
            else
            {
                company = new Company();
            }
            return company;
        }
    }
}
