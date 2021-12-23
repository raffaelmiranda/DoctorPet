using DoctorPet.Application.Interfaces;
using DoctorPet.Application.Model;
using DoctorPet.Application.Model.Input;
using DoctorPet.Domain.Core.Result;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace DoctorPet.Api.Controllers.V1
{
    [Route("v{version:apiVersion}/clientes")]
    [ApiVersion("1")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteAppService _clienteAppService;
        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [SwaggerResponse((int)HttpStatusCode.OK, "Salvar cliente", typeof(CriarClienteInput))]
        [SwaggerResponse((int)HttpStatusCode.UnprocessableEntity, "Erro de validação", typeof(ResultFault))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno no servidor", typeof(ResultFault))]
        [HttpPost]
        [Route("")]
        public IActionResult Salvar(CriarClienteInput clienteInput)
        {
            var output = _clienteAppService.Salvar(clienteInput);

            if (output == null)  return NoContent();
                    
            return Ok(output);
        }

        [SwaggerResponse((int)HttpStatusCode.OK, "Atualizar cliente", typeof(AtualizarClienteInput))]
        [SwaggerResponse((int)HttpStatusCode.UnprocessableEntity, "Erro de validação", typeof(ResultFault))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno no servidor", typeof(ResultFault))]
        [HttpPut]
        [Route("")]
        public IActionResult Atualizar(AtualizarClienteInput clienteInput)
        {
            var output = _clienteAppService.Atualizar(clienteInput);

            if (output == null) return NoContent();

            return Ok(output);
        }

        [SwaggerResponse((int)HttpStatusCode.OK, "Atualizar cliente", typeof(int))]
        [SwaggerResponse((int)HttpStatusCode.UnprocessableEntity, "Erro de validação", typeof(ResultFault))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno no servidor", typeof(ResultFault))]
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Excluir(int id)
        {
            var output = _clienteAppService.Excluir(id);

            if (output == false) return UnprocessableEntity();

            return NoContent();
        }

        [SwaggerResponse((int)HttpStatusCode.OK, "Buscar cliente", typeof(int))]
        [SwaggerResponse((int)HttpStatusCode.UnprocessableEntity, "Erro de validação", typeof(ResultFault))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno no servidor", typeof(ResultFault))]
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult ObterPorId(int id)
        {
            var output = _clienteAppService.ObterPorId(id);

            if (output == null) return UnprocessableEntity();

            return Ok(output);
        }
    }
}
