using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VariacaoAtivos.Domain.Entities;

namespace VariacaoAtivos.BD.Context
{
    public class SQL : DbContext
    {
        protected readonly IConfiguration Configuration;

        public SQL() { }

        public SQL(DbContextOptions<SQL> options) : base(options) { }

        public DbSet<Ativo> AtivoConsulta { get; set; }
    }
}
