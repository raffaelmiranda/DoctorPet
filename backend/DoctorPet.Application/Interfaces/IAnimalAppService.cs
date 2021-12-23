using DoctorPet.Application.Model;
using DoctorPet.Application.Model.Input;
using DoctorPet.Application.Model.Output;

namespace DoctorPet.Application.Interfaces
{
    public interface IAnimalAppService
    {
        AnimalOutput Salvar(CriarAnimalInput clienteInput);

        AnimalOutput Atualizar(AtualizarAnimalInput clienteInput);

        bool Excluir(int id);

        AnimalOutput ObterPorId(int id);
    }
}
