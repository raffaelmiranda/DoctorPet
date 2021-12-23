using DoctorPet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPet.Infrastructure.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoAnimal>().HasData(new TipoAnimal(1, "Cães"));
            modelBuilder.Entity<TipoAnimal>().HasData(new TipoAnimal(2, "Gatos"));
            modelBuilder.Entity<TipoAnimal>().HasData(new TipoAnimal(3, "Hamsters"));
        }
    }
}
