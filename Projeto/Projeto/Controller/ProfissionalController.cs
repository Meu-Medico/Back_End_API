using Microsoft.AspNetCore.Mvc;
using Data.Contexto;
using Data.Entidade;
using Data.Dto;
using Data.Interface;
using Data.Repositorio;

namespace Projeto.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfissionalController : ControllerBase
    {
        private readonly IProfissionalRepositorio _profissionalRepositorio;
        public ProfissionalController(IProfissionalRepositorio profissionalRepositorio)
        {
            _profissionalRepositorio= profissionalRepositorio;
        }
        [HttpGet]
        [Route("/ListarTodos/Profissionais")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProfissionalDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_profissionalRepositorio.ListarTodos());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("/ProfissionalID/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProfissionalDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarPorId(int id)
        {
            try
            {
                return Ok(_profissionalRepositorio.ListarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("/ListarNome/Profissional/{nome}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProfissionalDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarPorNome(string nome)
        {
            try
            {
                return Ok(_profissionalRepositorio.ListarPorNome(nome));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        [Route("/Cadastrar/Profissional")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProfissionalDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Cadastrar(ProfissionalDto profissionalDto)
        {
            try
            {
                return Ok(_profissionalRepositorio.Cadastrar(profissionalDto));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPatch]
        [Route("/Atualizar/Profissional")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProfissionalDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AtualizarHospital(ProfissionalDto profissionalDto)
        {
            try
            {
                return Ok(_profissionalRepositorio.Atualizar(profissionalDto));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        [Route("/Excluir/Profissional")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Excluir(int id)
        {
            try
            {
                return Ok(_profissionalRepositorio.Excluir(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
