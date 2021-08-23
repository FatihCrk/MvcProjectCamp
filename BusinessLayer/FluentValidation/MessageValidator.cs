using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.FluentValidation
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı mail adresi boş geçilemez.");


            RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("Girilen mail adresiniz geçerli değil.");


            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu alanı boş geçilemez.");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Mesajınızın konusu 50 karakterden uzun olmamalı.");

            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj boş geçilemez.");
            RuleFor(x => x.MessageContent).MinimumLength(2).WithMessage("Mesajınız en az 2 karakter olmalıdır.");
            RuleFor(x => x.MessageContent).MaximumLength(100).WithMessage("Mesajınız 300 karakterden uzun olmamalı.");
        }
    }
}
