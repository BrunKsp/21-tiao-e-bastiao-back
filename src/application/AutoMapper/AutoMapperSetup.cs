using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace application.AutoMapper;

public class AutoMapperSetup
{
    protected AutoMapperSetup()
    { }

    public static MapperConfiguration RegisterMappings(IConfiguration config)
    {
        return new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new EntityToDtoMapper(config));
            cfg.AddProfile(new DtoToEntityMapper());
        });
    }
}