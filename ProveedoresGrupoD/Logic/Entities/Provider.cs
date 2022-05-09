using Services;
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
        public DateTime Fecha { get; set; }
        public Company Company { get; set; }
    }
}
