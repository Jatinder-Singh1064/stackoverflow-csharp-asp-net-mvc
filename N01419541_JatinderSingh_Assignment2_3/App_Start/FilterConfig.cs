using System.Web;
using System.Web.Mvc;

namespace N01419541_JatinderSingh_Assignment2_3
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
