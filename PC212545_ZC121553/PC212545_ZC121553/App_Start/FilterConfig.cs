using System.Web;
using System.Web.Mvc;

namespace PC212545_ZC121553
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
