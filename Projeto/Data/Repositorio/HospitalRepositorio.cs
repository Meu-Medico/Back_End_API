using Data.Contexto;
using Data.Entidade;

namespace Data.Repositorio
{
    public class HospitalRepositorio
    {
        private readonly ProjetoContext _context;
        //injeçao de dados
        public HospitalRepositorio(ProjetoContext context) 
        {
            _context = context;
        }
        /*public List<Dto.HospitalDto> Hospital(int id)
        {
            return _context.Hospitals
                .Where(h=>h.IdHospital == id)
                .Select(s=> new Dto.HospitalDto()
                {
                    Id = s.IdHospital,
                    Nome = s.Nome
                })
                .ToList();
        }*/
        public List<Dto.HospitalDto> Hospital(int id)
        {
            return (from h in _context.Hospitals
                    where h.IdHospital == id
                    select new Dto.HospitalDto()
                    {
                        Id = h.IdHospital,
                        Nome = h.Nome
                    })
                .ToList();
        }
        
    }
}
