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
    public class CategoryTests
    {
        [TestMethod()]
        public void GetCategoriesAsyncListTypeTest()
        {
            var result = Category.GetCategoriesAsync().Result;
            Assert.AreEqual(result.GetType(), new List<Category>().GetType());            
        }       
    }
}