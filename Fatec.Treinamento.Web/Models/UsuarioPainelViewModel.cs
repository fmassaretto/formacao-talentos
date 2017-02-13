using Fatec.Treinamento.Model;
using Fatec.Treinamento.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fatec.Treinamento.Web.Models
{
    public class UsuarioPainelViewModel
    {
        public IEnumerable<AssuntoCursoUsuario> Acu { get; set; }
        public int PontosUsuario { get; set; }
        public IEnumerable<TreinamentoCurso> CursosFinalizado { get; set; }
        public IEnumerable<TreinamentoCurso> CursosAndamento { get; set; }
        public IEnumerable<TreinamentoCurso> CursosFavoritos { get; set; }
    }
}