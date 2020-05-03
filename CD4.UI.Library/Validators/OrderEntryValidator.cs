using CD4.UI.Library.ViewModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD4.UI.Library.Validators
{
    public class OrderEntryValidator: AbstractValidator<OrderEntryViewModel>
    {
        public OrderEntryValidator()
        {
            RuleFor(ar => ar.Cin)
                .Must(BeAValidCin).WithMessage("Invalid CIN.");
        }

        protected bool BeAValidCin(string cin)
        {
            return false;
        }
    }
}
