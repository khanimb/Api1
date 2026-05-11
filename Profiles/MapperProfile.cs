using Api1.Dtos.Categories;
using Api1.Dtos.Products;
using Api1.Extensions;
using Api1.Models;
using AutoMapper;

namespace Api1.Profiles
{
    public class MapperProfile:Profile
    {
        public MapperProfile(HttpContextAccessor httpContextAccessor)
        {
            var httpContext = httpContextAccessor.HttpContext;
            var uriBuilder = new UriBuilder
            {
                Scheme = httpContext.Request.Scheme,
                Host = httpContext.Request.Host.Host,
                Port = httpContext.Request.Host.Port ?? 80
            };
            var url = uriBuilder.Uri.AbsoluteUri;


            CreateMap<CategoryCreateDto, Category>()
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Photo.SaveFile("wwwroot/images")));
            CreateMap<Category, CategoryReturnDto>()
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => url + "images/" + src.ImageUrl));
            CreateMap<Category, CategoryUpdateDto>();
            CreateMap<Product, ProductInCategoryReturnDto>();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<Product, ProductReturnDto>();
            CreateMap<Category, ProductInCategoryReturnDto>();
        }
    }
}
