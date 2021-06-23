using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.FluentValidation
{
    public class WriterValidator : AbstractValidator<Writer>
    {

        public WriterValidator()
        {
            RuleFor(x => x.WriterId).NotEmpty().WithMessage("Yazar Id boş geçilemez.");
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar ismi boş geçilemez.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Yazarın adı en az 2 karakter olmalıdır.");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazarın soyadı boş geçilemez.");
            RuleFor(x => x.WriterSurName).MinimumLength(2).WithMessage("Yazar soyadı 2 karakterden uzun olmalıdır.");
            RuleFor(x => x.WriterSurName).MaximumLength(20).WithMessage("Yazay soyadı 20 karakterden uzun olmamalı.");
           // RuleFor(x => x.WriterName).Custom(harfBul("a").WithMessage($"Yazar ismi 'a' harfi içermelidir.");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar unvanı boş geçilemez.");

        }
    }
}
