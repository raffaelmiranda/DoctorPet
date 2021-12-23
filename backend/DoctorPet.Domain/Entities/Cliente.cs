using System;
using System.Collections.Generic;

namespace DoctorPet.Domain.Entities
{
    public class Cliente
    {
        public Cliente()
        {
            DataCadastro = DateTime.Now;
        }

        //public Cliente(string nome, string cpf, List<Animal> animals)
        //{
        //    Nome = nome;
        //    Cpf = cpf;
        //    Animais = animals;
        //    DataCadastro = DateTime.Now;
        //}

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataCadastro { get; set; }
        public List<Animal> Animais { get; set; }

        public bool CPFValido()
        {
            if (Cpf.Length == 11)
                return true;
            
            return false;
        }
    }
}
