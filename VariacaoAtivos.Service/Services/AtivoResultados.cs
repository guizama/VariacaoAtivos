using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VariacaoAtivos.Domain.Entities;
using System.Threading;
using VariacaoAtivos.Domain.Interfaces;
using System.Linq;

namespace VariacaoAtivos.Service.Services
{
    public class AtivoResultados : IHostedService, IDisposable
    {
        private Timer timer;

        public AtivoResultados(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public IServiceProvider ServiceProvider { get; private set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            SalvarAtivo();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private List<Ativo> SalvarAtivo()
        {
            try
            {
                var simbolo = "GME";

                using var scope = ServiceProvider.CreateScope();
                var service = scope.ServiceProvider.GetRequiredService<IServicoAPI<Ativo>>();
                var resultado = service.GetAPI(simbolo);

                var resultadosUltimos30Dias = resultado.Chart.Result
                   .Where(result => result.Timestamp.Any(timestamp => DateTimeOffset.FromUnixTimeSeconds((long)timestamp).DateTime >= DateTime.UtcNow.AddDays(-30)))
                   .ToList();

                var valorInicial = resultadosUltimos30Dias[0].Indicators.Quote[0].Open[0];
                var valorAtual = 0.0m;
                var valorAnterior = resultadosUltimos30Dias[0].Indicators.Quote[0].Open[0];
                var listAtivo = new List<Ativo>();

                foreach (var ultimos30 in resultadosUltimos30Dias)
                {
                    for (int i = 0; i < ultimos30.Timestamp.Length; i++)
                    {
                        if (i == 112) { 
                            var tat = 0; }
                        var ativo = new Ativo();
                        ativo.Data = DateTimeOffset.FromUnixTimeSeconds((long)ultimos30.Timestamp[i]).DateTime.ToString();
                        ativo.Simbolo = simbolo;
                        ativo.Valor = ultimos30.Indicators.Quote[0].Open[i].HasValue ? (decimal)ultimos30.Indicators.Quote[0].Open[i] : 0;
                        valorAtual = ativo.Valor;
                        if (i > 0)
                        { 
                            ativo.Variacao1DiaMenos = service.RetornaVariacao(valorAtual, valorAnterior);
                            ativo.VariacaoGeral = service.RetornaVariacao(valorAtual, valorInicial);
                        }
                        valorAnterior = valorAtual;
                        listAtivo.Add( ativo );
                    }
                }
                return listAtivo;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
