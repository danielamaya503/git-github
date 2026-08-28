using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestDB.interfaces;
using TestDB.models;

namespace TestDB.CONCRETES
{
    public class PersonaEmpresaService: IPersonaEmpresa
    {
        private readonly AppDbContext context;

        public PersonaEmpresaService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<PersonaEmpresa>> ListadoEmpleados()
        {
            var listado = await context.PersonaEmpresa
                .Include(pe => pe.Persona)
                .Include(pe => pe.Empresa)
                .AsNoTracking()
                .ToListAsync();

            return listado;
        }

        public async Task<PersonaEmpresa> CrearEmpleado(PersonaEmpresa persona)
        {
            if (persona.Persona is null)
                return null!;

            var existeEmpresa = await context.Empresa.FirstOrDefaultAsync(e => e.id == persona.idEmpresa);

            if (existeEmpresa is null)
                return null!;

            var nuevaPersona = persona.Persona;
            context.Persona.Add(nuevaPersona);

            persona.Persona = nuevaPersona;
            persona.Empresa = existeEmpresa;

            persona.idPersona = nuevaPersona.id;
            persona.idEmpresa = existeEmpresa.id;

            context.PersonaEmpresa.Add(persona);

            await context.SaveChangesAsync();

            var empleadoCreado = await context.PersonaEmpresa
                .Include(pe => pe.Persona)
                .Include(pe => pe.Empresa)
                .FirstAsync(pe => pe.id == persona.id);

            return empleadoCreado;
        }
    }
}
