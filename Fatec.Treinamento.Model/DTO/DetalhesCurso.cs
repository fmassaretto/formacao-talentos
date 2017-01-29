using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fatec.Treinamento.Model.DTO
{
    public class DetalhesCurso
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Assunto { get; set; }

        public string Autor { get; set; }

        public DateTime DataCriacao { get; set; }

        public int Classificacao { get; set; }

        //public string Descricao { get; set; }

    }
}
