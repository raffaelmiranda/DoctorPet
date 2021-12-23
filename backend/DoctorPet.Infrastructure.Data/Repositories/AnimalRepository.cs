using DoctorPet.Domain.Entities;
using DoctorPet.Domain.Interfaces.Repositories;
using DoctorPet.Infrastructure.Data.Context;

namespace DoctorPet.Infrastructure.Data.Repositories
{
    public class AnimalRepository : BaseRepository<Animal>, IAnimalRepository
    {
        public AnimalRepository(DoctorPetContext context) : base(context)
        {

        }
    }
}
