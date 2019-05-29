using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AdminApp
{
    public static class ServiceClient
    {
        internal async static Task<List<string>> GetCategoryNamesAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<string>>
            (await lcHttpClient.GetStringAsync("http://localhost:60064/api/inventory/GetCategoryNames/"));
        }

        internal async static Task<clsCategory> GetCategoryAsync(string prCategoryName)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<clsCategory>
            (await lcHttpClient.GetStringAsync("http://localhost:60064/api/inventory/GetCategory?CategoryName=" + prCategoryName));

        }

        private async static Task<string> InsertOrUpdateAsync<TItem>(TItem prItem, string prUrl, string prRequest)
        {
            using (HttpRequestMessage lcReqMessage = new HttpRequestMessage(new HttpMethod(prRequest), prUrl))
            using (lcReqMessage.Content =
        new StringContent(JsonConvert.SerializeObject(prItem), Encoding.Default, "application/json"))
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.SendAsync(lcReqMessage);
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }

        internal async static Task<string> UpdateProductAsync(clsProduct _Product)
        {
            return await InsertOrUpdateAsync(_Product, "http://localhost:60064/api/inventory/PutProduct", "PUT");
        }

        internal async static Task<string> InsertProductAsync(clsProduct _Product)
        {
            return await InsertOrUpdateAsync(_Product, "http://localhost:60064/api/inventory/PostProduct", "POST");
        }

        internal async static Task<string> InsertCategoryAsync(clsCategory prCategory)
        {
            return await InsertOrUpdateAsync(prCategory, "http://localhost:60064/api/inventory/PostCategory", "POST");
        }

        internal async static Task<string> UpdateCategoryAsync(clsCategory prCategory)
        {
            return await InsertOrUpdateAsync(prCategory, "http://localhost:60064/api/inventory/PutCategory", "PUT");
        }

        internal async static Task<string> DeleteProductAsync(clsProduct prProduct)
        {
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.DeleteAsync
            ($"http://localhost:60064/api/gallery/DeleteArtWork?WorkName={prProduct.ProductName}");
                return await lcRespMessage.Content.ReadAsStringAsync();
            }

        }
    }
}
