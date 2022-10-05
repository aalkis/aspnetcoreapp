using AspNetCoreApp.Models;

namespace AspNetCoreApp
{
  public static class CustomerContext
  {
    public static List<Customer> Customers = new()
    {
      new Customer{ Id=1, FirstName="Yavuz", LastName="Kahraman", Age=27},
      new Customer{ Id=2, FirstName="Oguz", LastName="Kahraman", Age=26},
      new Customer{ Id=3, FirstName="Alper", LastName="Alkis", Age=30},
    };
  }
}