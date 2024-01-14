using AutoMapper;
using BlogManagement.Application.Common.Features;
using BlogManagement.Application.Contracts.Persistence;
using BlogManagement.Application.Dto.Articles.Validations;
using BlogManagement.Application.Features.Articles.Requests.Commands;
using BlogManagement.Domain.Entities.Articles;
using MediatR;

namespace BlogManagement.Application.Features.Articles.Handlers.Commands;

public class EditArticleHandlerCommand : IRequestHandler<EditArticleRequestCommand, OperationResult>
{
    private readonly IArticleRepository _articleRepository;
    private readonly IMapper _mapper;

    public EditArticleHandlerCommand(IArticleRepository articleRepository, IMapper mapper)
    {
        _articleRepository = articleRepository;
        _mapper = mapper;
    }
    public async Task<OperationResult> Handle(EditArticleRequestCommand request, CancellationToken cancellationToken)
    {
        var validation = new EditArticleDtoValidation();
        var validationResult = await validation.ValidateAsync(request.EditArticleDto);
        if (!validationResult.IsValid)
            return OperationResult.Failed(validationResult.Errors[0].ErrorMessage);

        if (await _articleRepository.Exist(x => x.Title == request.EditArticleDto.Title && x.Id != request.EditArticleDto.Id))
            return OperationResult.Failed(ApplicationMessages.DuplicatedRecord);

        var article = _mapper.Map<Article>(request.EditArticleDto);

        article = await _articleRepository.Update(article);
        await _articleRepository.SaveChanges();

        return OperationResult.Succeeded();
    }
}
