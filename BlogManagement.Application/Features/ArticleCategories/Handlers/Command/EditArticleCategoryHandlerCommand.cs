using AutoMapper;
using BlogManagement.Application.Common.Features;
using BlogManagement.Application.Contracts.Persistence;
using BlogManagement.Application.Dto.ArticleCategories.Validations;
using BlogManagement.Application.Features.ArticleCategories.Requests.Command;
using BlogManagement.Domain.Entities.ArticleCategories;
using MediatR;

namespace BlogManagement.Application.Features.ArticleCategories.Handlers.Command;

public class EditArticleCategoryHandlerCommand : IRequestHandler<EditArticleCategoryRequestCommand, OperationResult>
{
    private readonly IArticleCategoryRepository _articleCategoryRepository;
    private readonly IMapper _mapper;

    public EditArticleCategoryHandlerCommand(IArticleCategoryRepository articleCategoryRepository, IMapper mapper)
    {
        _articleCategoryRepository = articleCategoryRepository;
        _mapper = mapper;
    }

    public async Task<OperationResult> Handle(EditArticleCategoryRequestCommand request, CancellationToken cancellationToken)
    {
        var validation = new EditArticleCategoryDtoValidation();
        var validationResult = await validation.ValidateAsync(request.EditArticleCategoryDto);

        if (!validationResult.IsValid)
            return OperationResult.Failed(validationResult.Errors[0].ErrorMessage);

        var articleCategory = _mapper.Map<ArticleCategory>(request.EditArticleCategoryDto);
        
        await _articleCategoryRepository.Update(articleCategory);
        await _articleCategoryRepository.SaveChanges();

        return OperationResult.Succeeded();
    }
}
