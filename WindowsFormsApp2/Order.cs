using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class Order
    {
        public SortedList<int, int> quantities { get; set; }
        public int OrderID { get; set; }
        public int? DiscountCode { get; set; }
    }
}
