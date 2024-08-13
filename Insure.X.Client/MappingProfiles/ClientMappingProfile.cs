using AutoMapper;
using Insure.X.Client.Models;
using Insure.X.Resource.Database.Entities.Client;

namespace Insure.X.Client.MappingProfiles;

public class ClientMappingProfile : Profile
{
    public ClientMappingProfile()
    {
        CreateMap<ClientEntity, ClientDto>();
    }
}
