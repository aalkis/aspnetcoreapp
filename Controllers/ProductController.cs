using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreApp.Controllers
{
  public class ProductController : Controller
  {
    public IActionResult Index(){

      return View();
    }
  }
}