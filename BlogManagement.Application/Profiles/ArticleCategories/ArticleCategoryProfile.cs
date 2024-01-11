using AutoMapper;
using BlogManagement.Application.Dto.ArticleCategories;
using BlogManagement.Domain.Entities.ArticleCategories;

namespace BlogManagement.Application.Profiles.ArticleCategories;

public class ArticleCategoryProfile : Profile
{
    public ArticleCategoryProfile()
    {
        CreateMap<ArticleCategory, ListArticleCategoryDto>().ReverseMap();
        CreateMap<ArticleCategory, CreateArticleCategoryDto>().ReverseMap();
        CreateMap<ArticleCategory, EditArticleCategoryDto>().ReverseMap();
        CreateMap<ArticleCategory, DetailsArticleCategoryDto>().ReverseMap();
    }
}
