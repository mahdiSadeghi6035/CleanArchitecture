using AutoMapper;
using BlogManagement.Application.Dto.Articles;
using BlogManagement.Domain.Entities.Articles;

namespace BlogManagement.Application.Profiles.Articles;

public class ArticleProfile : Profile
{
    public ArticleProfile()
    {
        CreateMap<Article, ListArticleDto>()
            .ForMember(x => x.ArticleCategoryTitle, i => i.MapFrom(ac => ac.ArticleCategory.Title))
            .ReverseMap();
        CreateMap<Article, DetailsArticleDto>().ReverseMap();
        CreateMap<Article, CreateArticleDto>().ReverseMap();
        CreateMap<Article, EditArticleDto>().ReverseMap();
    }
}
