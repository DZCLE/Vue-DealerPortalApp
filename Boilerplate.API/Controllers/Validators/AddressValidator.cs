using Boilerplate.Common;
using Boilerplate.Common.Enumerations;
using Boilerplate.Models.DealerCar;
using FluentValidation;
using System;

namespace Boilerplate.Controllers.Validators
{
    /// <summary>
    /// The address validator.
    /// </summary>
    /// <seealso cref="AbstractValidator{Address}" />
    public class AddressValidator
        : AbstractValidator<Address>
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressValidator"/> class.
        /// </summary>
        public AddressValidator(string Type)
        {
            const string isRequiredText = "may not be empty";
            const string isValidText = "Please enter a valid";

            RuleFor(req => req.Street)
                .NotEmpty()
                .WithMessage($"{Type} Street {isRequiredText}");

            // Allow:
            // i.	any whitespace
            // ii.	any digits 1-9
            // iii.	any lowercase or capital letters a-z
            // iv.	pound (#)
            // v.	hyphen (-)
            // vi.	forward slash (/)
            // vii.	ampersand (&)
            // Allow Alow: comma(,), period(.)
            RuleFor(req => req.Street)
               .Matches(Constants.Regex.Street)
               .WithMessage($"{isValidText} {Type} Street")
               .When(req => !string.IsNullOrWhiteSpace(req.Street));

            RuleFor(req => req.City)
                .NotEmpty()
                .WithMessage($"{Type} City {isRequiredText}");

            // Allow: letters and hyphen (-)
            RuleFor(req => req.City)
              .Matches(Constants.Regex.City)
              .WithMessage($"{isValidText} {Type} City")
              .When(req => !string.IsNullOrWhiteSpace(req.City));

            RuleFor(req => req.State)
                .NotEmpty()
                .WithMessage($"{Type} State {isRequiredText}");

            RuleFor(req => req.State)
                .Must(x => Enum.TryParse(x, out StateAbbreviation state))
                .WithMessage($"Please enter a valid {Type} State")
                .When(req => !string.IsNullOrWhiteSpace(req.State));

            RuleFor(req => req.Zip)
                .NotEmpty()
                .WithMessage($"{Type} Zip Code {isRequiredText}");

            RuleFor(req => req.Zip)
                .Matches(Constants.Regex.Numeric)
                .WithMessage($"Please enter a valid {Type} Zip Code")
                .When(req => !string.IsNullOrWhiteSpace(req.Zip) && req.Zip.Length == 5);

            RuleFor(req => req.Zip)
                .Length(5)
                .WithMessage($"{Type} Zip Code has to be 5 digits")
                .When(req => !string.IsNullOrWhiteSpace(req.Zip));
        }

        #endregion Public Constructors
    }
}