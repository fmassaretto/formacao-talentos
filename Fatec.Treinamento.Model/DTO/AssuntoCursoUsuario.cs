using System;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using Fatec.Treinamento.Model.Extensoes;
using Fatec.Treinamento.Model.Enum;

namespace Fatec.Treinamento.Model.DTO
{
    public class AssuntoCursoUsuario 
    {

        public int IdCurso { get; set; } //editado antes era Id
        public int IdAutor { get; set; }
        public int IdAssunto { get; set; }
        public int IdCursoDescricao { get; set; }

        public IList<Usuario> Usuario { get; set; }
        public int IdUsuario { get; set; }

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

        public string SelectedNota { get; set; }

        public string Img { get; set; }

        public IList<Capitulo> Capitulos { get; set; }

        public IEnumerable<int> PontosUsuario { get; set; }

        public IList<Capitulo> Pontos { get; set; }

        public IList<int> QtdUsuariosVotosCurso { get; set; }

        public int TotalDuracaoCurso { get; set; }

        public string TotalDuracaoCursoFormatado
        {
            get
            {
                TimeSpan time = TimeSpan.FromSeconds(TotalDuracaoCurso);
                return time.ToString(@"hh\:mm\:ss");
            }
        }

        public int TotalPontos {
            get
            {
                int somaPontos = 0;
                somaPontos = Pontos.Sum(ponto => ponto.Pontos);
                return somaPontos;
            }
        }

        public AssuntoCursoUsuario()
        {
            Capitulos = new List<Capitulo>();
            Pontos = new List<Capitulo>();
            QtdUsuariosVotosCurso = new List<int>();
            Usuario = new List<Usuario>();
        }

    }
}
