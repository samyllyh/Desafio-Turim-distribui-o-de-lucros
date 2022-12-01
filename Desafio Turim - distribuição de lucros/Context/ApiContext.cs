using Desafio_Turim.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Desafio_Turim.Context
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        public DbSet<Funcionarios> Funcionarios { get; set; }
    }
}