using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using E_PlayersProjeto.Models;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace E_PlayersProjeto.Controllers
{
    public class NoticiasController : Controller
    {

       Noticias noticiasModel = new Noticias();

       /// <summary>
       /// Aponta para a Index da minha View
       /// </summary>
       /// <returns>a própria View da Index</returns>
       public IActionResult Index()
        {
            ViewBag.Noticias = noticiasModel.ReadAll();
            return View();
        }

        /// <summary>
        ///  Cadastra uma nova equipe
        /// </summary>
        /// <param name="form">Dados do formulario</param>
        /// <returns>Redireciona para a mesma página </returns>
        public IActionResult Cadastrar(IFormCollection form)
        {
            Noticias noticias   = new Noticias();
            noticias.IdNoticia  = Int32.Parse(form["IdNoticia"]);
            noticias.Titulo     = form["Titulo"];
            noticias.Texto      = form["Texto"];

            // Upload da imagem
             var file    = form.Files[0];
             var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Noticias");

            //pastaA , pastaB , pastaC , arquivo.pdf

            if(file != null)
            {
                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }

                //wwwroot/img/Equipe/arquivo.pdf
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))  
                {  
                    file.CopyTo(stream);  
                }
                noticias.Imagem   = file.FileName;
            }
            else
            {
                noticias.Imagem   = "padrao.png";
            }
            // Fim - Upload Imagem

            noticiasModel.Create(noticias);

            return LocalRedirect("~/Noticias");
        }
         
        [Route("[controller]/{id}")]
        public IActionResult Excluir(int id)
        {
         noticiasModel.Delete(id);
         return LocalRedirect("~/Noticias");
        }


    }
}
