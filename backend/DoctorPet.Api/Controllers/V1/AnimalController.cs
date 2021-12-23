using DoctorPet.Application.Interfaces;
using DoctorPet.Application.Model;
using DoctorPet.Application.Model.Input;
using DoctorPet.Domain.Core.Result;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace DoctorPet.Api.Controllers.V1
{
    [Route("v{version:apiVersion}/animais")]
    [ApiVersion("1")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalAppService _animalAppService;
        public AnimalController(IAnimalAppService animalAppService)
        {
            _animalAppService = animalAppService;
        }

        [SwaggerResponse((int)HttpStatusCode.OK, "Salvar animal", typeof(CriarAnimalInput))]
        [SwaggerResponse((int)HttpStatusCode.UnprocessableEntity, "Erro de validação", typeof(ResultFault))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno no servidor", typeof(ResultFault))]
        [HttpPost]
        [Route("")]
        public IActionResult Salvar(CriarAnimalInput animalInput)
        {
            var output = _animalAppService.Salvar(animalInput);

            if (output == null) return NoContent();

            return Ok(output);
        }

        [SwaggerResponse((int)HttpStatusCode.OK, "Atualizar animal", typeof(CriarAnimalInput))]
        [SwaggerResponse((int)HttpStatusCode.UnprocessableEntity, "Erro de validação", typeof(ResultFault))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno no servidor", typeof(ResultFault))]
        [HttpPut]
        [Route("")]
        public IActionResult Atualizar(AtualizarAnimalInput animalInput)
        {
            var output = _animalAppService.Atualizar(animalInput);

            if (output == null) return NoContent();

            return Ok(output);
        }
    }
}
