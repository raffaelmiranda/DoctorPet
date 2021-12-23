using DoctorPet.Domain.Entities.Enum;
using System;
using System.Collections.Generic;

namespace DoctorPet.Domain.Entities
{
    public class Animal
    {
        public Animal()
        {
            DataCadastro = DateTime.Now;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }

        public int TipoAnimalId { get; set; }
        public TipoAnimal TipoAnimal { get; set; }
        public DateTime DataCadastro { get; private set; }
        public List<Atendimento> Atendimentos { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public List<Agendamento> Agendamentos { get; set; }

        public bool AnimalIdoso()
        {
            if (TipoAnimal.Nome == "Hamster" && Idade > 2)
                return true;
            if (TipoAnimal.Nome == "Cão" || TipoAnimal.Nome == "Gato" && Idade > 7)
                return true;

            return false;
        }
    }
}
