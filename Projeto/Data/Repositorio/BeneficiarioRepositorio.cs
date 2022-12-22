using Data.Dto.Beneficiario;
using Data.Interface;
using Projeto.Entidade;
using Data.Contexto;

namespace Data.Repositorio
{
    public class BeneficiarioRepositorio : IBeneficiarioRepositorio
    {
        private readonly ProjetoContext _context;
        public BeneficiarioRepositorio(ProjetoContext context)
        {
            _context = context;
        }
        public Beneficiario Criar(BeneficiarioCriarDto beneficiario)
        {
            Beneficiario beneficiarioEntidade = new Beneficiario()
            {
                Nome = beneficiario.Nome,
                Cpf = beneficiario.Cpf,
                Telefone = beneficiario.Telefone,
                Endereco = beneficiario.Endereco,
                NumeroCarteirinha = beneficiario.NumeroCarteirinha,
                Ativo = beneficiario.Ativo,
                Email = beneficiario.Email,
                Senha = beneficiario.Senha,
            };
            _context.ChangeTracker.Clear();
            _context.Beneficiarios.Add(beneficiarioEntidade);
            _context.SaveChanges();
            return beneficiarioEntidade;
        }
        public int Editar(BeneficiarioEditarDto beneficiario)
        {
            Beneficiario beneficiarioEntidadeBD =
            (from c in _context.Beneficiarios
             where c.IdBeneficiario == beneficiario.IdBeneficiario
             select c)
             ?.FirstOrDefault()
             ?? new Beneficiario();
            if (beneficiario == null || DBNull.Value.Equals(beneficiario.IdBeneficiario) || beneficiario.IdBeneficiario == 0)
            {
                return 0;
            }
            //Beneficiario beneficiarioEntidade = new Beneficiario()
            beneficiarioEntidadeBD.IdBeneficiario = beneficiario.IdBeneficiario;
            beneficiarioEntidadeBD.Nome = beneficiario.Nome;
            beneficiarioEntidadeBD.Cpf = beneficiario.Cpf;
            beneficiarioEntidadeBD.NumeroCarteirinha = beneficiario.NumeroCarteirinha;
            beneficiarioEntidadeBD.Telefone = beneficiario.Telefone;
            beneficiarioEntidadeBD.Endereco = beneficiario.Endereco;
            beneficiarioEntidadeBD.Ativo = beneficiario.Ativo;
            beneficiarioEntidadeBD.Email = beneficiario.Email;
            beneficiarioEntidadeBD.Senha = beneficiario.Senha;
           
            _context.ChangeTracker.Clear();
            _context.Beneficiarios.Update(beneficiarioEntidadeBD);
            return _context.SaveChanges();
        }
        public int Excluir(int Id)
        {
            Beneficiario beneficiarioEntidade = (from b in _context.Beneficiarios  
                                                 where b.IdBeneficiario == Id
                                                 select b).FirstOrDefault();
            if (beneficiarioEntidade == null || DBNull.Value.Equals(beneficiarioEntidade.IdBeneficiario)|| beneficiarioEntidade.IdBeneficiario == 0)
            {
                return 0;
            }

            _context.ChangeTracker.Clear();
            _context.Beneficiarios.Remove(beneficiarioEntidade);
            return _context.SaveChanges(); 

        }
        public List<BeneficiarioDto> ListarTodos()
        {
            return _context.Beneficiarios.Select(s => new BeneficiarioDto()
            {
                IdBeneficiario = s.IdBeneficiario,
                Nome = s.Nome,
                Cpf = s.Cpf,
                Telefone = s.Telefone,
                Endereco = s.Endereco,
                NumeroCarteirinha = s.NumeroCarteirinha,
                Ativo = s.Ativo,
                Email = s.Email,
                Senha = s.Senha,
            }).ToList();
        }

        public List<BeneficiarioDto> ListarPorId(int id)
        {
            return (from t in _context.Beneficiarios
                    where t.IdBeneficiario == id
                    select new Dto.Beneficiario.BeneficiarioDto()
                    {
                        IdBeneficiario = t.IdBeneficiario,
                        Nome = t.Nome,
                        Cpf = t.Cpf,
                        Telefone = t.Telefone,
                        Endereco = t.Endereco,
                        NumeroCarteirinha = t.NumeroCarteirinha,
                        Ativo = t.Ativo,
                        Email = t.Email,
                        Senha = t.Senha,
                    }).ToList();
        }
    }
}