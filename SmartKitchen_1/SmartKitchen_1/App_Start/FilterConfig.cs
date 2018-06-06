using System.Web;
using System.Web.Mvc;

namespace SmartKitchen_1Db
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
