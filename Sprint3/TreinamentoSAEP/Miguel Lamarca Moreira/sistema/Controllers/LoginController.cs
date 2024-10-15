using Microsoft.AspNetCore.Mvc;
using sistema.Contexts;

namespace sistema.Controllers
{
    public class LoginController : Controller
    {
        private readonly SistemaContext _contx;
        public LoginController(SistemaContext contx)
        {
           _contx = contx;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string email, string senha)
        {
            var professor = _contx.Professors.FirstOrDefault(p => p.Email == email && p.Senha == senha);
            if (professor != null)
            {
                HttpContext.Session.SetInt32("ProfessorId", professor.ProfessorId);
                HttpContext.Session.SetString("Nome", professor.Nome!);

                return RedirectToAction("Index", "Professor");
            }
            TempData["Mensagem"] = "Email ou senha incorreto";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index");
        }
    }
}
