using Data.Contexto;
using Data.Entidade;
using Data.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Data.Repositorio
{/*
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly IAgendamento _agendamentoService;

        public AgendamentoController(IAgendamentoService agendamentoService)
        {

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var agendamentos = _agendamentoService.FindAll();
                return Ok(agendamentos);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var agendamento = _agendamentoService.FindById(id);
                return Ok(agendamento);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] AgendamentoDto agendamentoDto)
        {
            try
            {
                var agendamento = new Agendamento
                {
                    NomePaciente = agendamentoDto.NomePaciente,
                    DataHoraAgendamento = agendamentoDto.DataHoraAgendamento,
                    HoraAgendamento = agendamentoDto.HoraAgendamento
                };

                _agendamentoService.Insert(agendamento);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AgendamentoDto agendamentoDto)
        {
            try
            {
                var agendamento = _agendamentoService.FindById(id);
                if (agendamento == null)
                    return NotFound();

                agendamento.NomePaciente = agendamentoDto.NomePaciente;
                agendamento.DataHoraAgendamento = agendamentoDto.DataHoraAgendamento;
                agendamento.HoraAgendamento = agendamentoDto.HoraAgendamento;

                _agendamentoService.Update(agendamento);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError;
            }
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                try
                {
                    var agendamento = _agendamentoService.FindById(id);
                    if (agendamento == null)
                        return NotFound();

                    _agendamentoService.Delete(agendamento);
                    return Ok();
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
                }
            }
        }
    }
   */ 
}