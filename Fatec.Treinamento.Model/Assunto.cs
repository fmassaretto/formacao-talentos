using Fatec.Treinamento.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fatec.Treinamento.Model
{
    public class Assunto : AssuntoCursoUsuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }

    }
}
