using eMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMarket.ViewModels
{
        public class NewProductDropdownsVM
        {
            public NewProductDropdownsVM()
            {
               
                Dealers = new List<Dealer>();
            }

        
            public List<Dealer> Dealers { get; set; }
        }
    }

