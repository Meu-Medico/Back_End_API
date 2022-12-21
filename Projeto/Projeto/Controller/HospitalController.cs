using Microsoft.AspNetCore.Mvc;
using Projeto.Contexto;

namespace Projeto.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly Contexto.ProjetoContext _context;
        public HospitalController(ProjetoContext context)
        {
            _context = context;
        }
        // GET: api/<HospitalController>
        [HttpGet]
        [Route("/ListarTodos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Entidade.Hospital>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok((from h in _context.Hospitals select h).ToList());

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
