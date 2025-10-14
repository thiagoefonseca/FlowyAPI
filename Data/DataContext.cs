using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlowyAPI.Models;
using FlowyAPI.Models.Enuns;
using Microsoft.EntityFrameworkCore.Diagnostics;
using FlowyAPI.Utils;

namespace FlowyAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Pagina> tbl_pagina { get; set; }
        public DbSet<Usuario> tbl_usuario { get; set; }
        public DbSet<Exercicio> tbl_exercicios { get; set; }
        public DbSet<Quest> tbl_quest { get; set; }
        public DbSet<Perfil> tbl_perfil { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pagina>().ToTable("tbl_pagina");
            modelBuilder.Entity<Usuario>().ToTable("tbl_usuario");
            modelBuilder.Entity<Exercicio>().ToTable("tbl_exercicios");
            modelBuilder.Entity<Quest>().ToTable("tbl_quest");
            modelBuilder.Entity<Perfil>().ToTable("tbl_perfil");
            modelBuilder.Entity<Nivel>().ToTable("tbl_nivel");

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Paginas)
                .WithOne(e => e.Usuario)
                .HasForeignKey(e => e.UsuarioId)
                .IsRequired(false);

            modelBuilder.Entity<Pagina>().HasData(
                new Pagina()
                {
                    Id = 1,
                    codDiario = 1,
                    tituloPagina = "Pagina1",
                    temaPagina = "teste",
                    dtCriacaoPagina = DateTime.Now,
                    contPagina = "teste 123 123 teste de novo",
                    Humor = HumorEnum.FELIZ,
                    qtdCaracteresPagina = 123,
                    UsuarioId = 1,
                }
            );

            modelBuilder.Entity<Exercicio>().HasData(
                new Exercicio()
                {
                    Id = 1,
                    atividade = "Respiração",
                    descricao = "Eu adoro respirar",
                    relogio = 5,
                    dataTermino = DateTime.Now.AddMinutes(5),
                    tempo = DateTime.Now.AddMinutes(5) - DateTime.Now,
                    quantidade = 1,
                    UsuarioId = 1,
                }
            );

            Usuario user = new Usuario();
            Criptografia.CriarPasswordHash("123456", out byte[] hash, out byte[] salt);
            user.Id = 1;
            user.Username = "UsuarioAdmin";
            user.PasswordString = string.Empty;
            user.PasswordHash = hash;
            user.PasswordSalt = salt;
            user.idPerfil = 1;
            user.Email = "seuemail@email.com";

            modelBuilder.Entity<Usuario>().HasData(user);

            //modelBuilder.Entity<Usuario>().Property(u => u.Perfil).HasDefaultValue("Utilizador");
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveColumnType("varchar").HaveMaxLength(1500);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings
                .Ignore(RelationalEventId.PendingModelChangesWarning));
        }
    }
}