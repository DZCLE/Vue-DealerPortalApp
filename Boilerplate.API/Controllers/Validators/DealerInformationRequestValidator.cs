using Boilerplate.Controllers.Requests;
using Boilerplate.Controllers.Validators;
using FluentValidation;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Boilerplate.Validators
{
    /// <summary>
    /// The dealer information request validator.
    /// </summary>
    public class DealerInformationRequestValidator
        : AbstractValidator<DealerInformationRequest>
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DealerInformationRequestValidator"/> class.
        /// </summary>
        public DealerInformationRequestValidator()
        {
            const string requiredText = "Dealer {PropertyName} may not be empty";
            const string requiredPhoneText = "Dealer {PropertyName} Number may not be empty";
            const string validText = "Please enter a valid Dealer {PropertyName}";

            RuleFor(req => req.Name)
                .NotEmpty()
                .WithMessage(requiredText);

            RuleFor(req => req.MailingAddress)
                .SetValidator(new AddressValidator("Dealer Mailing Address"));

            RuleFor(req => req.StreetAddress)
                .SetValidator(new AddressValidator("Dealer Street Address"));

            RuleFor(req => req.Phone)
                .NotEmpty()
                .WithMessage(requiredPhoneText);

            RuleFor(req => req.Phone)
                .SetValidator(new PhoneValidator("Dealer Phone"))
                .When(req => !string.IsNullOrWhiteSpace(req.Phone));

            RuleFor(req => req.Fax)
                .SetValidator(new PhoneValidator("Dealer Fax"))
                .When(req => !string.IsNullOrWhiteSpace(req.Fax));

            RuleFor(req => req.Email)
                .NotEmpty()
                .WithMessage(requiredText);

            RuleFor(req => req.Email)
                .SetValidator(new EmailValidator("Dealer Email"))
                .When(req => !string.IsNullOrWhiteSpace(req.Email));

            Unless(req => string.IsNullOrWhiteSpace(req.Website), () =>
            {
                RuleFor(req => req.Website).Must(website =>
                {
                    // Protocol subdomain validation
                    if (!(website.StartsWith("www.", StringComparison.OrdinalIgnoreCase) || website.StartsWith("http://", StringComparison.OrdinalIgnoreCase) || website.StartsWith("https://", StringComparison.OrdinalIgnoreCase)))
                    {
                        return false;
                    }

                    // No white space
                    if (website.Any(char.IsWhiteSpace))
                    {
                        return false;
                    }

                    int startIndex = 0;
                    if (website.Contains("www.")) startIndex = website.IndexOf("www.");
                    else if (website.Contains("://")) startIndex = website.IndexOf("://") + 3;

                    string tempURL = website;
                    if (startIndex != 0)
                    {
                        tempURL = website.Substring(startIndex);
                    }

                    // There must be content in the second-level domain and top-level domain whether there is subdomain
                    // No forward slash allowed in the second-level domain whether there is subdomain
                    // top-level domain cannot start with forward slash
                    // top-level domain must have at least two characters
                    if (!(
                        (
                        website.Contains("www.")
                        && website.Split('.').Length >= 3
                        && website.Split('.')[1] != ""
                        && website.Split('.')[2] != ""
                        && !website.Split('.')[1].Contains('/')
                        && !website.Split('.')[2].StartsWith('/')
                        && website.Split('.')[2].Split('/')[0].Length >= 2
                        )
                    || (
                        !website.Contains("www.")
                        && website.Contains('.')
                        && tempURL.Split('.')[0] != ""
                        && tempURL.Split('.')[1] != ""
                        && !tempURL.Split('.')[0].Contains('/')
                        && !tempURL.Split('.')[1].StartsWith('/')
                        && tempURL.Split('.')[1].Split('/')[0].Length >= 2
                        )
                       ))
                    {
                        return false;
                    }

                    // Subdomain validation
                    string substr = website.Substring(startIndex, website.IndexOf('/') > -1 ? website.IndexOf('/') : website.Length);
                    return string.Equals(Regex.Match(substr, @"[\w.-]*").Value, substr);

                }).WithMessage(validText);
            });
        }

        #endregion Public Constructors
    }
}