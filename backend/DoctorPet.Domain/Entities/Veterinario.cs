using System;
using System.Collections.Generic;

namespace DoctorPet.Domain.Entities
{
    public class Veterinario
    {
        public Veterinario()
        {
            DataCadastro = DateTime.Now;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Geriatria { get; set; }
        public DateTime DataContratacao { get; set; }
        public DateTime DataCadastro { get; private set; }

        public List<Agendamento> Agendamentos { get; set; }
        public List<Atendimento> Atendimentos { get; set; }

    }
}
