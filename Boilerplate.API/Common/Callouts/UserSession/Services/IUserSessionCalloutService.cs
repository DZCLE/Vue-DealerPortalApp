using Boilerplate.Callouts.UserSession.Contexts;
using Boilerplate.Callouts.UserSession.Results;
using System.Threading;
using System.Threading.Tasks;

namespace Boilerplate.Callouts.UserSession.Services
{
    /// <summary>
    /// The user session callout service interface.
    /// </summary>
    public interface IUserSessionCalloutService
    {
        #region Public Methods

        /// <summary>
        /// Loads user session data.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="cancellationToken">The context.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> containing <see cref="IProcessResult{T}"/>
        /// containing a <see cref="int"/>.
        /// </returns>
        UserSessionResult GetUserSession(UserSessionContext context, CancellationToken cancellationToken);

        #endregion Public Methods
    }
}