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
        public IList<int> CursosFinalizado { get; set; }
        public IList<int> CursosAndamento { get; set; }
        public IList<int> CursosFavoritos { get; set; }

        public UsuarioPainelViewModel()
        {
            CursosFinalizado = new List<int>();
            CursosAndamento = new List<int>();
            CursosFavoritos = new List<int>();
        }
    }
}