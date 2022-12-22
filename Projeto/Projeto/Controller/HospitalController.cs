using Microsoft.AspNetCore.Mvc;
using Data.Dto;
using Data.Interface;

namespace Projeto.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalRepositorio _hospitalRepositorio;
        public HospitalController(IHospitalRepositorio hospitalRepositorio)
        {
            _hospitalRepositorio = hospitalRepositorio;
        }
        [HttpGet]
        [Route("/ListarTodos/Hospitais")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<HospitalDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_hospitalRepositorio.ListarTodos());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("/ListarPorID/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<HospitalDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarPorId(int id)
        {
            try
            {
                return Ok(_hospitalRepositorio.ListarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("/ListarPorNome/{nome}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<HospitalDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarPorNome(string nome)
        {
            try
            {
                return Ok(_hospitalRepositorio.ListarPorNome(nome));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("/Cadastrar/Hospital")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<HospitalDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Cadastrar(HospitalDto hospitalDto)
        {
            try
            {
                return Ok(_hospitalRepositorio.Cadastrar(hospitalDto));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPatch]
        [Route("/Atualizar/Hospital")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<HospitalDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AtualizarHospital(HospitalDto hospitalDto)
        {
            try
            {
                return Ok(_hospitalRepositorio.Atualizar(hospitalDto));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("/Excluir/Hospital")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Excluir(int id)
        {
            try
            {
                return Ok(_hospitalRepositorio.Excluir(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
