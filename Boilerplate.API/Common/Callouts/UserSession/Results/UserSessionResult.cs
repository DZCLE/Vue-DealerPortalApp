namespace Boilerplate.Callouts.UserSession.Results
{
    /// <summary>
    /// The user session result.
    /// </summary>
    public sealed class UserSessionResult
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the dealer identifier.
        /// </summary>
        /// <value>The dealer identifier.</value>
        public int DealerId { get; set; }

        /// <summary>
        /// Gets or sets the login ID.
        /// </summary>
        /// <value>The login ID.</value>
        public string LoginId { get; set; }

        #endregion Public Properties
    }
}