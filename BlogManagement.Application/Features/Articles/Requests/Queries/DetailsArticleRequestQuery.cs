using BlogManagement.Application.Dto.Articles;
using MediatR;

namespace BlogManagement.Application.Features.Articles.Requests.Queries;

public class DetailsArticleRequestQuery : IRequest<DetailsArticleDto>
{
    public long Id { get; set; }
}