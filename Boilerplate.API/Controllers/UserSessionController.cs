using Boilerplate.Controllers.Handlers;
using Boilerplate.Controllers.Requests;
using Boilerplate.Controllers.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace Boilerplate.Controllers
{
    /// <summary>
    /// The user session controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class UserSessionController : ControllerBase
    {
        #region Private Fields

        private IUserSessionHandler _userSessionHandler;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UserSessionController"/> class.
        /// </summary>
        /// <param name="userSessionHandler">The mediator.</param>
        public UserSessionController(IUserSessionHandler userSessionHandler)
        {
            _userSessionHandler = userSessionHandler;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Loads both the user session and AMT instance information.
        /// </summary>
        /// <param name="request">The instance identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        [HttpPost("/user_session")]
        public ActionResult<UserSessionResponse> LoadUserSession(UserSessionRequest request, CancellationToken cancellationToken)
        {
            var response = _userSessionHandler.LoadUserSession(request, cancellationToken);

            return response;
        }

        #endregion Public Methods
    }
}