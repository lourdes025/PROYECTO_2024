using Microsoft.EntityFrameworkCore;
using PROYECTO_2024.BD.DATA.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_2024.BD.DATA
{
    public class Context : DbContext
    {
        public DbSet<Tdocumento> Tdocumentos { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Localidad> Localidades { get; set; }
        public DbSet<Validacion> Validaciones { get; set; }
        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFks = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership
                            && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fk in cascadeFks)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
