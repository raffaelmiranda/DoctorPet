using System;

namespace DoctorPet.Domain.Entities
{
    public class Atendimento
    {
        public Atendimento()
        {
            DataCadastro = DateTime.Now;
        }
        public string Diagnostico { get; set; }
        public DateTime DataAtendimento { get; set; }
        public DateTime DataCadastro { get; private set; }
        public int VeterinarioId { get; set; }
        public Veterinario Veterinario { get; set; }
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
    }
}
