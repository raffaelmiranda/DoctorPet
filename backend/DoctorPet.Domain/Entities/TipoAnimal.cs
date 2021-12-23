using System;

namespace DoctorPet.Domain.Entities
{
    public class TipoAnimal
    {
        public TipoAnimal()
        {
            DataCadastro = DateTime.Now;
        }

        public TipoAnimal(int id, string nome)
        {
            Id = id;
            Nome = nome;
            DataCadastro = DateTime.Now;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public Animal Animal { get; private set; }

        public DateTime DataCadastro { get; private set; }
    }
}
