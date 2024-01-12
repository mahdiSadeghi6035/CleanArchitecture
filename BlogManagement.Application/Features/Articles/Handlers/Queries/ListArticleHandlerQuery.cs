using AutoMapper;
using BlogManagement.Application.Contracts.Persistence;
using BlogManagement.Application.Dto.Articles;
using BlogManagement.Application.Features.Articles.Requests.Queries;
using MediatR;

namespace BlogManagement.Application.Features.Articles.Handlers.Queries;

public class ListArticleHandlerQuery : IRequestHandler<ListArticleRequestQuery, List<ListArticleDto>>
{
    private readonly IArticleRepository _articleRepository;
    private readonly IMapper _mapper;

    public ListArticleHandlerQuery(IArticleRepository articleRepository, IMapper mapper)
    {
        _articleRepository = articleRepository;
        _mapper = mapper;
    }

    public async Task<List<ListArticleDto>> Handle(ListArticleRequestQuery request, CancellationToken cancellationToken)
    {
        var articles = await _articleRepository.GetAllWithArticleCategory();

        var mapperArticles = _mapper.Map<List<ListArticleDto>>(articles);

        return mapperArticles;
    }
}
