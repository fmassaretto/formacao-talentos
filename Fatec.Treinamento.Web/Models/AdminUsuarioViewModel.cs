using Fatec.Treinamento.Model;
using Fatec.Treinamento.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fatec.Treinamento.Web.Models
{
    public class AdminUsuarioViewModel
    {
        public Usuario Usuario { get; set; }
        public IEnumerable<SelectListItem> ListaPerfil { get; set; }
    }
}