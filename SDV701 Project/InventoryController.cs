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
                    //??????????????????????????????????????????????????????????
                    ProductList = getProduct(CategoryName)
                };
            else
                return null;
        }

        private List<clsProduct> getProduct(string ProductName)
        {
            Dictionary<string, object> par = new Dictionary<string, object>(1);
            par.Add("ProductName", ProductName);
            DataTable lcResult = clsDBConnection.GetDataTable("SELECT * FROM tblProduct WHERE ProductName = @ProductName", par);
            List<clsProduct> lcWorks = new List<clsProduct>();
            foreach (DataRow dr in lcResult.Rows)
                lcWorks.Add(dataRowProduct(dr));
            return lcWorks;

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

        //?????????????????????????????????????????????????????
        public string DeleteProduct(string ProductName)
        {   // delete
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

        //?????????????????????????????????????????????
        public string PutProduct(clsProduct prProduct)
        {   // update
            try
            {
                int lcRecCount = clsDBConnection.Execute("UPDATE tblProduct SET " +
                "ProductName = @ProductName, ProductType = @ProductType, Brand = @Brand," +
                "NewOrUsed = @NewOrUsed, Warranty = @Warranty, Quantity = @Quantity, DateModified = @DateModified",
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
        {   // insert
            try
            {
                int lcRecCount = clsDBConnection.Execute("INSERT INTO tblProduct " +
                "(ProductID, ProductName, ProductType, Brand, NewOrUsed, Warranty, Quantity, DateModified) " +
                "VALUES (@ProductID, @ProductName, @ProductType, @Brand, @NewOrUsed, @Warranty, @Quantity, @DateModified)",
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
            par.Add("Quantity", prProduct.Quantity);
            par.Add("DateModified", prProduct.DateModified);
            return par;
        }


    }
}
