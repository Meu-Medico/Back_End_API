using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.Contexto;
using Projeto.Entidade;
using Projeto.Repositorio;
namespace Projeto.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeneficiarioController : ControllerBase
    {
        private readonly ProjetoContext _context;
        private readonly object beneficiarioRepositorio;

        public BeneficiarioController(ProjetoContext context)
        {
            _context = context;
        }

        // GET: api/Beneficiario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Beneficiario>>> GetBeneficiarios()
        {
            return await _context.Beneficiarios.ToListAsync();
        }

        // GET: api/Beneficiario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Beneficiario>> GetBeneficiario(int id)
        {
            var beneficiario = await _context.Beneficiarios.FindAsync(id);

            if (beneficiario == null)
            {
                return NotFound();
            }

            return beneficiario;
        }

        // PUT: api/Beneficiario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeneficiario(int id, Beneficiario beneficiario)
        {
            if (id != beneficiario.IdBeneficiario)
            {
                return BadRequest();
            }

            _context.Entry(beneficiario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeneficiarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Beneficiario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Beneficiario>> PostBeneficiario(Beneficiario beneficiario)
        {
            _context.Beneficiarios.Add(beneficiario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBeneficiario", new { id = beneficiario.IdBeneficiario }, beneficiario);
        }

        [HttpDelete]
        [Route("/Excluir")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ExcluirBeneficiario(int idBeneficiario)
        {
            try
            {
                beneficiarioRepositorio.ExcluirBeneficiario(idBeneficiario);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
