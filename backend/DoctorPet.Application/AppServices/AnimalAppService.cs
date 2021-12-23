using AutoMapper;
using DoctorPet.Application.Interfaces;
using DoctorPet.Application.Model;
using DoctorPet.Application.Model.Input;
using DoctorPet.Application.Model.Output;
using DoctorPet.Domain.Core.Notifications;
using DoctorPet.Domain.Entities;
using DoctorPet.Domain.Interfaces.Repositories;
using System;

namespace DoctorPet.Application.AppServices
{
    public class AnimalAppService : IAnimalAppService
    {
        private readonly IAnimalRepository _repository;
        private readonly INotificator _notificator;
        private readonly IMapper _mapper;

        public AnimalAppService(IAnimalRepository repository,
            INotificator notificator,
            IMapper mapper)
        {
            _repository = repository;
            _notificator = notificator;
            _mapper = mapper;
        }

        public AnimalOutput Salvar(CriarAnimalInput animalInput)
        {
            Animal animalSalvar = _mapper.Map<Animal>(animalInput);

            Animal animalSalvo = _repository.Salvar(animalSalvar);

            if (animalSalvo == null)
            {
                _notificator.Add("Não possível salvar o animal");
                return null;
            }

            AnimalOutput animalOutput = _mapper.Map<AnimalOutput>(animalSalvo);

            return animalOutput;
        }

        public AnimalOutput Atualizar(AtualizarAnimalInput animalInput)
        {
            Animal animalAtualizar = _mapper.Map<Animal>(animalInput);

            Animal animalAtualizado = _repository.Atualizar(animalAtualizar);

            if (animalAtualizado == null)
            {
                _notificator.Add("Não foi possível atualizar o animal");
                return null;
            }

            AnimalOutput animalOutput = _mapper.Map<AnimalOutput>(animalAtualizado);

            return animalOutput;
        }

        public bool Excluir(int id)
        {
            Animal animalExcluir = _repository.ObterPorId(id);

            if (animalExcluir == null)
            {
                _notificator.Add("Animal foi não localizado para exclusão");

                return false;
            }

            _repository.Remover(animalExcluir.Id);

            return true;
        }

        public AnimalOutput ObterPorId(int id)
        {
            Animal aninmalAchado = _repository.ObterPorId(id);

            if (aninmalAchado == null)
            {
                _notificator.Add("Animal não foi  localizado");

                return null;
            }

            AnimalOutput animalOutput = _mapper.Map<AnimalOutput>(aninmalAchado);

            return animalOutput;
        }

        
    }
}
