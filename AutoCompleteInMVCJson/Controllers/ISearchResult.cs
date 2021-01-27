using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCompleteInMVCJson.Controllers
{
    interface ISearchResult
    {

        int getPosition(string Keyword, String SiteUrl, String SearchEngine);
    }
}
