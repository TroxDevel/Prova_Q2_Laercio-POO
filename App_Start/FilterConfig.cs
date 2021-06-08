using System.Web;
using System.Web.Mvc;

namespace Prova_Q2_Laercio_POO
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
