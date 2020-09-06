using System.ComponentModel.DataAnnotations;

namespace MovieCollection.Web.Models.Account
{
    public class LoginViewModel
    {
        [Display(Name = "Имя пользователя")]
        [Required]
        public string Username { get; set; }
        
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        
        public string ReturnUrl { get; set; }
    }
}