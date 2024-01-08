using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VariacaoAtivos.Domain.Entities;

namespace VariacaoAtivos.Domain.Interfaces
{
    public interface IServicoAPI<T> where T : AtivoBase
    {
        Ativo Inserir(Ativo obj);
        IList<Ativo> Get();
        YahooObject? GetAPI(string simbolo);
        string RetornaVariacao(decimal? valorAtual, decimal? valorAnterior);
    }
}
