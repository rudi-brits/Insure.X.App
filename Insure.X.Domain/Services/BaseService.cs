using AutoMapper;

namespace Insure.X.Domain.Services;

public abstract class BaseService
{
    protected IMapper? _mapper;

    protected void SetupMapper<TMappingProfile>() where TMappingProfile : Profile, new()
    {
        var configuration = new MapperConfiguration(config =>
        {
            config.AddProfile<TMappingProfile>();
        });

        _mapper = configuration.CreateMapper();
    }
}
