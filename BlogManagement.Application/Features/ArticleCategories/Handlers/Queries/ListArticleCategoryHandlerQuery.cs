using AutoMapper;
using BlogManagement.Application.Contracts.Persistence;
using BlogManagement.Application.Dto.ArticleCategories;
using BlogManagement.Application.Features.ArticleCategories.Requests.Queries;
using MediatR;

namespace BlogManagement.Application.Features.ArticleCategories.Handlers.Queries;

public class ListArticleCategoryHandlerQuery : IRequestHandler<ListArticleCategoryRequestQuery, List<ListArticleCategoryDto>>
{
    private readonly IArticleCategoryRepository _articleCategoryRepository;
    private readonly IMapper _mapper;

    public ListArticleCategoryHandlerQuery(IArticleCategoryRepository articleCategoryRepository, IMapper mapper)
    {
        _articleCategoryRepository = articleCategoryRepository;
        _mapper = mapper;
    }

    public async Task<List<ListArticleCategoryDto>> Handle(ListArticleCategoryRequestQuery request, CancellationToken cancellationToken)
    {
        var articleCategory = await _articleCategoryRepository.GetAllWithArticle();

        var mapperArticleCategory = _mapper.Map<List<ListArticleCategoryDto>>(articleCategory);

        return mapperArticleCategory;
    }
}
