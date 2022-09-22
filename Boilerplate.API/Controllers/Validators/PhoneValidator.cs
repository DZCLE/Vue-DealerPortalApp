using Boilerplate.Common;
using FluentValidation;

namespace Boilerplate.Controllers.Validators
{
    /// <summary>
    /// The phone validator.
    /// </summary>
    /// <seealso cref="AbstractValidator{String}" />
    public class PhoneValidator
        : AbstractValidator<string>
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneValidator"/> class.
        /// </summary>
        public PhoneValidator(string Type)
        {

            RuleFor(req => req)
                .Matches(Constants.Regex.Numeric)
                .WithMessage($"Please enter a valid {Type} Number");

            RuleFor(req => req)
                .Length(10)
                .WithMessage($"{Type} Number is too short");
        }

        #endregion Public Constructors
    }
}