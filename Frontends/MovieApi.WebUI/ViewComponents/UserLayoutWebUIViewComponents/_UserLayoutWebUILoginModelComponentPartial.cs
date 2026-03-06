using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.ViewComponents.UserLayoutWebUIViewComponents
{
	public class _UserLayoutWebUILoginModelComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}

	}
}
