using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fatec.Treinamento.Model.Extensoes
{
    public class Youtube
    {
        public string RecuperarThumb(string codigoVideo)
        {
            return string.Format("http://img.youtube.com/vi/{0}/default.jpg", codigoVideo);
        }
    }
}
