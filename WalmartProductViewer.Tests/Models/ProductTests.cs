using Microsoft.VisualStudio.TestTools.UnitTesting;
using WalmartProductViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalmartProductViewer.Models.Tests
{
    [TestClass()]
    public class ProductTests
    {
        [TestMethod()]
        public void GetProductsAsyncTest()
        {
            var result = Product.GetProductsAsync("1334134").Result;
            Assert.AreEqual(result.GetType(), new List<Product>().GetType());
        }
    }
}