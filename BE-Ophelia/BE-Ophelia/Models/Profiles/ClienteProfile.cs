using AutoMapper;
using BE_Ophelia.Models.Dto;

namespace BE_Ophelia.Models.Profiles
{
    public class ClienteProfile: Profile
    {
        public ClienteProfile()
        {
            CreateMap<Cliente, ClienteDto>();
            CreateMap<ClienteDto, Cliente>();
        }
    }
}
