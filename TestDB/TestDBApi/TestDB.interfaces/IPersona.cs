using System;
using System.Collections.Generic;
using System.Text;
using TestDB.models;

namespace TestDB.interfaces
{
    public interface IPersona
    {
        Task<PersonaEmpresa> CrearEmpleadoPorEmpresa(int idEmpresa, PersonaEmpresa persona);

        Task<IEnumerable<PersonaEmpresa>> GetEmpleados();
    }
}
