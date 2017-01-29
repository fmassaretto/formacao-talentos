using Fatec.Treinamento.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fatec.Treinamento.Model
{
    public class Detalhe : DetalhesCurso
    {
        public int TotalCapitulos { get; set; }
        public int Pontos { get; set; }
    }
}
