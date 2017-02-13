using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fatec.Treinamento.Model
{
    public class TreinamentoCurso
    {
        public int Id { get; set; }

        public int IdUsuario { get; set; }

        public int IdCurso { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime UltimoAcesso { get; set; }

        public DateTime DataConclusao { get; set; }
    }
}
