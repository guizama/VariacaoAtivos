using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariacaoAtivos.Domain.Entities
{
    public class YahooQuote
    {
        public decimal?[]? Close { get; set; }
        public decimal?[]? Open { get; set; }
        public decimal?[]? Low { get; set; }
        public decimal?[]? High { get; set; }
        public decimal?[]? Volume { get; set; }
    }
}
