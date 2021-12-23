using AutoMapper;
using DoctorPet.Application.Model.Output;
using DoctorPet.Domain.Entities;

namespace DoctorPet.Application.AutoMapper
{
    public class DomainToModelProfile : Profile
    {
        public DomainToModelProfile()
        {
            CreateMap<Cliente, ClienteOutput>()
                .ForMember(model => model.Id, map => map.MapFrom(domain => domain.Id))
                .ForMember(model => model.Nome, map => map.MapFrom(domain => domain.Nome))
                .ForMember(model => model.Cpf, map => map.MapFrom(domain => domain.Cpf));

            CreateMap<Animal, AnimalOutput>()
                .ForMember(model => model.Id, map => map.MapFrom(domain => domain.Id))
                 .ForMember(model => model.ClienteId, map => map.MapFrom(domain => domain.ClienteId))
                 .ForMember(model => model.Nome, map => map.MapFrom(domain => domain.Nome))
                 .ForMember(model => model.Idade, map => map.MapFrom(domain => domain.Idade))
                 .ForMember(model => model.TipoAnimalId, map => map.MapFrom(domain => domain.TipoAnimalId));
        }
    }
}
