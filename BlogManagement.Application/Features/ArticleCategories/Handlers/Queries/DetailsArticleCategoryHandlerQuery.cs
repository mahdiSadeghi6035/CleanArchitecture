using AutoMapper;
using BlogManagement.Application.Contracts.Persistence;
using BlogManagement.Application.Dto.ArticleCategories;
using BlogManagement.Application.Features.ArticleCategories.Requests.Queries;
using MediatR;

namespace BlogManagement.Application.Features.ArticleCategories.Handlers.Queries;

public class DetailsArticleCategoryHandlerQuery : IRequestHandler<DetailsArticleCategoryRequestQuery, DetailsArticleCategoryDto>
{
    private readonly IArticleCategoryRepository _articleCategoryRepository;
    private readonly IMapper _mapper;

    public DetailsArticleCategoryHandlerQuery(IArticleCategoryRepository articleCategoryRepository, IMapper mapper)
    {
        _articleCategoryRepository = articleCategoryRepository;
        _mapper = mapper;
    }

    public async Task<DetailsArticleCategoryDto> Handle(DetailsArticleCategoryRequestQuery request,
        CancellationToken cancellationToken)
    {
        var articleCategory = await _articleCategoryRepository.Get(request.Id);

        if (articleCategory is null) return null;

        var mapperArticleCategory = _mapper.Map<DetailsArticleCategoryDto>(articleCategory);

        return mapperArticleCategory;
    }
}
