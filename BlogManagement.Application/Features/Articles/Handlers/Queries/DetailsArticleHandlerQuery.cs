using AutoMapper;
using BlogManagement.Application.Contracts.Persistence;
using BlogManagement.Application.Dto.Articles;
using BlogManagement.Application.Features.Articles.Requests.Queries;
using MediatR;

namespace BlogManagement.Application.Features.Articles.Handlers.Queries;

public class DetailsArticleHandlerQuery : IRequestHandler<DetailsArticleRequestQuery, DetailsArticleDto>
{
    private readonly IArticleRepository _articleRepository;
    private readonly IMapper _mapper;

    public DetailsArticleHandlerQuery(IArticleRepository articleRepository, IMapper mapper)
    {
        _articleRepository = articleRepository;
        _mapper = mapper;
    }

    public async Task<DetailsArticleDto> Handle(DetailsArticleRequestQuery request, CancellationToken cancellationToken)
    {
        var article = await _articleRepository.Get(request.Id);

        if (article is null) return null;

        var mapperArticle = _mapper.Map<DetailsArticleDto>(article);

        return mapperArticle;
    }
}
