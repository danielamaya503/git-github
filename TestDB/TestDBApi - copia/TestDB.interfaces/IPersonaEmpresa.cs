using System;
using System.Collections.Generic;
using System.Text;
using TestDB.models;

namespace TestDB.interfaces
{
    public interface IPersonaEmpresa
    {
        Task<IEnumerable<PersonaEmpresa>> ListadoEmpleados();
        Task<PersonaEmpresa> CrearEmpleado(PersonaEmpresa persona);
    }
}
