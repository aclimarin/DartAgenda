using DartAgenda.Business.Models;
using DartAgenda.Infra.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DartAgenda.Infra.Repositories
{
    public class ContatoRepository : BasicRepository<Contato>, IContatoRepository
    {
        public ContatoRepository(AppDbContext dbContext): base(dbContext)
        {
            
        }

        override
        public IEnumerable<Contato> Pesquisar(Contato filtro)
        {
            var query = _dbContext.Contato.AsQueryable();

            if (filtro.Id > 0)
            {
                query = query.Where(x => x.Id == filtro.Id);
            }
            else
            {
                if (!string.IsNullOrEmpty(filtro.Nome))
                {
                    query = query.Where(x => x.Nome.Contains(filtro.Nome));
                }
                if (!string.IsNullOrEmpty(filtro.Email))
                {
                    query = query.Where(x => x.Email.Contains(filtro.Email));
                }
                if (!string.IsNullOrEmpty(filtro.Telefone))
                {
                    query = query.Where(x => x.Telefone == filtro.Telefone);
                }
            }

            return query.AsEnumerable();
        }
    }
}
