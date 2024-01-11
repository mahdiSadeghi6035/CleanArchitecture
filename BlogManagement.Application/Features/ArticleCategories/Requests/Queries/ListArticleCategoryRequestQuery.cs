using BlogManagement.Application.Dto.ArticleCategories;
using MediatR;

namespace BlogManagement.Application.Features.ArticleCategories.Requests.Queries;

public class ListArticleCategoryRequestQuery : IRequest<List<ListArticleCategoryDto>>
{

}
