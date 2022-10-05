using AspNetCoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetCoreApp.ViewComponents{
  //[HtmlTargetElement("paragraph")]
  public class News : ViewComponent{
    public IViewComponentResult Invoke(string color="default")
    {
      var list = NewsContext.List;
      if(color == "default")
        return View(list);
      else if(color =="red")
        return View("red", list);
      else
        return View("blue", list); 
    }
  }
}