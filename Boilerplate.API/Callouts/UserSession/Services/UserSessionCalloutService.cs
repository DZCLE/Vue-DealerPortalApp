using Boilerplate.Callouts.UserSession.Contexts;
using Boilerplate.Callouts.UserSession.Converters;
using Boilerplate.Callouts.UserSession.Results;
using Boilerplate.Common;
using System.Linq;
using System.Threading;

namespace Boilerplate.Callouts.UserSession.Services
{
    /// <inheritDoc />
    /// <seealso cref="IUserSessionCalloutService" />
    public class UserSessionCalloutService : IUserSessionCalloutService
    {
        #region Private Fields

        private readonly IUserSessionCalloutConverter _userSessionCalloutConverter;

        #endregion Private Fields

        /// <summary>
        /// Initializes a new instance of the <see cref="UserSessionCalloutService"/> class.
        /// </summary>
        /// <param name="userSessionCalloutConverter">The user session callout converter.</param>
        public UserSessionCalloutService(IUserSessionCalloutConverter userSessionCalloutConverter)
        {
            _userSessionCalloutConverter = userSessionCalloutConverter;
        }

        /// <inheritdoc/>
        public UserSessionResult GetUserSession(UserSessionContext context, CancellationToken cancellation)
        {
            var response = from initialData in Constants.AppData.UserSessionData
                           where initialData.LoginId == context.LoginId
                           select initialData;

            return _userSessionCalloutConverter.Convert(response.FirstOrDefault());
        }
    }
}