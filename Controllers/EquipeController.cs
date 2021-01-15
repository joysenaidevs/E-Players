using System;
using System.IO;
using E_Players.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Players.Controllers
{
    //Herdar a classe controller
    //Classe que esta dentro de um biblioteca da Microsoft
    //nome da rota: http://localhost:5001/Equipe

    //ex: "Noticias" - ROTA DE NOTICIAS
    [Route("Equipe")] 
    //Rota especificada "Equipe"
    public class EquipeController : Controller  // utilizar metodos e propriedades
    {
        //Listagem
        //Conseguir acessar informações para guardar ou mostrar
        //Listamos todas as equipes
        //Acessar por todos os métodos - Instanciar Model da Equipe (equipeModel)
        Equipe equipeModel = new Equipe();

        [Route("Listar")]
        public IActionResult Index()
        {

            //Enviar informações como retorno da view, para acessar na página
            //instrução utlizada -> ViewBag
            //ViewBag -> Pacote com um conjunto de informações
            //Enviamos para ViewBag
            ViewBag.Equipes = equipeModel.ReadAll();
            
            //Tudo que for definido dentro desse método esta relacionado a página index

            //Metodo de ação - IActionResult, Codigo de status.
            return View();
        }

        //Cadastro
        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            //Recurso para fazer o cadastro
            //Envio de informações
            //Exemplificamos através de formularios
            //Recebemos as informações do formulario

            //CADASTRAR NOVA EQUIPE
            //Instancio novaEquipe baseado no modelo de Equipe
            Equipe novaEquipe   = new Equipe();
            novaEquipe.IdEquipe = Int32.Parse( form["IdEquipe"] ); // Armazemaos a informacao chegando do formulario
            novaEquipe.Nome     = form["Nome"];

            //UPLOAD INICIO

            //Verificamos se o usuario selecionou um arquivo
            if (form.Files.Count > 0)
            {
                //Recebemos o arquivo que o usuario enviou e armazenamos na variavel File
                var file        = form.Files[0];
                var folder      = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipes" );

                //Verificamos se o Diretorio (pasta) já existe, caso não, a criamos
                if (!Directory.Exists(folder) ) 
                {
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.Name );
                using( var stream = new FileStream(path, FileMode.Create) )
                {
                    file.CopyTo(stream);
                }

                novaEquipe.Imagem =  file.FileName;

            }
            else
            {
                novaEquipe.Imagem = "Padrão.pnj";
            }

            //UPLOAD FIM


            //Chamamos o método de Cadastro para salvar novaEquipe no CSV
            equipeModel.Create(novaEquipe);
            //Enviar através de uma ViewBag as novas informações - Atualiza lista de equipes
            ViewBag.Equipes = equipeModel.ReadAll();

            //Apontamos aonde queremos o rediricionamento
            //instrucao que indica RAIZ : "~/Equipe" -> Equipe é a rota
            return LocalRedirect("~/Equipe/Listar");
        
        }
        //http://localhost:5000/Equipe/1

        [Route("{id}")]
        public IActionResult Excluir(int id)
        {
            equipeModel.Delete(id);
            ViewBag.Equipes = equipeModel.ReadAll();
            return LocalRedirect("~/Equipe/Listar");
        }
        
    }
}