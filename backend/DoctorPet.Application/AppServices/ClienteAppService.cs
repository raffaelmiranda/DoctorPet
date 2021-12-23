using AutoMapper;
using DoctorPet.Application.Interfaces;
using DoctorPet.Application.Model;
using DoctorPet.Application.Model.Input;
using DoctorPet.Application.Model.Output;
using DoctorPet.Domain.Core.Notifications;
using DoctorPet.Domain.Entities;
using DoctorPet.Domain.Interfaces.Repositories;

namespace DoctorPet.Application.AppServices
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteRepository _repository;
        private readonly INotificator _notificator;
        private readonly IMapper _mapper;

        public ClienteAppService(
            IClienteRepository repository,
            INotificator notificator,
            IMapper mapper)
        {
            _repository = repository;
            _notificator = notificator;
            _mapper = mapper;
        }

        public ClienteOutput Salvar(CriarClienteInput clienteInput)
        {
            Cliente clienteSalvar = _mapper.Map<Cliente>(clienteInput);

            if (!clienteSalvar.CPFValido())
            {
                _notificator.Add("CPF inválido");
                return null;
            }

            Cliente clienteSalvo = _repository.Salvar(clienteSalvar);

            if (clienteSalvo == null)
            {
                _notificator.Add("Não possível salvar o cliente");
                return null;
            }

            ClienteOutput clienteOutput = _mapper.Map<ClienteOutput>(clienteSalvo);

            return clienteOutput;
        }

        public ClienteOutput Atualizar(AtualizarClienteInput clienteInput)
        {

            Cliente clienteAtualizar = _mapper.Map<Cliente>(clienteInput);

            if (!clienteAtualizar.CPFValido())
            {
                _notificator.Add("CPF inválido");
                return null;
            }

            Cliente clienteAtualizado = _repository.Atualizar(clienteAtualizar);

            if (clienteAtualizado == null)
            {
                _notificator.Add("Não foi possível atualizar o cliente");
                return null;
            }

            ClienteOutput clienteOutput = _mapper.Map<ClienteOutput>(clienteAtualizado);

            return clienteOutput;
        }

        public bool Excluir(int id)
        {
            Cliente clienteExcluir = _repository.ObterPorId(id);

            if (clienteExcluir == null)
            {
                _notificator.Add("Cliente foi não localizado para exclusão");
                
                return false;
            }
                
            _repository.Remover(clienteExcluir.Id);

            return true;
        }

        public ClienteOutput ObterPorId(int id)
        {
            Cliente clienteAchado = _repository.ObterPorId(id);

            if (clienteAchado == null)
            {
                _notificator.Add("Cliente foi não localizado");

                return null;
            }

            ClienteOutput clienteOutput = _mapper.Map<ClienteOutput>(clienteAchado);

            return clienteOutput;

        }
    }
}
