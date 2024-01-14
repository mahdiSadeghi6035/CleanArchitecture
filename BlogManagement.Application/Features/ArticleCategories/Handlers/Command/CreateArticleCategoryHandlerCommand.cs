using AutoMapper;
using BlogManagement.Application.Common.Features;
using BlogManagement.Application.Contracts.Persistence;
using BlogManagement.Application.Dto.ArticleCategories.Validations;
using BlogManagement.Application.Features.ArticleCategories.Requests.Command;
using BlogManagement.Domain.Entities.ArticleCategories;
using MediatR;

namespace BlogManagement.Application.Features.ArticleCategories.Handlers.Command;

public class CreateArticleCategoryHandlerCommand : IRequestHandler<CreateArticleCategoryRequestCommand, OperationResult>
{

    private readonly IArticleCategoryRepository _articleCategoryRepository;
    private readonly IMapper _mapper;

    public CreateArticleCategoryHandlerCommand(IArticleCategoryRepository articleCategoryRepository, IMapper mapper)
    {
        _articleCategoryRepository = articleCategoryRepository;
        _mapper = mapper;
    }

    public async Task<OperationResult> Handle(CreateArticleCategoryRequestCommand request, CancellationToken cancellationToken)
    {


        var validation = new CreateArticleCategoryDtoValidation();
        var validationResult = await validation.ValidateAsync(request.CreateArticleCategoryDto);

        if (!validationResult.IsValid)
        {
            return OperationResult.Failed(validationResult.Errors[0].ErrorMessage);
        }

        var articleCategory = _mapper.Map<ArticleCategory>(request.CreateArticleCategoryDto);

        await _articleCategoryRepository.Add(articleCategory);
        await _articleCategoryRepository.SaveChanges();

        return OperationResult.Succeeded();
    }
}
