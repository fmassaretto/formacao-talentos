using Fatec.Treinamento.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fatec.Treinamento.Web.Models
{
    public class CursoAssuntoUsuarioViewModel
    {
        public AssuntoCursoUsuario Curso { get; set; }

        public IList<SelectListItem> ListaUsuarios { get; set; }

        public IList<SelectListItem> ListaAssuntos { get; set; }

        public CursoAssuntoUsuarioViewModel()
        {
            ListaAssuntos = new List<SelectListItem>();
            ListaUsuarios = new List<SelectListItem>();

        }
    }
}