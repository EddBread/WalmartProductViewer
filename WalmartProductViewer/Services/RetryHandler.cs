using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WalmartProductViewer.Services
{
    /// <summary>
    /// Handles the retries on status code 5xx for the WalmartHttpClientService
    /// </summary>
    public class RetryHandler : DelegatingHandler
    {

        private const int _maxRetries = 7;

        public RetryHandler(HttpMessageHandler innerHandler) : base(innerHandler) { }
        /// <summary>
        /// Does not retry on successful status code or 4xx.
        /// </summary>
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            HttpResponseMessage response = null;

            response = null;
            
            for (int i = 0; i < _maxRetries; i++)
            {
                response = await base.SendAsync(request, cancellationToken);
                
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }
                else if (IsClientError(response.StatusCode))
                {
                    throw new HttpRequestException(String.Format("HTTP STATUS CODE:{0} {1}", response?.StatusCode, response?.ReasonPhrase));
                }
                else if (IsServerError(response.StatusCode))
                {
                    continue;
                }
                await Task.Delay(3000);
            }

            throw new HttpRequestException(String.Format("HTTP STATUS CODE:{0} {1}", response?.StatusCode, response?.ReasonPhrase));

        }
        /// <summary>
        /// Helper function to check if response is client error.
        /// </summary>
        private Boolean IsClientError(HttpStatusCode statusCode)
        {
            return 399 < (int)statusCode && (int)statusCode < 500;
        }
        /// <summary>
        /// Helper function to check if response is server error.
        /// </summary>
        private Boolean IsServerError(HttpStatusCode statusCode)
        {
            return 499 < (int)statusCode && (int)statusCode < 600;
        }

    }
}