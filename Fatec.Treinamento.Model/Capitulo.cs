using Fatec.Treinamento.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fatec.Treinamento.Model
{
    public class Capitulo
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int Pontos { get; set; }

        public IEnumerable<Video> Videos { get; set; }

        public string TempoTotal {
            get
            {
                int somaVideos = 0;
                if (Videos != null)
                {
                    somaVideos = Videos.Sum(video => video.Duracao);
                }

                TimeSpan time = TimeSpan.FromSeconds(somaVideos);
                return time.ToString(@"hh\:mm\:ss");
            }
        }

    }
}
