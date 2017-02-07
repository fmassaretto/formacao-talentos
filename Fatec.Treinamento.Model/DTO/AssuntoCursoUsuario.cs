using System;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fatec.Treinamento.Model.DTO
{
    public class AssuntoCursoUsuario
    {

        public int IdCurso { get; set; } //editado ante era Id
        public int IdAutor { get; set; }
        public int IdAssunto { get; set; }
        public int IdCursoDescricao { get; set; }

        public Usuario usuario { get; set; }

        public int UsuarioSelecionado { get; set; }
        public int AssuntoSelecionado { get; set; }

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

        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        public string Nivel { get; set; }

        public IList<Capitulo> Pontos { get; set; }

        public int TotalPontos {
            get
            {
                int somaPontos = 0;
                somaPontos = Pontos.Sum(ponto => ponto.Pontos);
                return somaPontos;
            }
        }

        public IList<Capitulo> Capitulos { get; set; }

        public int TotalCapitulos
        {
            get
            {
                int somaCap = 0;
                if (Capitulos != null)
                {
                    somaCap = Capitulos.Sum(x => x.QtdeCapitulos);
                }
                return somaCap;
            }
        }

        public AssuntoCursoUsuario()
        {
            Capitulos = new List<Capitulo>();
            Pontos = new List<Capitulo>();
        }

    }
}
