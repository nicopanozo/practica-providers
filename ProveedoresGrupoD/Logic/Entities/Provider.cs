using System;

namespace Logic.Entities
{
    public class Provider
    {
        public int Id { get; set;}
        public String Name { get; set; }
        public String LastName { get; set; }
        public String Numero { get; set; }

        public String Direccion { get; set; }
        public String Categoria { get; set; }
        public String Fecha { get; set; }

        public Boolean Status { get; set; }

        public Boolean Contract { get; set; }
        public int ContractExpiration { get; set; }
    }
}
