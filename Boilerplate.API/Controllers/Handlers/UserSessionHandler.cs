using Boilerplate.Callouts.UserSession.Services;
using Boilerplate.Controllers.Converters;
using Boilerplate.Controllers.Handlers;
using Boilerplate.Controllers.Requests;
using Boilerplate.Controllers.Responses;
using System.Threading;

namespace Boilerplate.UI.Controllers.Handlers
{
    /// <inheritDoc />
    public sealed class UserSessionHandler : IUserSessionHandler
    {
        #region Private Fields

        private readonly IUserSessionControllerConverter _userSessionControllerConverter;
        private readonly IUserSessionCalloutService _userSessionCalloutService;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UserSessionHandler"/> class.
        /// </summary>
        /// <param name="userSessionControllerConverter">The converter service.</param>
        /// <param name="userSessionCalloutService">The user session callout service.</param>
        public UserSessionHandler(
            IUserSessionControllerConverter userSessionControllerConverter,
            IUserSessionCalloutService userSessionCalloutService)
        {
            _userSessionControllerConverter = userSessionControllerConverter;
            _userSessionCalloutService = userSessionCalloutService;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <inheritDoc />
        public UserSessionResponse LoadUserSession(UserSessionRequest command, CancellationToken cancellationToken)
        {
            var context = _userSessionControllerConverter.Convert(command);

            var result = _userSessionCalloutService.GetUserSession(context, cancellationToken);

            return _userSessionControllerConverter.Convert(result);
        }

        #endregion Public Methods
    }
}