using System;

namespace DoctorPet.Domain.Entities
{
    public class Agendamento
    {
        public Agendamento()
        {
            DataCadastro = DateTime.Now;    
        }
        public int Id { get; set; }
        public DateTime DataConsulta { get; set; }
        public DateTime DataCadastro { get; private set; }

        public int VeterinarioId { get; set; }
        public Veterinario Veterinario { get; set; }
        public int AnimalId { get; set; }

        public Animal Animal { get; set; }
    }
}
