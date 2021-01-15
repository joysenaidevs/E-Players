using System;
using E_Players.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Players.Controllers
{
    [Route("Jogador")]
    public class JogadorController : Controller
    {

        //Instanciar Jogador
        Jogador jogadorModel = new Jogador();
       public IActionResult Index()
       {
           ViewBag.Jogadores = jogadorModel.ReadAll();
           return View();
       }

       public IActionResult Cadastrar(IFormCollection form)
       {
           Jogador novoJogador = new Jogador();
           novoJogador.IdJogador        =Int32.Parse(form["IdJogador"] );
           novoJogador.Nome             =form["Nome"];
           novoJogador.Email            =form["Email"];
           novoJogador.Senha            =form["Senha"];

           jogadorModel.Create(novoJogador);
           ViewBag.Jogadores = jogadorModel.ReadAll();

           return LocalRedirect("~/Jogador");
       }



       

    }
}