using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sistema.Contexts;
using sistema.Models;

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
            var turma = _context.Turmas.FirstOrDefault(t => t.TurmaId == turmaId);
            var atividades = _context.Atividades.Where(t => t.TurmaId == turmaId).ToList();
            ViewBag.TurmaNome = turma!.Nome;
            ViewBag.NomeProfessor = professor!.Nome;
            ViewBag.TurmaId = turma.TurmaId;

            return View(atividades);
        }

        [HttpPost]
        public IActionResult CadastrarAtividades(string nomeAtividade, int turmaId)
        {
            var atividade = new Atividade
            {
                Descricao = nomeAtividade,
                TurmaId = turmaId,
            };

            _context.Atividades.Add(atividade);
            _context.SaveChanges();

            return RedirectToAction("Index", new {turmaId});
        }
    }
}
