using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VariacaoAtivos.Domain.Entities;

namespace VariacaoAtivos.Domain.Interfaces
{
   public interface IBancoDados<T> where T : AtivoBase
    {
        void Inserir(T obj);
        IList<T> SelecionarTudo();
    }
}
