using System.Web;
using System.Web.Mvc;

namespace Authenecation_and_authoraization
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
