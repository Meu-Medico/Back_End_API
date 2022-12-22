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
        public List<ProfissionalDto> ListarPorId(int id)
        {
            return (from h in _context.Profissionals
                    where h.IdProfissional == id
                    select new Dto.ProfissionalDto()
                    {
                        Id = h.IdProfissional,
                        Nome = h.Nome
                    }).ToList();
        }
        public List<ProfissionalDto> ListarPorNome(string nome)
        {
            return (from h in _context.Profissionals
                    where h.Nome == nome
                    select new Dto.ProfissionalDto()
                    {
                        Id = h.IdProfissional,
                        Nome = h.Nome
                    }).ToList();
        }

        public int Cadastrar(ProfissionalDto profissional)
        {
            Profissional ProfissionalEntidade = new Profissional()
                {
                    Nome = profissional.Nome,
                    Endereco = profissional.Endereco,
                    Telefone = profissional.Telefone,
                    Ativo = profissional.Ativo,
                };

                _context.ChangeTracker.Clear();
                _context.Profissionals.Add(ProfissionalEntidade);
                return _context.SaveChanges();
        }

        public int Atualizar(ProfissionalDto profissionalDto)
        {

            Profissional profissional = (from p in _context.Profissionals
                                 where p.IdProfissional == p.IdProfissional
                                 select p)
                                       ?.FirstOrDefault()
                                       ?? new Profissional();

            if (profissionalDto == null || DBNull.Value.Equals(profissionalDto.Id) || profissionalDto.Id == 0)
            {
                return 0;
            }

            profissional.Nome = profissionalDto.Nome;
            profissional.Telefone = profissionalDto.Telefone;
            profissional.Endereco = profissionalDto.Endereco;
            profissional.Ativo = profissionalDto.Ativo;

            _context.ChangeTracker.Clear();
            _context.Profissionals.Update(profissional);
            return _context.SaveChanges();
        }

        public int Excluir(int id)
        {
            Profissional profissional = (from p in _context.Profissionals
                                 where p.IdProfissional == id
                                 select p).FirstOrDefault();

            if (profissional == null || DBNull.Value.Equals(profissional.IdProfissional) || profissional.IdProfissional == 0)
            {
                return 0;
            }

            _context.ChangeTracker.Clear();
            _context.Profissionals.Remove(profissional);
            return _context.SaveChanges();
        }
    }
}
