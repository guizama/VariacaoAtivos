using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariacaoAtivos.Domain.Entities
{
    [Table("Ativo")]
    public class Ativo : AtivoBase
    {
        public string Data { get; set; }
        public decimal Valor { get; set; }
        public string? Variacao1DiaMenos { get; set; }
        public string? VariacaoGeral { get; set; }
        public string? Simbolo { get; set; }
    }
}
