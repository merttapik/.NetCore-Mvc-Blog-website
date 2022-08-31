using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidation: AbstractValidator<Blog>
    {
        public BlogValidation()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Writer name can not be empty")
                         .MinimumLength(2).WithMessage("Writer name can not be under 2 word")
                         .MaximumLength(50).WithMessage("Writer name can not be upper  50 word");
            RuleFor(x => x.Category).NotEmpty().WithMessage("You should choose a category");
            RuleFor(X => X.BlogImage).NotEmpty().WithMessage("Image have to be uploaded");
        }
    }
}
