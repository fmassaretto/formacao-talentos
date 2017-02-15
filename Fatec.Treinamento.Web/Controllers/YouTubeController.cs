using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fatec.Treinamento.Web.Controllers
{
    public class YouTubeController : Controller
    {
        // GET: YouTube
        public ActionResult Index()
        {
            return View();
        }

        // Teste não implementado
        public string RecuperarThumb(string codigoVideo)
        {
            //string[] result = enderecoVideo.Split('=');
            //string codEmbed = result[1];
            //return string.Format("http://img.youtube.com/vi/{0}/default.jpg", codEmbed);
            return string.Format("http://img.youtube.com/vi/{0}/default.jpg", codigoVideo);
        }

        private string RecuperarEmbedVideo(string enderecoVideo)
        {
            string[] result = enderecoVideo.Split('=');
            return result[1];
        }
    }
}