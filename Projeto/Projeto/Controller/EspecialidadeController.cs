using Microsoft.AspNetCore.Mvc;
using Data.Dto;
using Data.Interface;

namespace Projeto.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadeController : ControllerBase
    {
        private readonly IEspecialidadeRepositorio _especialidadeRepositorio;
        public EspecialidadeController(IEspecialidadeRepositorio especialidadeRepositorio)
        {
            _especialidadeRepositorio = especialidadeRepositorio;
        }
        [HttpGet]
        [Route("/ListarTodos/Especialidades")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<EspecialidadeDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_especialidadeRepositorio.ListarTodos());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("/Listar/Especialidade/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<EspecialidadeDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarPorId(int id)
        {
            try
            {
                return Ok(_especialidadeRepositorio.ListarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("/ListarNome/Especialidade/{nome}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<EspecialidadeDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarPorNome(string nome)
        {
            try
            {
                return Ok(_especialidadeRepositorio.ListarPorNome(nome));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        [Route("/Cadastrar/Especialidade")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<EspecialidadeDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Cadastrar(EspecialidadeDto especialidadeDto)
        {
            try
            {
                return Ok(_especialidadeRepositorio.Cadastrar(especialidadeDto));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPatch]
        [Route("/Atualizar/Especialidade")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<EspecialidadeDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AtualizarHospital(EspecialidadeDto especialidadeDto)
        {
            try
            {
                return Ok(_especialidadeRepositorio.Atualizar(especialidadeDto));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message); 
            }
        }

        [HttpDelete]
        [Route("/Excluir/Especialidade")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Excluir(int id)
        {
            try
            {
                return Ok(_especialidadeRepositorio.Excluir(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
