using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariacaoAtivos.Domain.Entities
{
    public class AtivoBase
    {
        [Key]
        public virtual int Dia { get; set; }
    }
}
