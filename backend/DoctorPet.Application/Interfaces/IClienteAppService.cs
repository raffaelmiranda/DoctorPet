using DoctorPet.Application.Model;
using DoctorPet.Application.Model.Input;
using DoctorPet.Application.Model.Output;

namespace DoctorPet.Application.Interfaces
{
    public interface IClienteAppService
    {
        ClienteOutput Salvar(CriarClienteInput clienteInput);

        ClienteOutput Atualizar(AtualizarClienteInput clienteInput);

        bool Excluir(int id);

        ClienteOutput ObterPorId(int id);
    }
}
