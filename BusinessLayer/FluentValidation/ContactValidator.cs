using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.FluentValidation
{
   public class ContactValidator: AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adınız boş geçilemez.");

            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail adresi boş geçilemez.");


            RuleFor(x => x.Subject).NotEmpty().WithMessage("Mesajınızın konusu geçilemez.");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Mesajınızın konusu 50 karakterden uzun olmamalı.");

            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj boş geçilemez.");
            RuleFor(x => x.Message).MinimumLength(2).WithMessage("Mesajınız en az 2 karakter olmalıdır.");
            RuleFor(x => x.Message).MaximumLength(300).WithMessage("Mesajınız 300 karakterden uzun olmamalı.");
        }
    }
}
