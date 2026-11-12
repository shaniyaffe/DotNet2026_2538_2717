using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalFacade.Do
{
    public record Sale
    {
        public int SaleId { get; set; }
        public Product ProductId { get; set; }
        public int CountMinSale { get; set; }
        public int CountAllPrice { get; set; }
        public bool Every { get; set; }
        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }

    }
}
