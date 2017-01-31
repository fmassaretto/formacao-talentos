using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fatec.Treinamento.Model.DTO
{
    public class AssuntoCursoUsuario
    {

        public int Id { get; set; }
        public int IdAutor { get; set; }
        public int IdAssunto { get; set; }

        [DisplayName("Curso")]
        public string Nome { get; set; }

        [DisplayName("Assunto")]
        public string NomeAssunto { get; set; }

        [DisplayName("Autor")]
        public string NomeAutor { get; set; }

        [DisplayName("Data da Criação")]
        public DateTime DataCriacao { get; set; }

        [DisplayName("Classificação")]
        public int Classificacao { get; set; }
    }
}
