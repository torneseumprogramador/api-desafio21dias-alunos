using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using api_desafio21dias.Models;
using api_desafio21dias.Servicos;

namespace api_desafio21dias.Controllers
{
    [ApiController]
    public class FornecedoresController : ControllerBase
    {
        private readonly DbContexto _context;

        public FornecedoresController(DbContexto context)
        {
            _context = context;
        }

        // GET: /Fornecedores
        [HttpGet]
        [Route("/Fornecedores")]
        public async Task<IActionResult> Index()
        {
            return StatusCode(200, await _context.Fornecedores.ToListAsync());
        }

        // GET: /Fornecedores/5
        [HttpGet]
        [Route("/Fornecedores/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return StatusCode(200, fornecedor);
        }

        // POST: /Fornecedores
        [HttpPost]
        [Route("/Fornecedores")]
        public async Task<IActionResult> Create(Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fornecedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return StatusCode(201, fornecedor);
        }

        // PUT: /Fornecedores/5
        [HttpPut]
        [Route("/Fornecedores/{id}")]
        public async Task<IActionResult> Edit(int id, Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    fornecedor.Id = id;
                    _context.Update(fornecedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FornecedorExists(fornecedor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return StatusCode(200, fornecedor);
            }
            return StatusCode(200, fornecedor);
        }

        // DELETE: /Fornecedores/5
        [HttpDelete]
        [Route("/Fornecedores/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(id);
            _context.Fornecedores.Remove(fornecedor);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }

        private bool FornecedorExists(int id)
        {
            return _context.Fornecedores.Any(e => e.Id == id);
        }
    }
}
