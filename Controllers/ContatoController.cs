using CRUDContatos.Data;
using CRUDContatos.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContatoController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Busca a view da index e os dados na tabela contato
        /// </summary>
        /// <returns>Retorna a view da index</returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.Contato.ToList());
        }

        /// <summary>
        /// Busca os registros de acordo com o filtro
        /// </summary>
        /// <returns>Retorna os registros em json</returns>
        [HttpGet]
        public IActionResult Listar(string? filtro)
        {
            if (filtro != null && filtro.Length > 0)
                return Json(_context.Contato
                    .Where(c => 
                        c.TelefonePessoal.Contains(filtro)
                        || c.TelefoneComercial.Contains(filtro)
                        || c.Nome.Contains(filtro)
                        || c.Empresa.Contains(filtro)
                        || c.Emails.Contains(filtro)
                        ).ToList());
            else
                return Json(_context.Contato.ToList());
        }

        /// <returns>Retorna a view de criação do contato</returns>
        public IActionResult Criar()
        {
            return View();
        }

        /// <summary>
        /// Busca o registro com id passado por parametro para edição 
        /// </summary>
        /// <returns>Retorna a view com os dados do registro buscado</returns>
        public IActionResult Editar(int id)
        {
            var contato = _context.Contato.Find(id);
            if (contato == null)
                return NotFound();

            // Mapeia para o model de edição
            var model = new ContatoCriacaoEdicao
            {
                Nome = contato.Nome,
                TelefonePessoal = contato.TelefonePessoal,
                TelefoneComercial = contato.TelefoneComercial,
                Empresa = contato.Empresa,
            };

            if (contato.Emails.Length > 0)
                model.SepararEmailsPorPontoVirgula(contato.Emails);

            ViewBag.ContatoId = contato.Id;
            return View(model);
        }

        /// <summary>
        /// Edita o registro 
        /// </summary>
        /// <returns>Retorna para a index</returns>
        [HttpPost]
        public IActionResult Editar(int id, ContatoCriacaoEdicao model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ContatoId = id;
                return View(model);
            }

            var contato = _context.Contato.Find(id);
            if (contato == null)
                return NotFound();

            contato.Nome = model.Nome;
            contato.TelefonePessoal = model.TelefonePessoal;
            contato.TelefoneComercial = model.TelefoneComercial;
            contato.Empresa = model.Empresa;
            contato.Emails = model.ListaEmails != null ? string.Join(";", model.ListaEmails) : null;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Cria um novo contato a partir de um ContatoCriacaoEdicao e transforma em contato 
        /// a partir de um mapeamento
        /// </summary>
        /// <returns>Retorna para o index</returns>
        [HttpPost]
        public IActionResult CriarContato(ContatoCriacaoEdicao contatoCriacaoEdicao)
        {
            if (!ModelState.IsValid)
                return View("Criar", contatoCriacaoEdicao);

            Contato novoContato = new Contato()
            {
                Nome = contatoCriacaoEdicao.Nome,
                TelefonePessoal = contatoCriacaoEdicao.TelefonePessoal,
                TelefoneComercial = contatoCriacaoEdicao.TelefoneComercial,
                Empresa = contatoCriacaoEdicao.Empresa,
                Emails = contatoCriacaoEdicao.ListaEmails != null ? string.Join(";", contatoCriacaoEdicao.ListaEmails) : null
            };

            _context.Contato.Add(novoContato);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Exclui o contato com id que é passado por parametro
        /// </summary>
        [HttpDelete]
        public IActionResult Excluir(int id)
        {
            var contato = _context.Contato.Find(id);
            if (contato == null)
                return NotFound();

            _context.Contato.Remove(contato);
            _context.SaveChanges();
            return Ok();
        }
    }
}