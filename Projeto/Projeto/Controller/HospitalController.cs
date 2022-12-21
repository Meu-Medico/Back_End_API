﻿using Microsoft.AspNetCore.Mvc;
using Data.Contexto;
using Data.Entidade;
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
        // GET: api/<HospitalController>
        [HttpGet]
        [Route("/ListarTodos/Hospital")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<HospitalDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarTodos()
        {   
            try
            {
                //return Ok((from h in _context.Hospitals select h).ToList());
                return Ok(_hospitalRepositorio.ListarTodos());

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        [Route("/Cadastrar/Hospital")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Cadastrar(HospitalDto hospitalDto)
        {
            if (hospitalDto == null || String.IsNullOrEmpty(hospitalDto.Nome))
                return NoContent();

            return BadRequest();
        }
        /*
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<HospitalController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<HospitalController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HospitalController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HospitalController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
