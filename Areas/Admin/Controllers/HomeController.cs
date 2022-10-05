using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreApp.Areas.Admin
{
  [Area("Admin")]
  public class HomeController : Controller
  {
    public IActionResult Index(){
      return View();
    }
  }
}