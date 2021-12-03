using DarAgenda.Utils.Extensions;
using DarAgenda.Utils.Models;
using DartAgenda.Business.Models;
using DartAgenda.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DartAgenda.Api.Controllers
{
    [ApiController]
    [Route("assinatura")]
    public class ContatoControler: Controller
    {
        private IContatoService _contatoService;

        public ContatoControler(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        [HttpPost]
        [Route("salvar")]
        public async Task<IActionResult> Salvar([FromBody] Contato contato)
        {
            var defaultResponse = new DefaultResponse();
            try
            {
                if (contato == null)
                    throw new ExceptionExtension("Dados de entrada inválidos");

                var contatoSalvo = await _contatoService.Salvar(contato);
                defaultResponse = new DefaultResponse("Contato incluído com sucesso", contatoSalvo);
            }
            catch (ExceptionExtension ee)
            {
                defaultResponse = new DefaultResponse(ee.Messages, null);
            }

            return Json(defaultResponse);
        }

        [HttpGet]
        [Route("listar-todos")]
        public IActionResult ListarTodos()
        {
            var defaultResponse = new DefaultResponse();
            try
            {                
                var contatos = _contatoService.ListaTodos();                
                defaultResponse = new DefaultResponse("", contatos);

            }
            catch (ExceptionExtension ee)
            {
                defaultResponse = new DefaultResponse(ee.Messages, null);
            }

            return Json(defaultResponse);
        }

        [HttpPost]
        [Route("pesquisar")]
        public IActionResult Pesquisar([FromBody] Contato filtro)
        {
            var defaultResponse = new DefaultResponse();
            try
            {
                var contatos = _contatoService.Pesquisar(filtro);
                defaultResponse = new DefaultResponse("", contatos);

            }
            catch (ExceptionExtension ee)
            {
                defaultResponse = new DefaultResponse(ee.Messages, null);
            }

            return Json(defaultResponse);
        }

        [HttpDelete]
        [Route("excluir/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var defaultResponse = new DefaultResponse();
            try
            {
                await _contatoService.Excluir(id);
                defaultResponse = new DefaultResponse("Contato excluído", null);

            }
            catch (ExceptionExtension ee)
            {
                defaultResponse = new DefaultResponse(ee.Messages, null);
            }

            return Json(defaultResponse);
        }
    }
}
