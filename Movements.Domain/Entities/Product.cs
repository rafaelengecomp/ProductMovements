using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movements.Domain.Entities
{
    public class Product
    {
        public string CodProduct { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public List<Cosif> Cosif { get; set; }
    }
}
