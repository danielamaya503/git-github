using System;
using System.Collections.Generic;
using System.Text;
using TestDB.models;

namespace TestDB.interfaces
{
    public interface IEmpresa
    {
        Task<IEnumerable<Empresa>> ListadoEmpresa();
        Task<Empresa> CrearEmpresa(Empresa empresa);
    }
}
