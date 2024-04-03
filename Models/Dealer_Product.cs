using eMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Dealer_Product
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int DealerId { get; set; }
        public Dealer Dealer { get; set; }
    }
}