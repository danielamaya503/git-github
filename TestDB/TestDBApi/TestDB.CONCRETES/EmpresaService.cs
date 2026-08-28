using System;
using System.Collections.Generic;
using System.Text;
using TestDB.interfaces;
using TestDB.models;
using Microsoft.EntityFrameworkCore;

namespace TestDB.CONCRETES
{
    public class EmpresaService: IEmpresa
    {
        private readonly AppDbContext appDbContext;

        public EmpresaService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Empresa>> ListadoEmpresa()
        {
            return await appDbContext.Empresa.ToListAsync();
        }

        public async Task<Empresa> CrearEmpresa(Empresa empresa)
        {
            appDbContext.Add(empresa);
            await appDbContext.SaveChangesAsync();

            return empresa;
        }

        
    }
}
