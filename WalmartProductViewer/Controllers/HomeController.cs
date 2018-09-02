using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WalmartProductViewer.Models;
using System.Web.UI;
using System.Net.Http;

namespace WalmartProductViewer.Controllers
{

    /// <summary>
    /// The main controller class containing all the Actions.
    /// </summary>
    /// <remarks> Pass model objects to view for better compile-time checking and keep methods async to prevent deadlock. See: http://blog.stephencleary.com/2012/07/dont-block-on-async-code.html </remarks>
    public class HomeController : Controller
    {
        /// <summary>
        /// Action to categories page.
        /// </summary>
        /// <returns> The index page with all the departments and categories. </returns>
        /// <remarks>Cached for performance improvement. Can check cache settings in Web.config</remarks>        
        [HttpGet]
        [OutputCache(CacheProfile = "CacheFor100Seconds")]
        public async Task<ActionResult> Index()
        {
            var listOfCategory = await Category.GetCategoriesAsync();
            return View(listOfCategory);
        }

        /// <summary>
        /// Action to products page.
        /// </summary>
        /// <param name="id">A category ID</param>
        /// <returns> The products page for a category </returns>
        /// <remarks>Cached for performance improvement. Can check cache settings in Web.config</remarks>     
        [HttpGet]
        [OutputCache(CacheProfile = "CacheFor100Seconds")]
        public async Task<ActionResult> Products(String id)
        {
            var listOfProducts = await Product.GetProductsAsync(id);
            return View(listOfProducts);
        }

        /// <summary>
        /// Action to product details page.
        /// </summary>
        /// <param name="product">A product object</param>
        /// <returns> The product detail page for a specific product </returns>
        [HttpGet]
        public ActionResult ProductDetail(Product product)
        {
            return View(product);
        }
    }
}