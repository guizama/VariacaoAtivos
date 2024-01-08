using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VariacaoAtivos.BD.Context;
using VariacaoAtivos.Domain.Entities;
using VariacaoAtivos.Domain.Interfaces;

namespace VariacaoAtivos.BD.Repository
{
    public class BancoDados<TEntity> : IBancoDados<TEntity> where TEntity : AtivoBase
    {
        protected readonly SQL sqlContext;

        public BancoDados(SQL sqlContext)
        {
            this.sqlContext = sqlContext;
        }

        public void Inserir(TEntity obj)
        {
            this.sqlContext.Set<TEntity>().Add(obj);
            this.sqlContext.SaveChanges();
        }

        public IList<TEntity> SelecionarTudo()
        {
            var result = this.sqlContext.AtivoConsulta.OrderByDescending(c => c.Dia).Take(30);
            return (IList<TEntity>)result.ToList();
        }
    }
}
