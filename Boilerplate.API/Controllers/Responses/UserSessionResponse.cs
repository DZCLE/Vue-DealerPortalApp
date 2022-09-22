namespace Boilerplate.Controllers.Responses
{
    /// <summary>
    /// Response to the DEALER login information request.
    /// </summary>
    public sealed class UserSessionResponse
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the dealer identifier.
        /// </summary>
        /// <value>The dealer identifier.</value>
        public int DealerId { get; set; }

        #endregion Public Properties
    }
}