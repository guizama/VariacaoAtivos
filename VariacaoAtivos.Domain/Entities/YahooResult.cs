using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariacaoAtivos.Domain.Entities
{
    [Table("YahooResult")]
    public class YahooResult
    {
        public YahooMeta? Meta { get; set; }
        public long?[]? Timestamp { get; set; }
        public YahooIndicator? Indicators { get; set; }
    }
}
