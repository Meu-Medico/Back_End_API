﻿using Microsoft.AspNetCore.Mvc;
using Data.Contexto;
using Data.Entidade;
using Data.Dto;
using Data.Interface;
using Data.Repositorio;

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
        // GET: api/<HospitalController>
        [HttpGet]
        [Route("/ListarTodos/Especialidade")]
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
        }/*
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
