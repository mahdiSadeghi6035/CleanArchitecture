using AutoMapper;
using BlogManagement.Application.Common.Features;
using BlogManagement.Application.Contracts.Persistence;
using BlogManagement.Application.Dto.Articles.Validations;
using BlogManagement.Application.Features.Articles.Requests.Commands;
using BlogManagement.Domain.Entities.Articles;
using MediatR;

namespace BlogManagement.Application.Features.Articles.Handlers.Commands;

public class CreateArticleHandlerCommand : IRequestHandler<CreateArticleRequestCommand, OperationResult>
{
    private readonly IArticleRepository _articleRepository;
    private readonly IMapper _mapper;

    public CreateArticleHandlerCommand(IArticleRepository articleRepository, IMapper mapper)
    {
        _articleRepository = articleRepository;
        _mapper = mapper;
    }

    public async Task<OperationResult> Handle(CreateArticleRequestCommand request, CancellationToken cancellationToken)
    {
        var validation = new CreateArticleDtoValidation();
        var validationResult = await validation.ValidateAsync(request.CreateArticleDto);
        if (!validationResult.IsValid)
            return OperationResult.Failed(validationResult.Errors[0].ErrorMessage);

        if (await _articleRepository.Exist(x => x.Title == request.CreateArticleDto.Title))
            return OperationResult.Failed(ApplicationMessages.DuplicatedRecord);

        var article =  _mapper.Map<Article>(request.CreateArticleDto);

        article = await _articleRepository.Add(article);
        await _articleRepository.SaveChanges();

        return OperationResult.Succeeded();

    }
}
