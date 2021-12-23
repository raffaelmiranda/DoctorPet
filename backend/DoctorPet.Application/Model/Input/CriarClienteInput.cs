using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DoctorPet.Application.Model
{
    public class CriarClienteInput
    {
        [Required(ErrorMessage = "O nome do cliente é obrigatório")]      
        public string Nome { get; set; }

        [Required(ErrorMessage = "O cpf do cliente é obrigatório")]
        public string Cpf { get; set; }

        //[Required(ErrorMessage = "O animal é obrigatório")]
        //[MinLength(1, ErrorMessage = "É obrigatório pelo menos 1 animal")]
        //public List<CriarAnimalInput> Animais { get; set; }
    }
}
