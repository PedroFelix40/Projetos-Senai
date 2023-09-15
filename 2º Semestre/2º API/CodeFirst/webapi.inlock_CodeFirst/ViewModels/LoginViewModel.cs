﻿using System.ComponentModel.DataAnnotations;

namespace webapi.inlock_CodeFirst.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O email é obrigatório!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória!")]
        public string Senha { get; set; }
    }
}
