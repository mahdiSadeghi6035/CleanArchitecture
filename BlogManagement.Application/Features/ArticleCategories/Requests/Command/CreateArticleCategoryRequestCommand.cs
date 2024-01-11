using BlogManagement.Application.Common.Features;
using BlogManagement.Application.Dto.ArticleCategories;
using MediatR;

namespace BlogManagement.Application.Features.ArticleCategories.Requests.Command
{
    public class CreateArticleCategoryRequestCommand : IRequest<OperationResult>
    {
        public CreateArticleCategoryDto CreateArticleCategoryDto { get; set; }
    }
}
