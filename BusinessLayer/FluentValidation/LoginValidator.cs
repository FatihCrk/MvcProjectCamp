using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.FluentValidation
{
    public class LoginValidator : AbstractValidator<Admin>
    {
        public LoginValidator()
        {
            RuleFor(x => x.AdminUserName).NotEmpty().WithMessage("Kullanıcı adınız boş geçilemez.");

            RuleFor(x => x.AdminPassword).NotEmpty().WithMessage("Şifre adresi boş geçilemez.");


            
            RuleFor(x => x.AdminUserName).MaximumLength(50).WithMessage("Kullanıcı Adı 50 karakterden uzun olmamalı.");

        
        }
    }
}
