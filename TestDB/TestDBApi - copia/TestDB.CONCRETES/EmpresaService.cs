using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestDB.interfaces;
using TestDB.models;

namespace TestDB.CONCRETES
{
    public class EmpresaService: IEmpresa
    {
        private readonly AppDbContext contex;

        public EmpresaService(AppDbContext appDbContext) {
            this.contex = appDbContext;
        }

        public async Task<IEnumerable<Empresa>> ListadoEmpresa()
        {
            return await contex.Empresa.AsNoTracking().ToListAsync();
        }
        public async Task<Empresa> CrearEmpresa(Empresa empresa)
        {
            if (empresa is null)
            {
                return null!;
            }

            contex.Empresa.Add(empresa);

            await contex.SaveChangesAsync();

            return empresa;
        }

    }
}
