using Desafio_Turim.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Desafio_Turim.Context
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base() { }
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "FuncionariosDb");
        }

        public DbSet<Funcionarios> Funcionarios { get; set; }
    }
}