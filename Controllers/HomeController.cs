using AspNetCoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreApp.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet]
    public IActionResult Index(){

      var customers = CustomerContext.Customers;
      return View(customers);
    }
    [HttpGet]
    public IActionResult Create(){
      return View(new Customer());
    }
    [HttpPost]

    public IActionResult Create(Customer customer){
      ModelState.Remove("Id");
      if(ModelState.IsValid){
      if (CustomerContext.Customers.Count > 0){
        var lastCustomer = CustomerContext.Customers.Last();
        customer.Id = lastCustomer.Id + 1;
      } else
        customer.Id = 1; 
      CustomerContext.Customers.Add(customer);
      return RedirectToAction("Index");
      }
      return View();
    }


    [HttpGet]
    public IActionResult Remove(int id){
      //var id = int.Parse(RouteData.Values["id"].ToString());
      var removedcustomer = CustomerContext.Customers.Find(a=> a.Id==id);
      CustomerContext.Customers.Remove(removedcustomer);
      return RedirectToAction("index");
    }
    [HttpGet]
    public IActionResult Update(int id){
      //var id = int.Parse(RouteData.Values["id"].ToString());
      var updatedCustomer = CustomerContext.Customers.FirstOrDefault(a=> a.Id == id);

      return View(updatedCustomer);
    }
    [HttpPost]
    public IActionResult Update(Customer customer){
      
      var updatedCustomer = CustomerContext.Customers.FirstOrDefault(a=> a.Id == customer.Id);
      updatedCustomer.FirstName = customer.FirstName;
      updatedCustomer.LastName = customer.LastName;
      updatedCustomer.Age = customer.Age;

      return RedirectToAction("index");
    }
  }
}