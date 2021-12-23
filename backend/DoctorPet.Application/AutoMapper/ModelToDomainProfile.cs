using AutoMapper;
using DoctorPet.Application.Model;
using DoctorPet.Application.Model.Input;
using DoctorPet.Domain.Entities;

namespace DoctorPet.Application.AutoMapper
{
    public class ModelToDomainProfile : Profile
    {
        public ModelToDomainProfile()
        {
            CreateMap<CriarClienteInput, Cliente>()
                 .ForMember(domain => domain.Nome, map => map.MapFrom(model => model.Nome))
                 .ForMember(domain => domain.Cpf, map => map.MapFrom(model => model.Cpf));

            CreateMap<AtualizarClienteInput, Cliente>()
                .ForMember(domain => domain.Id, map => map.MapFrom(model => model.Id))
                .ForMember(domain => domain.Nome, map => map.MapFrom(model => model.Nome))
                .ForMember(domain => domain.Cpf, map => map.MapFrom(model => model.Cpf));

            CreateMap<CriarAnimalInput, Animal>()
                 .ForMember(domain => domain.ClienteId, map => map.MapFrom(model => model.ClienteId))
                 .ForMember(domain => domain.Nome, map => map.MapFrom(model => model.Nome))
                 .ForMember(domain => domain.Idade, map => map.MapFrom(model => model.Idade))
                 .ForMember(domain => domain.TipoAnimalId, map => map.MapFrom(model => model.TipoAnimalId));

            CreateMap<AtualizarAnimalInput, Animal>()
                 .ForMember(domain => domain.Id, map => map.MapFrom(model => model.Id))
                 .ForMember(domain => domain.ClienteId, map => map.MapFrom(model => model.ClienteId))
                 .ForMember(domain => domain.Nome, map => map.MapFrom(model => model.Nome))
                 .ForMember(domain => domain.Idade, map => map.MapFrom(model => model.Idade))
                 .ForMember(domain => domain.TipoAnimalId, map => map.MapFrom(model => (int)model.TipoAnimalId));

        }
    }
}
