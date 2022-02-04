using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movements.Domain.Entities
{
    public class Movement
    {
        public int Month { get; set; }

        public int Year { get; set; }

        public int EntryNumber { get; set; }

        public string CodProduct { get; set; }
        
        public string CodCosif { get; set; }

        public string Description { get; set; }

        public DateTime MovimentDate { get; set; }

        public string UserCode { get; set; }

        public int Value { get; set; }
    }
}
