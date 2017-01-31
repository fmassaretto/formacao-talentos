using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fatec.Treinamento.Model
{
    public class Perfil
    {
        [DisplayName("Perfil")]
        public int Id { get; set; }

        public string Nome { get; set; }
    }
}
