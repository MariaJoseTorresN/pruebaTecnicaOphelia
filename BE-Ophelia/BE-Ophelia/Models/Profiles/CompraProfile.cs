using AutoMapper;
using BE_Ophelia.Models.Dto;

namespace BE_Ophelia.Models.Profiles
{
    public class CompraProfile:Profile
    {
        public CompraProfile()
        {
            CreateMap<Compra, CompraDto>();
            CreateMap<CompraDto, Compra>();
        }
    }
}
