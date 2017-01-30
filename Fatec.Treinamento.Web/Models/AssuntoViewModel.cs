using Fatec.Treinamento.Model;
using Fatec.Treinamento.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fatec.Treinamento.Web.Models
{
    public class AssuntoViewModel
    {
        public IEnumerable<Assunto> Assunto { get; set; }
        public Assunto Obter { get; set; }
    }
}