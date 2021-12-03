using DartAgenda.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DartAgenda.Domain.Interfaces
{
    public interface IContatoService
    {
        Task<Contato> Salvar(Contato model);
        IEnumerable<Contato> ListaTodos();
        IEnumerable<Contato> Pesquisar(Contato filtro);
        Task Excluir(int id);
    }
}
