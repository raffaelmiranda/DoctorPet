using System.ComponentModel.DataAnnotations;

namespace DoctorPet.Application.Model.Input
{
    public class AtualizarAnimalInput
    {
        [Required(ErrorMessage = "O id do animal é obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do animal é obrigatório")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "A idade do animal é obrigatório")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "O tipo do animal é obrigatório")]
        public ETipoAnimalInput TipoAnimalId { get; set; }

        [Required(ErrorMessage = "O cliente é obrigatório")]
        public int ClienteId { get; set; }
    }
}
