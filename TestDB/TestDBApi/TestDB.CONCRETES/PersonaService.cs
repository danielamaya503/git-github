using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestDB.interfaces;
using TestDB.models;

namespace TestDB.CONCRETES
{
    public class PersonaService : IPersona
    {
        private readonly AppDbContext appDbContext;

        public PersonaService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<PersonaEmpresa>> GetEmpleados()
        {
            return await appDbContext.PersonaEmpresa
                .Include(pe => pe.Persona)
                .Include(pe => pe.Empresa)
                .ToListAsync();
        }

        public async Task<PersonaEmpresa> CrearEmpleadoPorEmpresa(int idEmpresa, PersonaEmpresa persona)
        {
            var existeEmpresa = await appDbContext.Empresa.FirstOrDefaultAsync(e => e.id == idEmpresa);

            if (existeEmpresa is null)
            {
                return null;
            }

            if (persona.Persona is null)
            {
                return null;
            }

            var nuevaPersonas = persona.Persona;

            appDbContext.Persona.Add(nuevaPersonas);

            persona.idPersona = nuevaPersonas.id;
            persona.idEmpresa = existeEmpresa.id;

            persona.Persona = nuevaPersonas;
            persona.Empresa = existeEmpresa;

            appDbContext.PersonaEmpresa.Add(persona);


            await appDbContext.SaveChangesAsync();

            return await appDbContext.PersonaEmpresa
                .Include(pe => pe.Persona)
                .Include(pe => pe.Empresa)
                .AsNoTracking()
                .FirstAsync(pe => pe.id == persona.id);

        }

       
    }
}
