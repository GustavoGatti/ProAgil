using AutoMapper;
using ProAgil.Domain;
using ProAgil.Domain.Identity;
using ProAgil.WebApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProAgil.WebApi.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Evento, EventoDto>().ForMember(dest => dest.palestrante, opt =>
            {
                opt.MapFrom(src => src.palestranteEventos.Select(x => x.palestrante).ToList());
            }).ReverseMap();
            CreateMap<Palestrante, PalestranteDto>().ForMember(dest => dest.Eventos, opt =>
            {
                opt.MapFrom(src => src.palestranteEventos.Select(x => x.evento).ToList());
            }).ReverseMap();
            CreateMap<Lote, LoteDto>().ReverseMap();
            CreateMap<RedeSocial, RedeSocialDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
        }
    }
}
