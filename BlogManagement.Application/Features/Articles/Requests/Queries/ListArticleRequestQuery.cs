using BlogManagement.Application.Dto.Articles;
using MediatR;

namespace BlogManagement.Application.Features.Articles.Requests.Queries;

public class ListArticleRequestQuery : IRequest<List<ListArticleDto>>
{
}
