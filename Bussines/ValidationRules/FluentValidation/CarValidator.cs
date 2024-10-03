using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
          
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);

            RuleFor(c => c.ModelYear).NotEmpty();
          
            RuleFor(c => c.CarDescription).NotEmpty();
            RuleFor(c => c.CarDescription).MinimumLength(5);
           
            RuleFor(c => c.BrandId).NotEmpty();

            RuleFor(c => c.ColorId).NotEmpty();
        }
    }
}
