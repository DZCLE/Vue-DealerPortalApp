using Boilerplate.Controllers.Requests;
using Boilerplate.Controllers.Responses;
using System.Threading;

namespace Boilerplate.Controllers.Handlers
{
    /// <summary>
    /// The user session handler interface.
    /// </summary>
    public interface IUserSessionHandler
    {
        #region Public Methods

        /// <summary>
        /// Gets the user session information asynchronously.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        UserSessionResponse LoadUserSession(UserSessionRequest command, CancellationToken cancellationToken);

        #endregion Public Methods
    }
}