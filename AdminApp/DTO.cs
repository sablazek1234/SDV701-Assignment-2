using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp
{
    public class clsCategory
    {
        public string Category { get; set; }
        public string Description { get; set; }

        public List<clsProduct> ProductList { get; set; }
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

        public override string ToString()
        {
            return ProductName + "\t" + ProductType + "\t" + Brand + "\t" + NewOrUsed + "\t" +
            Quantity + "\t" + Price + "\t" + DateModified.ToShortDateString();
        }

        public static readonly string FACTORY_PROMPT = "Enter N for New and U for Used";

        public static clsProduct NewProduct(char prChoice)
        {
            return new clsProduct() { NewOrUsed = prChoice.ToString() };
        }
    }

    public class clsOrderDetails
    {
        public int ProductID { get; set; }
        public string CustomerName { get; set; }
        public int CustomerPhone { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime DatePurchased { get; set; }

        //public List<clsProduct> OrderDetailsList { get; set; }
    }
}
