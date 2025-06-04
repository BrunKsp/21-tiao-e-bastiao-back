using application.Dtos.Usuario;
using AutoMapper;
using data.Infra.PG.Entities;

namespace application.AutoMapper;

public class DtoToEntityMapper : Profile
{
    public DtoToEntityMapper()
    {
        CreateMap<CriarUsuarioDto, UsuarioEntity>();
    }
}