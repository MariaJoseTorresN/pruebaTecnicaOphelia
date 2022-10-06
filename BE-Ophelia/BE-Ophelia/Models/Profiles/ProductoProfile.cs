using AutoMapper;
using BE_Ophelia.Models.Dto;

namespace BE_Ophelia.Models.Profiles
{
    public class ProductoProfile:Profile
    {
        public ProductoProfile()
        {
            CreateMap<Producto, ProductoDto>();
            CreateMap<ProductoDto, Producto>();
        }
    }
}
