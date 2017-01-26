using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fatec.Treinamento.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Preencha o email")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha a senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Display(Name = "Manter conectado?")]
        public bool ManterConectado { get; set; }
    }
}