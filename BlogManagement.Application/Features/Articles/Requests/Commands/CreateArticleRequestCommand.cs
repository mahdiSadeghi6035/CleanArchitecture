using BlogManagement.Application.Common.Features;
using BlogManagement.Application.Dto.Articles;
using MediatR;

namespace BlogManagement.Application.Features.Articles.Requests.Commands;

public class CreateArticleRequestCommand : IRequest<OperationResult>
{
    public CreateArticleDto CreateArticleDto{ get; set; }
}
