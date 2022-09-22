using Boilerplate.Common;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Boilerplate.Controllers.Validators
{
    /// <summary>
    /// The email validator.
    /// </summary>
    /// <seealso cref="AbstractValidator{String}" />
    public class EmailValidator
        : AbstractValidator<string>
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailValidator"/> class.
        /// </summary>
        public EmailValidator(string Type)
        {
            RuleFor(req => req).Must(email =>
            {
                string[] emailAddressParts = email.Split('@');

                if (emailAddressParts.Length < 2)
                {
                    return false;
                }

                // Local Part Validation
                char[] allowedSpecialChars = { '%', '&', '-', '_', '+' };
                LocalPartValidationResult localResult = new LocalPartValidationResult(0, false);

                foreach (char specialCharacter in allowedSpecialChars)
                {

                    if (emailAddressParts[0].StartsWith(specialCharacter) || emailAddressParts[0].EndsWith(specialCharacter))
                    {
                        localResult.StartOrEnd++;
                    }

                    for (int i = 1; i < emailAddressParts[0].Length - 1; i++)
                    {
                        if (emailAddressParts[0][i] == specialCharacter && emailAddressParts[0][i - 1] == specialCharacter)
                        {
                            localResult.Consecutive = true;
                            break;
                        }
                    }
                }

                if (emailAddressParts[0].StartsWith("'")
                || emailAddressParts[0].EndsWith('.')
                || emailAddressParts[0].Contains("..")
                || emailAddressParts[0] == ""
                || localResult.StartOrEnd > 0
                || localResult.Consecutive)
                {
                    return false;
                }

                // Domain Part Validation
                string[] invalidDomainCharacters = { "&", "..", "/", "\\", "'" };
                int invalidOccurance = 0;
                foreach (string invalidChar in invalidDomainCharacters)
                {
                    if (emailAddressParts[1].Contains(invalidChar))
                    {
                        invalidOccurance++;
                    }
                }

                if (emailAddressParts[1].EndsWith(".") || invalidOccurance > 0)
                {
                    return false;
                }

                // Top Leval Domain Validation: The part after the last period must have at least two chars
                int numberofPartsSplitByPeriod = emailAddressParts[1].Split('.').Length;
                if (emailAddressParts[1].Split('.')[numberofPartsSplitByPeriod - 1].Length < 2)
                {
                    return false;
                }

                // Regex match
                return string.Equals(Regex.Match(email, Constants.Regex.Email).Value, email);

            }).WithMessage($"Please enter a valid {Type}");
        }

        #endregion Public Constructors

        internal class LocalPartValidationResult
        {
            public int StartOrEnd { get; set; }
            public bool Consecutive { get; set; }

            public LocalPartValidationResult(int startOrEnd, bool consecutive)
            {
                StartOrEnd = startOrEnd;
                Consecutive = consecutive;
            }
        }

    }
}