using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WalmartProductViewer.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTest
    {
        [TestMethod()]
        public void IndexIsNotNull()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Index().Result as ViewResult;
            Assert.IsNotNull(result);           
        }

        [TestMethod()]
        public void IndexModelTypeIsList()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Index().Result as ViewResult;
            Type modelType = result.Model.GetType();
            Type listCategory = new List<Models.Category>().GetType();
            Assert.AreEqual(modelType, listCategory);
        }


        [TestMethod()]
        public void ProductsIsNotNull()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Products("Test").Result as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void ProductsModelIsList()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Products("1334134").Result as ViewResult;
            Type modelType = result.Model.GetType();
            Type listProduct = new List<Models.Product>().GetType();
            Assert.AreEqual(modelType, listProduct);
        }




        [TestMethod()]
        public void ProductDetailIsNotNull()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.ProductDetail(new Models.Product()) as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}

