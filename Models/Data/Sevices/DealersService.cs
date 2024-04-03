using eTickets.Data;
using eTickets.Data.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMarket.Models.Data.Sevices
{
  public class DealersService : EntityBaseRepository<Dealer>, IDealersService
    {

        public DealersService(AppDbContext context) : base(context) { }
    }
}
