using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;

namespace DoctorPet.Domain.Core.Result
{
    public class ResultFault
    {
        [SwaggerSchema("Falha na operação", Format = "bool", Nullable = false, ReadOnly = true)]
        public bool Invalid { get; set; } = true;
        public bool Valid { get; set; } = false;

        [SwaggerSchema("Lista de erros encontrados durante a operação", Format = "IEnumerable<string>", Nullable = false, ReadOnly = true)]
        public IEnumerable<string> Notifications { get; set; }
    }
}
