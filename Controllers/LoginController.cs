using E_Players.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Players.Controllers
{
    [Route("Login")]
    public class LoginController : Controller
    {
        Jogador jogadorModel = new Jogador();

        public IActionResult Index()
        {
            return View();
        }
    }
}