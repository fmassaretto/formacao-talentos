using Fatec.Treinamento.Model;
using Fatec.Treinamento.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fatec.Treinamento.Web.Models
{
    public class AdminCursoViewModel
    {
        public AssuntoCursoUsuario Acu { get; set; }
        public IEnumerable<SelectListItem> ListaUsuarios { get; set; }
        public IEnumerable<SelectListItem> ListaAssunto { get; set; }

        public HttpPostedFileBase Img { get; set; }

        public IList<SelectListItem> Niveis { get; set; }

        public AdminCursoViewModel()
        {
            var data = new[]{
                 new SelectListItem{ Value="Iniciante",Text="Iniciante"},
                 new SelectListItem{ Value="Intermediário",Text="Intermediário"},
                 new SelectListItem{ Value="Avançado",Text="Avançado"}
             };

            Niveis = data.ToList();
        }

        //public List<HttpPostedFileBase> Files { get; set; }

        //public AdminCursoViewModel(){
        //    Files = new List<HttpPostedFileBase>();    
        //}

    }
}