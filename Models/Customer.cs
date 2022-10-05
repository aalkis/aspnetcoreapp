using System.ComponentModel.DataAnnotations;

namespace AspNetCoreApp.Models
{
  public class Customer
  {
    [Required(ErrorMessage ="Id is required!")]
    public int Id { get; set; }
    [Required(ErrorMessage ="Please enter your first name")]
    [MaxLength(30, ErrorMessage ="First name can be maximum of 30")]
    [MinLength(2, ErrorMessage ="First name can be minimum of 2")]
    public string? FirstName { get; set; }

    [MaxLength(30, ErrorMessage ="Last name can be maximum of 30")]
    [MinLength(2, ErrorMessage ="Last name can be minimum of 2")]
    [Required(ErrorMessage ="Please enter your last name")]
    public string? LastName { get; set; }

    [Required(ErrorMessage ="Please enter your age")]
    [Range(18, Double.PositiveInfinity, ErrorMessage ="You need to be abow 18.")]
    public int Age { get; set; }
  }  
}