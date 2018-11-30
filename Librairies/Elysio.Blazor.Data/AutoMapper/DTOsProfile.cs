using AutoMapper;
using Elysio.Blazor.Data.Entities;
using Elysio.Blazor.DTOs.DTOs;

namespace Elysio.Blazor.Data.AutoMapper
{
    public class DTOsProfile : Profile
    {
        public DTOsProfile()
        {
            RegisterArticle();
        }
        private void RegisterArticle()
        {
            CreateMap<Article, ArticleDTO>()
                .ReverseMap();
        }
    }
}
