using AutoMapper;
using BE_Ophelia.Models.Dto;

namespace BE_Ophelia.Models.Profiles
{
    public class FacturaProfile:Profile
    {
        public FacturaProfile()
        {
            CreateMap<Factura, FacturaDto>();
            CreateMap<FacturaDto, Factura>();
        }
    }
}
