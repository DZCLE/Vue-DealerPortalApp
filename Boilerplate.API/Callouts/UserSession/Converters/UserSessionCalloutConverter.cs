using Boilerplate.Callouts.DealerCar.Responses;
using Boilerplate.Callouts.UserSession.Results;

namespace Boilerplate.Callouts.UserSession.Converters
{
    /// <inheritDoc/>
    public class UserSessionCalloutConverter : IUserSessionCalloutConverter
    {
        /// <inheritdoc />
        public UserSessionResult Convert(UserSessionDataResponse source)
        {
            return source == null
                ? null
                : new UserSessionResult
                {
                    LoginId = source.LoginId,
                    DealerId = source.DealerId
                };
        }
    }
}