using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoCompleteInMVCJson.Controllers
{
    enum SearchEngineName
    {
        Google,
        Bing
    }
    
    // Factory class between client and business layer
    // For any new search engine simply create new concreate class and create object in below class
    class SearchEngineFactory
    {
       static public ISearchResult GetSearchResult(string SearchEngine)
        {
            if (SearchEngine == SearchEngineName.Google.ToString())
            {
                return new GoogleResult();
            }
            else if (SearchEngine == SearchEngineName.Bing.ToString())
            {
                return new BingResult();
            }
            else
            {
                return null;
            }
        }
    }
    // concreate business class
    public class GoogleResult : ISearchResult
    {
        public int getPosition(string Keyword, String SiteUrl, String SearchEngine)
        {
            int position = 0;
            switch (Keyword)
            {
                case "Online Title Search":
                    position = 1;
                    break;
                case "Title Search Sydney":
                    position = 3;
                    break;
                case "InfoTrack Title Search":
                    position = 1;
                    break;
                case "Property Search":
                    position = 3;
                    break;
                case "InfoTrack":
                    position = 1;
                    break;
                case "Company Search":
                    position = 7;
                    break;
                default:
                    position = 0;
                    break;

            }
            return position;
        }

    }
    // concreate business class
    public class BingResult : ISearchResult
    {
        public int getPosition(string Keyword, String SiteUrl, String SearchEngine)
        {
            int position = 0;
            switch (Keyword)
            {
                case "Online Title Search":
                    position = 1;
                    break;
                case "Title Search Sydney":
                    position = 20;
                    break;
                case "InfoTrack Title Search":
                    position = 3;
                    break;
                case "Property Search":
                    position = 37;
                    break;
                case "InfoTrack":
                    position = 1;
                    break;
                case "Company Search":
                    position = 24;
                    break;
                default:
                    position = 0;
                    break;

            }
            return position;
        }

    }
}