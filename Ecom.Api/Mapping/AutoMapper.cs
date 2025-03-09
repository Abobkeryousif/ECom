using AutoMapper;
using Ecom.Core.DTO;
using Ecom.Core.Entities.Product;

namespace Ecom.Api.Mapping
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<CategoryDto,Categories>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap().
                ForMember(x => x.CategoryName, op => op.MapFrom(src =>src.Categories.Name));
            CreateMap<Photo, PhotoDto>().ReverseMap();
            CreateMap<AddProductDto , Product>().ForMember(x=>x.photos , o=>o.Ignore())
                .ReverseMap();
            CreateMap<UpdateProductDto, Product>().ForMember(x=> x.photos , o=> o.Ignore()).ReverseMap();
                
        }
    }
}
