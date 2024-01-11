using BlogManagement.Application.Common.Features;
using BlogManagement.Application.Dto.ArticleCategories;
using MediatR;

namespace BlogManagement.Application.Features.ArticleCategories.Requests.Command;

public class EditArticleCategoryRequestCommand : IRequest<OperationResult>
{
    public EditArticleCategoryDto EditArticleCategoryDto{ get; set; }
}
