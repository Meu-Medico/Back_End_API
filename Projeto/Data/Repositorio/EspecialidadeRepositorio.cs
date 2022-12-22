using Data.Contexto;
using Data.Dto;
using Data.Entidade;
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
        public List<EspecialidadeDto> ListarPorId(int id)
        {
            return (from e in _context.Especialidades
                    where e.IdEspecialidade == id
                    select new Dto.EspecialidadeDto()
                    {
                        Id = e.IdEspecialidade,
                        Nome = e.Nome
                    }).ToList();
        }

        public List<EspecialidadeDto> ListarPorNome(string nome)
        {
            return (from e in _context.Especialidades
                    where e.Nome == nome
                    select new Dto.EspecialidadeDto()
                    {
                        Id = e.IdEspecialidade,
                        Nome = e.Nome
                    }).ToList();
        }

        public int Cadastrar(EspecialidadeDto especialidadeDto)
        {
            Especialidade especialidade = new Especialidade()
            {
                Nome = especialidadeDto.Nome,
                Descricao = especialidadeDto.Descricao,
                Ativo = especialidadeDto.Ativo,
            };

            _context.ChangeTracker.Clear();
            _context.Especialidades.Add(especialidade);
            return _context.SaveChanges();
        }

        public int Atualizar(EspecialidadeDto especialidadeDto)
        {
            Especialidade especialidade = (from e in _context.Especialidades
                                 where e.IdEspecialidade == e.IdEspecialidade
                                 select e)
                                       ?.FirstOrDefault()
                                       ?? new Especialidade();

            if (especialidadeDto == null || DBNull.Value.Equals(especialidadeDto.Id) || especialidadeDto.Id == 0)
            {
                return 0;
            }

            especialidade.Nome = especialidadeDto.Nome;
            especialidade.Descricao = especialidadeDto.Descricao;
            especialidade.Ativo = especialidadeDto.Ativo;

            _context.ChangeTracker.Clear();
            _context.Especialidades.Update(especialidade);
            return _context.SaveChanges();
        }

        public int Excluir(int id)
        {
            Especialidade especialidade = (from e in _context.Especialidades
                                 where e.IdEspecialidade == id
                                 select e).FirstOrDefault();

            if (especialidade == null || DBNull.Value.Equals(especialidade.IdEspecialidade) || especialidade.IdEspecialidade == 0)
            {
                return 0;
            }

            _context.ChangeTracker.Clear();
            _context.Especialidades.Remove(especialidade);
            return _context.SaveChanges();
        }
    }
}
