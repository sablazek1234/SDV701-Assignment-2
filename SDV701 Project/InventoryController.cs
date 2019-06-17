using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace APISelfHosted
{
    public class InventoryController : ApiController
    {
        public List<string> GetCategoryNames()
        {
            DataTable lcResult = clsDBConnection.GetDataTable("SELECT Category FROM tblCategory", null);
            List<string> lcNames = new List<string>();
            foreach (DataRow dr in lcResult.Rows)
                lcNames.Add((string)dr[0]);
            return lcNames;
        }

        public clsCategory GetCategory(string CategoryName)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("Category", CategoryName);
            DataTable lcResult =
            clsDBConnection.GetDataTable("SELECT * FROM tblCategory WHERE Category = @Category", par);
            if (lcResult.Rows.Count > 0)
                return new clsCategory()
                {
                    Category = (string)lcResult.Rows[0]["Category"],
                    Description = (string)lcResult.Rows[0]["Description"],
                    ProductList = GetProducts(CategoryName)
                };
            else
                return null;
        }

        public List<string> GetProductNames()
        {
            DataTable lcResult = clsDBConnection.GetDataTable("SELECT ProductName FROM tblProduct", null);
            List<string> lcNames = new List<string>();
            foreach (DataRow dr in lcResult.Rows)
                lcNames.Add((string)dr[0]);
            return lcNames;
        }

        private List<clsProduct> GetProducts(string CategoryName)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("CategoryName", CategoryName);
            DataTable lcResult = 
            clsDBConnection.GetDataTable("SELECT * FROM tblProduct WHERE Category = @CategoryName", par);
            List<clsProduct> lcProducts = new List<clsProduct>();
            foreach (DataRow dr in lcResult.Rows)
                lcProducts.Add(dataRowProduct(dr));
            return lcProducts;

        }

        private clsProduct dataRowProduct(DataRow prDataRow)
        {
            return new clsProduct()
            {
                ProductID = Convert.ToInt16(prDataRow["ProductID"]),
                Category = Convert.ToString(prDataRow["Category"]),
                ProductName = Convert.ToString(prDataRow["ProductName"]),
                ProductType = Convert.ToString(prDataRow["ProductType"]),
                Brand = Convert.ToString(prDataRow["Brand"]),
                NewOrUsed = Convert.ToString(prDataRow["NewOrUsed"]),
                Warranty = Convert.ToString(prDataRow["Warranty"]),
                Condition = Convert.ToString(prDataRow["Condition"]),
                Quantity = Convert.ToInt16(prDataRow["Quantity"]),
                DateModified = Convert.ToDateTime(prDataRow["DateModified"]),
                Price = Convert.ToDecimal(prDataRow["Price"]),
            };

        }

        public string PutCategory(clsCategory prCategory)
        {   // update
            try
            {
                int lcRecCount = clsDBConnection.Execute(
        "UPDATE tblCategory SET Category = @Category, WHERE Description = @Description",
        prepareCategoryParameters(prCategory));
                if (lcRecCount == 1)
                    return "One category updated";
                else
                    return "Unexpected category update count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public string DeleteProduct(string ProductID)
        { 
            try
            {
                Dictionary<string, object> par = new Dictionary<string, object>(3);
                par.Add("ProductID", ProductID);
                int lcRecCount = clsDBConnection.Execute(
     //   "DELETE FROM tblProduct WHERE ProductID=" + ProductID, null);
                "DELETE FROM tblProduct WHERE ProductID=@ProductID", par);
                if (lcRecCount == 1)
                    return "One product deleted";
                else
                    return "Unexpected products delete count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public string PostCategory(clsCategory prCategory)
        {   
            try
            {
                int lcRecCount = clsDBConnection.Execute(
        "Insert Into Category(Category,Description) Values(@Category, @Description)",
        prepareCategoryParameters(prCategory));
                if (lcRecCount == 1)
                    return "One category inserted";
                else
                    return "Unexpected category insert count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        private Dictionary<string, object> prepareCategoryParameters(clsCategory prCategory)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(3);
            par.Add("Category", prCategory.Category);
            par.Add("Description", prCategory.Description);
            return par;
        }

        public string PutProduct(clsProduct prProduct)
        {   
            try
            {
                int lcRecCount = clsDBConnection.Execute("UPDATE tblProduct SET " +
                "ProductName = @ProductName, ProductType = @ProductType, Brand = @Brand," +
                "NewOrUsed = @NewOrUsed, Warranty = @Warranty, Condition = @Condition, Quantity = @Quantity," +
                "DateModified = @DateModified, Price = @Price " +
                "WHERE ProductID = @ProductID",
                prepareProductParameters(prProduct));
                if (lcRecCount == 1)
                    return "One product updated";
                else
                    return "Unexpected product update count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        public string PostProduct(clsProduct prProduct)
        {  
            try
            {
                int lcRecCount = clsDBConnection.Execute("INSERT INTO tblProduct " +
                "(Category, ProductName, ProductType, Brand, NewOrUsed, Warranty, Condition, Quantity, DateModified, Price) " +
                "VALUES (@Category, @ProductName, @ProductType, @Brand, @NewOrUsed, @Warranty, @Condition, @Quantity, @DateModified, @Price)",
                prepareProductParameters(prProduct));
                if (lcRecCount == 1)
                    return "One product inserted";
                else
                    return "Unexpected product insert count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }

        private Dictionary<string, object> prepareProductParameters(clsProduct prProduct)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(11);
            par.Add("ProductID", prProduct.ProductID);
            par.Add("Category", prProduct.Category);
            par.Add("ProductName", prProduct.ProductName);
            par.Add("ProductType", prProduct.ProductType);
            par.Add("Brand", prProduct.Brand);
            par.Add("NewOrUsed", prProduct.NewOrUsed);
            par.Add("Warranty", prProduct.Warranty);
            par.Add("Condition", prProduct.Condition);
            par.Add("Quantity", prProduct.Quantity);
            par.Add("DateModified", prProduct.DateModified);
            par.Add("Price", prProduct.Price);
            return par;
        }

        public List<clsOrderDetails> GetOrders()
        {
            DataTable lcResult =
            clsDBConnection.GetDataTable("SELECT * FROM tblOrderDetails JOIN tblProduct ON tblOrderDetails.ProductID = tblProduct.ProductID", null);
            List<clsOrderDetails> lcOrders = new List<clsOrderDetails>();
            foreach (DataRow dr in lcResult.Rows)
                lcOrders.Add(dataRowOrder(dr));
            return lcOrders;

        }

        private clsOrderDetails dataRowOrder(DataRow prDataRow)
        {
            return new clsOrderDetails()
            {
                OrderID = Convert.ToInt16(prDataRow["OrderID"]),
           //     ProductID = Convert.ToInt16(prDataRow["ProductID"]),
                ProductName = Convert.ToString(prDataRow["ProductName"]),
                CustomerName = Convert.ToString(prDataRow["CustomerName"]),
                CustomerPhone = Convert.ToString(prDataRow["CustomerPhone"]),
                DateOfPurchase = Convert.ToDateTime(prDataRow["DateOfPurchase"]),                
                Price = Convert.ToDecimal(prDataRow["Price"]),
                Quantity = Convert.ToInt16(prDataRow["Quantity"]),
            };

        }

        private Dictionary<string, object> prepareOrderParameters(clsOrderDetails prOrder)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(7);
            par.Add("OrderID", prOrder.OrderID);
            par.Add("ProductID", prOrder.ProductID);
            par.Add("CustomerName", prOrder.CustomerName);
            par.Add("CustomerPhone", prOrder.CustomerPhone);
            par.Add("DateOfPurchase", prOrder.DateOfPurchase);
            par.Add("Price", prOrder.Price);
            par.Add("Quantity", prOrder.Quantity);
            return par;
        }

        public string DeleteOrder(string OrderID)
        {
            try
            {
                Dictionary<string, object> par = new Dictionary<string, object>(3);
                par.Add("OrderID", OrderID);
                int lcRecCount = clsDBConnection.Execute(
                "DELETE FROM tblOrderDetails WHERE OrderID=@OrderID", par);
                if (lcRecCount == 1)
                    return "One order deleted";
                else
                    return "Unexpected order delete count: " + lcRecCount;
            }
            catch (Exception ex)
            {
                return ex.GetBaseException().Message;
            }
        }
    }
}
