using MarektDemo.Models;
using MarektDemo.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarektDemo.Services.Concrete
{
    public class MarketService: IMarketable
    {
        private List<Product> products;
        private List<Sell> sells;
        private List<Sell_item> sell_İtems;
    }
}
