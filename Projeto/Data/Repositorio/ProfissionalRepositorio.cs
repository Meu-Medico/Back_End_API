using Data.Contexto;
using Data.Dto;
using Data.Entidade;
using Data.Interface;

namespace Data.Repositorio
{
    public class ProfissionalRepositorio : IProfissionalRepositorio
    {
        private readonly ProjetoContext _context;
        //injeçao de dados
        public ProfissionalRepositorio(ProjetoContext context)
        {
            _context = context;

        }

        public List<ProfissionalDto> ListarTodos()
        {
            return (from h in _context.Profissionals
                    select new Dto.ProfissionalDto()
                    {
                        Id = h.IdProfissional,
                        Nome = h.Nome
                    }).ToList();
        }
    }
}
