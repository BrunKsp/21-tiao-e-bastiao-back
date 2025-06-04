using application.Dtos.Usuario;
using AutoMapper;
using data.Infra.PG.Entities;
using Microsoft.Extensions.Configuration;

namespace application.AutoMapper;

public class EntityToDtoMapper : Profile
{
    public EntityToDtoMapper(IConfiguration config)
    {
        CreateMap<UsuarioEntity, UsuarioDto>();
    }
}