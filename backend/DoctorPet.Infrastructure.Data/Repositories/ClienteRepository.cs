using DoctorPet.Domain.Entities;
using DoctorPet.Domain.Interfaces.Repositories;
using DoctorPet.Infrastructure.Data.Context;

namespace DoctorPet.Infrastructure.Data.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(DoctorPetContext context) : base(context)
        {

        }
    }
}
