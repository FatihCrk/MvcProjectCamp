using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.FluentValidation
{
   public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori İsmi Alanı boş geçilemez.");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori Açıklaması boş geçilemez.");
            RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("Kategori ismi 2 karakterden uzun olmalıdır.");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Kategori ismi 20 karakterden uzun olmamalı.");
            
        }
    }
}
