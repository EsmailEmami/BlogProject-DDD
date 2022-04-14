using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Blog.Application.ViewModels.User;

public class UserViewModel
{
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "The Firstname is Required")]
    [MinLength(3)]
    [MaxLength(50)]
    [DisplayName("Firstname")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "The LastName is Required")]
    [MinLength(3)]
    [MaxLength(50)]
    [DisplayName("LastName")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "The Email is Required")]
    [EmailAddress(ErrorMessage = "Please enter your correct email")]
    [MaxLength(100)]
    [DisplayName("Email")]
    public string Email { get; set; }
}