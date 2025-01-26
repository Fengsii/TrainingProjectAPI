using FluentValidation;
using PelatihanKe2.Model.DTO;
using System.Text.RegularExpressions;

namespace PelatihanKe2.Validator
{
    public class ValidatorRequestCustomer : AbstractValidator<CustomerRequestDTO>
    {
       
        public ValidatorRequestCustomer()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(5).WithMessage("Name is not valid!");
            RuleFor(x => x.PhoneNumber).NotEmpty().MinimumLength(9).MaximumLength(13).Must(ValidPhoneNumber).WithMessage("PhoneNumber must be numeric!");
        }

        public bool ValidPhoneNumber(string phoneNumber)
        {
            string regexNumberOnly = @"^\d+$";
            if (Regex.IsMatch(phoneNumber, regexNumberOnly))
                return true;
            else
                return false;
        }
    }
}
