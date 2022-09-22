namespace Boilerplate.Controllers.Requests
{
    /// <summary>
    /// Request to load dealer login information.
    /// </summary>
    public sealed class UserSessionRequest
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the login ID.
        /// </summary>
        /// <value>
        /// The login ID.
        /// </value>
        public string LoginId { get; set; }

        #endregion Public Properties
    }
}