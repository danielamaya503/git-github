using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace TestDB.models
{
    public class Empresa
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        [JsonIgnore]
        public virtual ICollection<PersonaEmpresa> PersonaEmpresas { get; set; } = new List<PersonaEmpresa>();
    }
}
