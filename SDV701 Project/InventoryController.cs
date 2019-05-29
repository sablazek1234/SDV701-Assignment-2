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
                ProductName = Convert.ToString(prDataRow["ProductName"]),
                ProductType = Convert.ToString(prDataRow["ProductType"]),
                Brand = Convert.ToString(prDataRow["Brand"]),
                NewOrUsed = Convert.ToString(prDataRow["NewOrUsed"]),
                Warranty = Convert.ToString(prDataRow["Warranty"]),
                Condition = Convert.ToString(prDataRow["Condition"]),
                Quantity = Convert.ToInt16(prDataRow["Quantity"]),
                DateModified = Convert.ToDateTime(prDataRow["DateModified"]),
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

        public string DeleteProduct(string ProductName)
        { 
            try
            {
                int lcRecCount = clsDBConnection.Execute(
        "DELETE FROM tblProduct WHERE ProductName='" + ProductName, null);
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
                "DateModified = @DateModified",
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
                "(ProductID, ProductName, ProductType, Brand, NewOrUsed, Warranty, Condition, Quantity, DateModified) " +
                "VALUES (@ProductID, @ProductName, @ProductType, @Brand, @NewOrUsed, @Warranty, @Condition, @Quantity, @DateModified)",
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
            Dictionary<string, object> par = new Dictionary<string, object>(10);
            par.Add("ProductID", prProduct.ProductID);
            par.Add("ProductName", prProduct.ProductName);
            par.Add("ProductType", prProduct.ProductType);
            par.Add("Brand", prProduct.Brand);
            par.Add("NewOrUsed", prProduct.NewOrUsed);
            par.Add("Warranty", prProduct.Warranty);
            par.Add("Condition", prProduct.Condition);
            par.Add("Quantity", prProduct.Quantity);
            par.Add("DateModified", prProduct.DateModified);
            return par;
        }


    }
}
