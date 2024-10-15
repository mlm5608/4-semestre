using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sistema.Contexts;

namespace sistema.Controllers
{
    public class AtividadeController : Controller
    {
        private readonly SistemaContext _context;
        public AtividadeController()
        {
            _context = new SistemaContext();
        }

        public IActionResult Index()
        {
            int? professorId = HttpContext.Session.GetInt32("ProfessorId");
            var turmaIdS = HttpContext.Request.Query["turmaId"].ToString();
            if (professorId == null)
            {
                return RedirectToAction("Index", "Login");
            }
            int turmaId = int.Parse(turmaIdS);
            var professor = _context.Professors.Find(professorId);
            var turma = _context.Turmas.Find(turmaId);
            ViewBag.NomeTurma = turma.Nome;
            ViewBag.NomeProfessor = professor!.Nome;

            return View();
        }
    }
}
