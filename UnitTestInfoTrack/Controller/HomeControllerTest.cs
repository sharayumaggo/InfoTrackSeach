using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoCompleteInMVCJson;
using AutoCompleteInMVCJson.Controllers;
using System.Web.Mvc;

namespace UnitTestInfoTrack.Controller
{
    // Below are some sample testcases which are written for Unit Teating
    [TestClass]
    public class HomeControllerTest
    {
        //Arrange
        HomeController homeController = new HomeController();

        [TestMethod]
        public void Test_IndexMethod()
        {
            //Act
            ViewResult result = homeController.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Test_JsonResult_Index()
        {
            //Act
            string Prefix = "Online Title Search";
            JsonResult result = homeController.Index(Prefix) as JsonResult;
            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Test_JsonResult_SearchResult()
        {
            //Act
            string Keyword = "Title Search";
            string SiteUrl = "https://www.infotrack.com.au/";
            string SearchEngine = "Google";

            JsonResult result = homeController.SearchResult(Keyword, SiteUrl, SearchEngine) as JsonResult;
            //Assert
            Assert.IsNotNull(result);
        }

    }
}
