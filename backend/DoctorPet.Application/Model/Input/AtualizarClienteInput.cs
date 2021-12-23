using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPet.Application.Model.Input
{
    public class AtualizarClienteInput
    {
        [Required(ErrorMessage = "O id do cliente é obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do cliente é obrigatório")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O cpf do cliente é obrigatório")]
        public string Cpf { get; set; }
    }
}
