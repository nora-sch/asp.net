using System.Web;
using System.Web.Mvc;

namespace TP_mod5_PIZZAS
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
