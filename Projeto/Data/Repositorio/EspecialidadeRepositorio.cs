using Data.Contexto;
using Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorio
{
    public class EspecialidadeRepositorio : IEspecialidadeRepositorio
    {

        private readonly ProjetoContext _context;
        //injeçao de dados
        public EspecialidadeRepositorio(ProjetoContext context)
        {
            _context = context;
        }
        public List<Dto.EspecialidadeDto> ListarTodos()
        {
            return (from e in _context.Especialidades
                    select new Dto.EspecialidadeDto()
                    {
                        Id = e.IdEspecialidade,
                        Nome = e.Nome
                    }).ToList();
        }

    }
}
