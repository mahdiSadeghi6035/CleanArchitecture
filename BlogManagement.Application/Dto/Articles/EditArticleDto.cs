﻿using BlogManagement.Application.Common.Dto;

namespace BlogManagement.Application.Dto.Articles;

public class EditArticleDto : BaseDto<long>, IArticleDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public long ArticleCategoryId { get; set; }
}