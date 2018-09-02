using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WalmartProductViewer.Models
{
    /// <summary>
    /// The category data model 
    /// </summary>
    /// <remarks> All business logic involving category goes here.</remarks>
    public class Category
    {
        [JsonProperty("id"), JsonRequired()]
        public String ID { get; set; }
        [JsonProperty("name"), JsonRequired()]
        public String Name { get; set; }
        [JsonProperty("children")]
        public List<Category> Children { get; set; }

        /// <summary>
        /// Uses the WalmartHttpClientService to query the Walmart Taxonomy API and deserializes response into list of category.
        /// </summary>
        /// <returns>
        /// A list of all the departments with categories and sub-categories nested within.
        /// </returns>
        public async static Task<List<Category>> GetCategoriesAsync()
        {   
            var categoryResponse = await HttpClientService.WalmartHttpClientService.Instance.GetCategoriesAsync();
            var listOfCategory = JsonConvert.DeserializeObject<RootObject>(categoryResponse).Categories;
            return listOfCategory;
        }

        /// <summary>
        /// The root object of the Walmart API response.
        /// </summary>
        private class RootObject
        {
            [JsonProperty("categories")]
            public List<Category> Categories { get; set; }
        }
    }
}