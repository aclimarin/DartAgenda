using DarAgenda.Utils.Extensions;
using DartAgenda.Business.Models;
using DartAgenda.Domain.Interfaces;
using DartAgenda.Infra.Interfaces;using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DartAgenda.Domain.Services
{
    public class ContatoService : IContatoService
    {
        private IContatoRepository _contatoRepository;
        public ContatoService(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }
        public async Task Excluir(int id)
        {
            using (var transaction = _contatoRepository.BeginTransaction())
            {
                try
                {
                    var contato = _contatoRepository.ObterPorId(id);
                    _contatoRepository.Excluir(contato);
                    await _contatoRepository.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (ExceptionExtension)
                {
                    transaction.Rollback();
                    throw new ExceptionExtension("Erro ao excluir contato");
                }
            }
                
        }

        public IEnumerable<Contato> ListaTodos()
        {
            return _contatoRepository.ListaTodos();
        }

        public IEnumerable<Contato> Pesquisar(Contato filtro)
        {
            if (filtro == null)
                return _contatoRepository.ListaTodos();

            return _contatoRepository.Pesquisar(filtro);
        }

        public async Task<Contato> Salvar(Contato model)
        {
            Contato result = new Contato();   
            using (var transaction = _contatoRepository.BeginTransaction())
            {
                try
                {
                    List<string> errorMessages = new List<string>();

                    if (string.IsNullOrEmpty(model.Nome.Trim()))
                    {
                        errorMessages.Add("Nome não pode ficar em branco.");
                    }
                    if (string.IsNullOrEmpty(model.Telefone.Trim()))
                    {
                        errorMessages.Add("Telefone não pode ficar em branco.");
                    }
                    if (string.IsNullOrEmpty(model.Email.Trim()))
                    {
                        errorMessages.Add("E-mail não pode ficar em branco.");
                    }

                    if (errorMessages.Count > 0)
                        throw new ExceptionExtension(errorMessages);


                    result =  await _contatoRepository.Salvar(model);
                    await _contatoRepository.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (ExceptionExtension)
                {
                    transaction.Rollback();
                    throw new ExceptionExtension("Erro ao excluir contato");
                }
            }

            return result;
        }
    }
}
