using BlogManagement.Application.Dto.ArticleCategories;
using MediatR;

namespace BlogManagement.Application.Features.ArticleCategories.Requests.Queries;

public class DetailsArticleCategoryRequestQuery : IRequest<DetailsArticleCategoryDto>
{
    public long Id { get; set; }
}
