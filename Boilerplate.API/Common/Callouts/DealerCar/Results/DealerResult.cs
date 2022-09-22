using Boilerplate.Models.DealerCar;

namespace Boilerplate.Callouts.DealerCar.Results
{
    /// <summary>
    /// The dealer result.
    /// </summary>
    public sealed class DealerResult
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the dealer identifier.
        /// </summary>
        /// <value>
        /// The dealer identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the dealer name.
        /// </summary>
        /// <value>
        /// The dealer name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the dealer AKA name
        /// </summary>
        /// <value>
        /// The dealer AKA name
        /// </value>
        public string DealerNameAka { get; set; }

        /// <summary>
        /// Gets or sets the mailing address.
        /// </summary>
        /// <value>
        /// The mailing address.
        /// </value>
        public Address MailingAddress { get; set; }

        /// <summary>
        /// Gets or sets the street address.
        /// </summary>
        /// <value>
        /// The street address.
        /// </value>
        public Address StreetAddress { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>
        /// The phone.
        /// </value>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the fax.
        /// </summary>
        /// <value>
        /// The fax.
        /// </value>
        public string Fax { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the website.
        /// </summary>
        /// <value>
        /// The website.
        /// </value>
        public string Website { get; set; }

        #endregion Public Properties
    }
}