using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GerenciadoDespesas.Models;
using GerenciadorDespesas.Models;

namespace GerenciadorDespesas.Controllers
{
    public class TipoDespesasController : Controller
    {
        private readonly Contexto _context;

        public TipoDespesasController(Contexto context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            return View(await _context.TipoDespesas.ToListAsync());

        }
        [HttpPost]
        public async Task<IActionResult> Index(string txtProcurar)
        {
            if (!string.IsNullOrEmpty(txtProcurar))
                return View(await _context.TipoDespesas.Where(td => td.Nome.ToUpper().Contains(txtProcurar.ToUpper())).ToListAsync());
            return View(await _context.TipoDespesas.ToListAsync());
        }

        

        //funcao vai dizer se aquele tipo de despesa ja exixte ou não
        public async Task<JsonResult> TipoDespesaExiste(string Nome)
        {
            if (await _context.TipoDespesas.AnyAsync(td => td.Nome.ToUpper() == Nome.ToUpper()))
                return Json("Esse tipo de despesa já exixte!");
            return Json(true);



        }

        // GET: TipoDespesas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDespesas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoDespesaId,Nome")] TipoDespesas tipoDespesas)
        {
            if (ModelState.IsValid)
            {
                TempData["Confirmacao"] = tipoDespesas.Nome + " Foi cadastrado com sucesso.";

                _context.Add(tipoDespesas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDespesas);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDespesas = await _context.TipoDespesas.FindAsync(id);
            if (tipoDespesas == null)
            {
                return NotFound();
            }
            return View(tipoDespesas);
        }

        // POST: TipoDespesas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoDespesaId,Nome")] TipoDespesas tipoDespesas)
        {
            if (id != tipoDespesas.TipoDespesaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                try
                {
                    TempData["Confirmacao"] = tipoDespesas.Nome + " Foi atualizado com sucesso.";

                    _context.Update(tipoDespesas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDespesasExists(tipoDespesas.TipoDespesaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDespesas);
        }



        // POST: TipoDespesas/Delete/5
        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            var tipoDespesas = await _context.TipoDespesas.FindAsync(id);
            TempData["Confirmacao"] = tipoDespesas.Nome + " Foi excluido com sucesso.";

            _context.TipoDespesas.Remove(tipoDespesas);
            await _context.SaveChangesAsync();
            return Json(tipoDespesas.Nome + " excluído com sucesso.");
        }

        private bool TipoDespesasExists(int id)
        {
            return _context.TipoDespesas.Any(e => e.TipoDespesaId == id);
        }
    }
}
