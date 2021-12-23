using DoctorPet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPet.Domain.Interfaces.Repositories
{
    public interface IAnimalRepository : IBaseRepository<Animal>
    {
    }
}
