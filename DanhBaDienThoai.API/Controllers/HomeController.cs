using System.Web.Mvc;

namespace DanhBaDienThoai.API.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Title = "Danh bạ điện thoại";

			return View();
		}
	}
}
