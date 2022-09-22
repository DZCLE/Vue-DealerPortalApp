using Boilerplate.Callouts.UserSession.Contexts;
using Boilerplate.Callouts.UserSession.Results;
using Boilerplate.Controllers.Converters;
using Boilerplate.Controllers.Requests;
using Boilerplate.Controllers.Responses;

namespace Biolerplate.Controllers.Converters
{
    /// <inheritDoc/>
    public sealed class UserSessionControllerConverter : IUserSessionControllerConverter
    {
        /// <inheritDoc />
        public UserSessionContext Convert(UserSessionRequest source)
        {
            return source == null
                ? null
                : new UserSessionContext
                {
                    LoginId = source.LoginId
                };
        }

        /// <inheritDoc />
        public UserSessionResponse Convert(UserSessionResult source)
        {
            return source == null
                ? null
                : new UserSessionResponse
                {
                    DealerId = source.DealerId
                };
        }
    }
}