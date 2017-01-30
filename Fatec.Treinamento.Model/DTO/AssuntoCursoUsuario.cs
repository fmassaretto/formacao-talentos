using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fatec.Treinamento.Model.DTO
{
    public class AssuntoCursoUsuario
    {

        public int IdCurso { get; set; }
        public int IdAutor { get; set; }
        public int IdAssunto { get; set; }

        public string NomeCurso { get; set; }
        public string NomeAssunto { get; set; }
        public string NomeAutor { get; set; }

        public string Assunto { get; set; }

        public DateTime DataCriacao { get; set; }

        public int Classificacao { get; set; }
    }
}
