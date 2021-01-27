using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoCompleteInMVCJson.Models;
using System;
namespace AutoCompleteInMVCJson.Controllers
{
    public class HomeController : Controller
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Index(string Prefix)
        {
            try
            {
                log.Info("entering application, fetch list!");

                //Note : you can bind same list from database
                List<KeywordModel> ObjList = new List<KeywordModel>()
            {

                new KeywordModel {Id=1,Keyword="Online Title Search" },
                new KeywordModel {Id=2,Keyword="Title Search Sydney" },
                new KeywordModel {Id=3,Keyword="InfoTrack Title Search" },
                new KeywordModel {Id=4,Keyword="Property Search" },
                new KeywordModel {Id=5,Keyword="InfoTrack" },
                new KeywordModel {Id=6,Keyword="Company Search" }

        };
                //Searching records from list using LINQ query
                var KeywordName = (from N in ObjList
                                   where N.Keyword.StartsWith(Prefix, System.StringComparison.InvariantCultureIgnoreCase)
                                   select new { N.Keyword });
                return Json(KeywordName, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Info(ex);

                return null;
            }
        }

        [HttpPost]
        public JsonResult SearchResult(string Keyword, string SiteUrl, string SearchEngine)
        {
            try
            {
                log.Info("entering application, Search Result!");
                // Client Side
                // Here simple factory patern is implemented. 
                // based on searchEngine respective object will be created at single place and 
                // respective concrete class method will be called

                ISearchResult searchResult = null;
                searchResult = SearchEngineFactory.GetSearchResult(SearchEngine);

                int position = 0;
                position = searchResult.getPosition(Keyword, SiteUrl, SearchEngine);

                return Json(position, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Info(ex);
                return null;
            }
        }
    }
}