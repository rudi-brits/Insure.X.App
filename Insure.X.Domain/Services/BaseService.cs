using AutoMapper;

namespace Insure.X.Domain.Services;

/// <summary>
/// BaseService
/// </summary>
public abstract class BaseService
{
    /// <summary>
    /// IMapper
    /// </summary>
    protected IMapper? _mapper;

    /// <summary>
    /// SetupMapper
    /// </summary>
    /// <typeparam name="TMappingProfile"></typeparam>
    protected void SetupMapper<TMappingProfile>() where TMappingProfile : Profile, new()
    {
        var configuration = new MapperConfiguration(config =>
        {
            config.AddProfile<TMappingProfile>();
        });

        _mapper = configuration.CreateMapper();
    }
}
