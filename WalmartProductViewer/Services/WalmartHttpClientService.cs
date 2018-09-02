using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Threading;
using WalmartProductViewer.Services;

namespace WalmartProductViewer.HttpClientService
{
    /// <summary>
    /// The main service class that GETs the WalmartAPI
    /// </summary>
    /// <remarks> Singleton class for HttpClient to prevent SocketExceptions. </remarks>    
    public sealed class WalmartHttpClientService
    {
        
        private const String _apiKey = "56yv952pzdymq2v5ckcrzzd8";
        private const String _apiBaseAddress = "http://api.walmartlabs.com/v1/";


        private static HttpClient _client;
        private static readonly WalmartHttpClientService instance = new WalmartHttpClientService();
        static WalmartHttpClientService() { }
        internal static WalmartHttpClientService Instance { get { return instance; } }

        /// <summary>
        /// The singleton constructor initialized with RetryHandler to handle HTTP 5xx Status Codes 
        /// </summary>
        private WalmartHttpClientService()
        {
            _client = new HttpClient(new RetryHandler(new HttpClientHandler()));
            _client.Timeout = TimeSpan.FromSeconds(15);
            _client.BaseAddress = new Uri(_apiBaseAddress);                        
        }

        /// <summary>
        /// GETs categories from Walmart Taxonomy API.
        /// </summary>
        /// <returns> Stringified JSON response of categories </returns>
        internal async Task<String> GetCategoriesAsync()
        {
            var categoryPath = String.Format("taxonomy?format=json&apiKey={0}", _apiKey);
            var response = await _client.GetAsync(categoryPath).ConfigureAwait(false);
            var stringifiedResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return stringifiedResponse;
        }

        /// <summary>
        /// GETs categories from Walmart Paginated API.
        /// </summary>
        /// <returns> Stringified JSON response of products </returns>
        internal async Task<String> GetProductsAsync(String id)
        {            
            var productPath = String.Format("paginated/items?category={1}&apiKey={0}&format=json", _apiKey, id);
            var response = await _client.GetAsync(productPath).ConfigureAwait(false);
            var stringifiedResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return stringifiedResponse;
        }        
    }
}
