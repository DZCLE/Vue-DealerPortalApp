using Boilerplate.Callouts.DealerCar.Responses;
using Boilerplate.Callouts.UserSession.Results;

namespace Boilerplate.Callouts.UserSession.Converters
{
    /// <summary>
    /// The user session callout converter interface.
    /// </summary>
    public interface IUserSessionCalloutConverter
    {
        /// <summary>
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        UserSessionResult Convert(UserSessionDataResponse source);
    }
}
