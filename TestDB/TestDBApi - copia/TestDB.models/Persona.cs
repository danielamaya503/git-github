using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace TestDB.models
{
    public class Persona
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Ocupacion { get; set; }
        [JsonIgnore]
        public virtual ICollection<PersonaEmpresa> PersonaEmpresas { get; set; } = new List<PersonaEmpresa>();
    }
}
