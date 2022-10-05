using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreApp.Areas.Member
{
  [Area("Member")]
  public class HomeController : Controller
  {
    public IActionResult Index(){
      return View();
    }
  }
}