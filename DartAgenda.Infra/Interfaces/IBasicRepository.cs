using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DartAgenda.Infra.Interfaces
{
    public interface IBasicRepository<T>
    {
        IDbContextTransaction BeginTransaction();
        Task<int> SaveChangesAsync();
        Task<T> Salvar(T model);
        T ObterPorId(int id);
        IEnumerable<T> ListaTodos();
        IEnumerable<T> Pesquisar(T filtro);
        void Excluir(T model);
    }
}
