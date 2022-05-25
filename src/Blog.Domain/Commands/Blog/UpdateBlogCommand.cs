﻿using Blog.Domain.Validations.Command.Blog;

namespace Blog.Domain.Commands.Blog;

public class UpdateBlogCommand : BlogCommand<bool>
{
    public UpdateBlogCommand(Guid id, Guid authorId, string blogTitle, string summary, string description,
        string imageFile, string readTime, List<Guid> tags, List<Guid> categories)
    {
        Id = id;
        AuthorId = authorId;
        BlogTitle = blogTitle;
        Summary = summary;
        Description = description;
        ImageFile = imageFile;
        ReadTime = readTime;
        Tags = tags;
        Categories = categories;
    }

    public override bool IsValid()
    {
        ValidationResult = new UpdateBlogCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}