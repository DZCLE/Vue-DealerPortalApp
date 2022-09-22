namespace Boilerplate.Callouts.DealerCar.Responses
{
    /// <summary>
    /// Response containing the dealer login information.
    /// </summary>
    public class UserSessionDataResponse
    {
        #region Public Properties

        /// <summary>
        /// The login identifier.
        /// </summary>
        public string LoginId { get; set; }

        /// <summary>
        /// The dealer identifier.
        /// </summary>
        public int DealerId { get; set; }

        #endregion Public Properties
    }
}