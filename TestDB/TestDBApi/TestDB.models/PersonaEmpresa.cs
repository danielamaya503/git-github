using System;
using System.Collections.Generic;
using System.Text;

namespace TestDB.models
{
    public class PersonaEmpresa
    {
         public int id { get; set; }
        public int idPersona { get; set; }
        public int idEmpresa { get; set; }
        public DateTime FechaContrato { get; set; }
        public DateTime FechaFinContrato { get; set; }
        public virtual Persona? Persona { get; set; } = null!;
        public virtual Empresa? Empresa { get; set; } = null!;
    }
}
