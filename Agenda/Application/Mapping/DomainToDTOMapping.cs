using Agenda.Domain.DTOs;
using Agenda.Domain.Model;
using AutoMapper;

namespace Agenda.Application.Mapping
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        {
            CreateMap<UsuarioModel, UsuarioDTO>();
        }
    }
}
