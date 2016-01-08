using System;
using System.ComponentModel.DataAnnotations;

namespace DVA231_Projekt.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
