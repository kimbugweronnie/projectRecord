using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Project;
using Project.Controllers;
using Project.Models
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Project.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            public void TestDetailsView()
          {
               var controller = new HomeController();
               var result = controller.list()  as ViewResult;
               Assert.AreEqual("collection", result);

          }
     }
     
          [TestMethod]
          public void TestDetailsRedirect()
          {
               var controller = new HomeController();
               var result = (RedirectToRouteResult) controller.Index()
               Assert.AreEqual("projects", result.Values["action"]);

          }
     }
}

            