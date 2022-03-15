using DesafioCursos.Enum;
using DesafioCursos.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DesafioCursos.Data
{
    public class CursosContext : DbContext
    {
        public CursosContext(DbContextOptions<CursosContext> options) : base(options)
        {
        }

        public DbSet<CursosModel> CursosModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CursosModel>(e =>
            {
                e.ToTable("Cursos");
                e.Property(p => p.NomeDoCurso).HasColumnType("varchar(30)").IsRequired();

            });
        }
    }
}
