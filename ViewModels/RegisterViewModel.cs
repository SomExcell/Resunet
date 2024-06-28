using System;
using System.ComponentModel.DataAnnotations;
namespace Resunet.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Email обязательное поле")]
        [EmailAddress(ErrorMessage ="Некорректный формат")]
        public string? Email { get; set; }
        [Required(ErrorMessage ="Пароль обязательное поле")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[!@#$%^&*-]).{10,}$",
            ErrorMessage ="Пароль слишком простой")]
        public string? Password { get; set; }
    }
}

