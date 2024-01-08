using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VariacaoAtivos.Domain.Entities;
using VariacaoAtivos.Domain.Interfaces;

namespace VariacaoAtivos.Service.Services
{
    public class ServicoAPI<T> : IServicoAPI<T> where T : AtivoBase
    {
        private readonly IBancoDados<Ativo> bancoDados;
        private readonly HttpClient httpClient;

        public ServicoAPI(IBancoDados<Ativo> bancoDados, HttpClient httpClient)
        {
            this.bancoDados = bancoDados;
            this.httpClient = httpClient;
        }

        public Ativo Inserir(Ativo obj)
        {
            this.bancoDados.Inserir(obj);
            return obj;
        }

        public IList<Ativo> Get()
        { 
           return this.bancoDados.SelecionarTudo ();
        }

        public YahooObject? GetAPI(string simbolo)
        {
            try
            {
                var resposta = this.httpClient.GetAsync(this.httpClient.BaseAddress + simbolo).GetAwaiter().GetResult();
                var resultado = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                YahooObject dadosDeserializados = JsonConvert.DeserializeObject<YahooObject>(resultado);

                return dadosDeserializados;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

       public string RetornaVariacao(decimal? valorAtual, decimal? valorAnterior)
        {
            if (valorAnterior == 0 || !valorAnterior.HasValue) return null;
            if (valorAtual == 0 || !valorAtual.HasValue) return null;

            var variacao = (valorAtual - valorAnterior) / valorAnterior * 100;

            return _ = variacao.ToString() + "%";
        }

    }
}
