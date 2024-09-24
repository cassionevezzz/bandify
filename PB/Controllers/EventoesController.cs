using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PB.Data;
using PB.Models;
using PB.ViewModels;

namespace PB.Controllers
{
    public class EventoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Eventoes/Create
        [HttpGet]
        [Route("Eventoes/Create")]
        public IActionResult Create()
        {
            var viewModel = new EventoCreateViewModel
            {
                Artistas = _context.Artistas.ToList()
            };

            return View(viewModel);
        }

        // POST: Eventoes/Create
        [HttpPost]
        [Route("Eventoes/Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventoCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var artista = await _context.Artistas.FindAsync(viewModel.ArtistaId);
                var evento = new Evento
                {
                    Nome = viewModel.Nome,
                    Localizacao = viewModel.Localizacao,
                    Data = viewModel.Data,
                    Artista = artista
                };

                _context.Eventos.Add(evento);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            viewModel.Artistas = await _context.Artistas.ToListAsync();
            return View(viewModel);
        }

        // GET: Eventoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Eventos.ToListAsync());
        }

        // GET: Eventoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // GET: Eventoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }
            return View(evento);
        }

        // POST: Eventoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Localizacao,Data")] Evento evento)
        {
            if (id != evento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventoExists(evento.Id))
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
            return View(evento);
        }

        // GET: Eventoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // POST: Eventoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento != null)
            {
                _context.Eventos.Remove(evento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventoExists(int id)
        {
            return _context.Eventos.Any(e => e.Id == id);
        }
    }
}
