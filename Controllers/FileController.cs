using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreApp.Controllers
{
  public class FileController : Controller
  {
   public IActionResult List(){
    DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(),"wwwroot", "files"));

    var files = directoryInfo.GetFiles();
    return View(files);
   }
   public IActionResult Create(){
    return View();
   }
   [HttpPost]
   public IActionResult Create(string fileName){
    FileInfo fileInfo = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", fileName));
    if(!fileInfo.Exists)
      fileInfo.Create();
    return RedirectToAction("List");
   }
    public IActionResult CreateWithData(){

      FileInfo fileInfo = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", Guid.NewGuid().ToString()+".txt"));
      
      StreamWriter writer= fileInfo.CreateText();
      writer.Write("Merhaba Ben Alper");
      writer.Close();

      return RedirectToAction("List");
    }
    public IActionResult Remove(string fileName){
      FileInfo fileInfo = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", fileName));
      if(fileInfo.Exists)
        fileInfo.Delete();
      return RedirectToAction("List");
    }

    public IActionResult Upload(){
      return View();
    }
    [HttpPost]
    public IActionResult Upload(IFormFile formFile){
      if(formFile.ContentType == "image/png")
      {
        var ext = Path.GetExtension(formFile.FileName);
      var path = Directory.GetCurrentDirectory()+"/wwwroot"+"/uploads/"+Guid.NewGuid()+ext;
      FileStream stream= new FileStream(path, FileMode.Create);
      formFile.CopyTo(stream);
        TempData["message"]="File uploaded successfully";
      }
      else{
        TempData["message"]="File is not PNG";
      }

      return RedirectToAction("Upload");
    }


  }
}