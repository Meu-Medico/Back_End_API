using Data.Dto.Beneficiario;
using Microsoft.AspNetCore.Mvc;
using Projeto.Entidade;
using Data.Entidade;
using Data.Interface;
using Data.Repositorio;

namespace Projeto.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeneficiarioController : ControllerBase
    {
        private readonly IBeneficiarioRepositorio _beneficiarioRepositorio;
        public BeneficiarioController(IBeneficiarioRepositorio beneficiarioRepositorio)
        {
            _beneficiarioRepositorio = beneficiarioRepositorio;
        }
        [HttpGet]
        [Route("ListarTodos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<BeneficiarioDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_beneficiarioRepositorio.ListarTodos());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("Criar/Beneficiario")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<BeneficiarioDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Criar(BeneficiarioCriarDto novoBeneficiario)
        {
            try
            {
                //Beneficiario beneficiarioEntidade = _beneficiarioRepositorio.Criar(novoBeneficiario);
                return Ok(_beneficiarioRepositorio.Criar(novoBeneficiario));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch]
        [Route("Editar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<BeneficiarioDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Editar(BeneficiarioEditarDto beneficiario)
        {
            try
            {
                //Beneficiario beneficiarioEntidade = _beneficiarioRepositorio.Editar(beneficiario);
                return Ok(_beneficiarioRepositorio.Editar(beneficiario));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("Excluir/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<BeneficiarioDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Excluir(int id)
        {
            try
            {
                //int linhasRetornadas = _beneficiarioRepositorio.Excluir(id);
                return Ok(_beneficiarioRepositorio.Excluir(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}