using Boilerplate.Models.DealerCar;
namespace Boilerplate.Producers.Contexts
{
    /// <summary>
    /// The dealer information context.
    /// </summary>
    public sealed class DealerInformationContext
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
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the aka name.
        /// </summary>
        /// <value>
        /// The aka name.
        /// </value>
        public string AkaName { get; set; }

        /// <summary>
        /// Gets or sets the dealer mailing address.
        /// </summary>
        /// <value>
        /// The dealer mailing address.
        /// </value>
        public Address MailingAddress { get; set; }

        /// <summary>
        /// Gets or sets the dealer street address.
        /// </summary>
        /// <value>
        /// The dealer street address.
        /// </value>
        public Address StreetAddress { get; set; }

        /// <summary>
        /// Gets or sets the dealer phone.
        /// </summary>
        /// <value>
        /// The dealer phone.
        /// </value>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the dealer fax.
        /// </summary>
        /// <value>
        /// The dealer fax.
        /// </value>
        public string Fax { get; set; }

        /// <summary>
        /// Gets or sets the dealer email.
        /// </summary>
        /// <value>
        /// The dealer email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the dealer website.
        /// </summary>
        /// <value>
        /// The dealer website.
        /// </value>
        public string Website { get; set; }

        #endregion Public Properties
    }
}