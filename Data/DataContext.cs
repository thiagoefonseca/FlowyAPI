using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoFInalApi.Models;
using ProjetoFInalApi.Models.Enuns;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ProjetoFInalApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Pagina> TB_PAGINAS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pagina>().ToTable("TB_PAGINAS");

            modelBuilder.Entity<Pagina>().HasData(
                new Pagina() { Id = 1, codDiario = 1, tituloPagina = "Pagina1", temaPagina = "teste",
                dtCriacaoPagina = DateTime.Now,
                contPagina = "teste 123 123 teste de novo", Humor = HumorEnum.FELIZ,
                qtdCaracteresPagina = 123,
                }
            );
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveColumnType("varchar").HaveMaxLength(200);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings
                .Ignore(RelationalEventId.PendingModelChangesWarning));
        }
    }
}