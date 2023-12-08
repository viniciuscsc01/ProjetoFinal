using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Models;

namespace ProjetoFinal.Controllers
{
    public class ProcedimentoRealizadoController : Controller
    {
        private readonly Contexto _context;

        public ProcedimentoRealizadoController(Contexto context)
        {
            _context = context;
        }

        // GET: ProcedimentoRealizado
        public async Task<IActionResult> Index()
        {
            var contexto = _context.ProcedimentoRealizado.Include(p => p.Cidade).Include(p => p.LocalRealizacao).Include(p => p.TipoColaborador).Include(p => p.TipoProcedimento);
            return View(await contexto.ToListAsync());
        }

        // GET: ProcedimentoRealizado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProcedimentoRealizado == null)
            {
                return NotFound();
            }

            var procedimentoRealizado = await _context.ProcedimentoRealizado
                .Include(p => p.Cidade)
                .Include(p => p.LocalRealizacao)
                .Include(p => p.TipoColaborador)
                .Include(p => p.TipoProcedimento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procedimentoRealizado == null)
            {
                return NotFound();
            }

            return View(procedimentoRealizado);
        }

        // GET: ProcedimentoRealizado/Create
        public IActionResult Create()
        {
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "CidadeId", "CidadeId");
            ViewData["LocalRealizacaoId"] = new SelectList(_context.LocalRealizacao, "LocalRealizacaoId", "LocalNome");
            ViewData["TipoColaboradorId"] = new SelectList(_context.TipoColaborador, "TipoColaboradorId", "TipoColaboradorNome");
            ViewData["TipoProcedimentoId"] = new SelectList(_context.TipoProcedimento, "Id", "TipoProcedimentoNome");
            return View();
        }

        // POST: ProcedimentoRealizado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CidadeId,TipoProcedimentoId,TipoColaboradorId,LocalRealizacaoId,DataRealizacao,ObservacaoRealizacao")] ProcedimentoRealizado procedimentoRealizado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(procedimentoRealizado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "CidadeId", "CidadeId", procedimentoRealizado.CidadeId);
            ViewData["LocalRealizacaoId"] = new SelectList(_context.LocalRealizacao, "LocalRealizacaoId", "LocalNome", procedimentoRealizado.LocalRealizacaoId);
            ViewData["TipoColaboradorId"] = new SelectList(_context.TipoColaborador, "TipoColaboradorId", "TipoColaboradorNome", procedimentoRealizado.TipoColaboradorId);
            ViewData["TipoProcedimentoId"] = new SelectList(_context.TipoProcedimento, "Id", "TipoProcedimentoNome", procedimentoRealizado.TipoProcedimentoId);
            return View(procedimentoRealizado);
        }

        // GET: ProcedimentoRealizado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProcedimentoRealizado == null)
            {
                return NotFound();
            }

            var procedimentoRealizado = await _context.ProcedimentoRealizado.FindAsync(id);
            if (procedimentoRealizado == null)
            {
                return NotFound();
            }
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "CidadeId", "CidadeId", procedimentoRealizado.CidadeId);
            ViewData["LocalRealizacaoId"] = new SelectList(_context.LocalRealizacao, "LocalRealizacaoId", "LocalNome", procedimentoRealizado.LocalRealizacaoId);
            ViewData["TipoColaboradorId"] = new SelectList(_context.TipoColaborador, "TipoColaboradorId", "TipoColaboradorNome", procedimentoRealizado.TipoColaboradorId);
            ViewData["TipoProcedimentoId"] = new SelectList(_context.TipoProcedimento, "Id", "TipoProcedimentoNome", procedimentoRealizado.TipoProcedimentoId);
            return View(procedimentoRealizado);
        }

        // POST: ProcedimentoRealizado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CidadeId,TipoProcedimentoId,TipoColaboradorId,LocalRealizacaoId,DataRealizacao,ObservacaoRealizacao")] ProcedimentoRealizado procedimentoRealizado)
        {
            if (id != procedimentoRealizado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procedimentoRealizado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcedimentoRealizadoExists(procedimentoRealizado.Id))
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
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "CidadeId", "CidadeId", procedimentoRealizado.CidadeId);
            ViewData["LocalRealizacaoId"] = new SelectList(_context.LocalRealizacao, "LocalRealizacaoId", "LocalNome", procedimentoRealizado.LocalRealizacaoId);
            ViewData["TipoColaboradorId"] = new SelectList(_context.TipoColaborador, "TipoColaboradorId", "TipoColaboradorNome", procedimentoRealizado.TipoColaboradorId);
            ViewData["TipoProcedimentoId"] = new SelectList(_context.TipoProcedimento, "Id", "TipoProcedimentoNome", procedimentoRealizado.TipoProcedimentoId);
            return View(procedimentoRealizado);
        }

        // GET: ProcedimentoRealizado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProcedimentoRealizado == null)
            {
                return NotFound();
            }

            var procedimentoRealizado = await _context.ProcedimentoRealizado
                .Include(p => p.Cidade)
                .Include(p => p.LocalRealizacao)
                .Include(p => p.TipoColaborador)
                .Include(p => p.TipoProcedimento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procedimentoRealizado == null)
            {
                return NotFound();
            }

            return View(procedimentoRealizado);
        }

        // POST: ProcedimentoRealizado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProcedimentoRealizado == null)
            {
                return Problem("Entity set 'Contexto.ProcedimentoRealizado'  is null.");
            }
            var procedimentoRealizado = await _context.ProcedimentoRealizado.FindAsync(id);
            if (procedimentoRealizado != null)
            {
                _context.ProcedimentoRealizado.Remove(procedimentoRealizado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcedimentoRealizadoExists(int id)
        {
          return (_context.ProcedimentoRealizado?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> Imprimir(int? id)
        {
            if (id == null || _context.ProcedimentoRealizado == null)
            {
                return NotFound();
            }
            var resultado = await _context.ProcedimentoRealizado
                .Include(p => p.Cidade)
                .Include(p => p.LocalRealizacao)
                .Include(p => p.TipoColaborador)
                .Include(p => p.TipoProcedimento)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (resultado == null)
            {
                return NotFound();
            }
            return View(resultado);
        }
    }
}
