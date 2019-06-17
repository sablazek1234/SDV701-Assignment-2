using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APISelfHosted
{   
    public class clsCategory
    {
        public string Category { get; set; }
        public string Description { get; set; }

        public List<clsProduct> ProductList { get; set; }
        public List<clsOrderDetails> OrderList { get; set; }
    }

    public class clsProduct
    {
        public int ProductID { get; set; }
        public string Category { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public string Brand { get; set; }
        public string NewOrUsed { get; set; }
        public string Warranty { get; set; }
        public string Condition { get; set; }
        public int Quantity { get; set; }
        public DateTime DateModified { get; set; }  
        public decimal Price { get; set; }
    }

    public class clsOrderDetails
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
