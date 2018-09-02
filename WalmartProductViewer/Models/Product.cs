using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WalmartProductViewer.Models
{
    /// <summary>
    /// The product data model
    /// </summary>
    /// <remarks> All business logic involving product goes here.</remarks>
    public class Product
    {
        [JsonProperty("itemID"), JsonRequired()]
        public String ItemID { get; set; }
        [JsonProperty("name"), JsonRequired()]
        public String Name { get; set; }
        [JsonProperty("thumbnailImage")]
        public String ThumbnailImage { get; set; }

        /// <summary>
        /// Uses the WalmartHttpClientService to query the Walmart Paginated API and deserializes response into list of product.
        /// </summary>
        /// <param name="id">A category ID</param>
        /// <returns>
        /// A list of all the departments with categories and sub-categories nested within.
        /// </returns>
        public async static Task<List<Product>> GetProductsAsync(String id)
        {            
            var productResponse = await HttpClientService.WalmartHttpClientService.Instance.GetProductsAsync(id);
            var listOfProducts = JsonConvert.DeserializeObject<RootObject>(productResponse).Items;
            return listOfProducts;
        }

        /// <summary>
        /// The root object of the Walmart API response.
        /// </summary>
        private class RootObject
        {
            [JsonProperty("items")]
            public List<Product> Items { get; set; }
        }


    }
}