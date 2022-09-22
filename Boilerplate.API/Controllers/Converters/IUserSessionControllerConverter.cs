using Boilerplate.Callouts.UserSession.Contexts;
using Boilerplate.Callouts.UserSession.Results;
using Boilerplate.Controllers.Requests;
using Boilerplate.Controllers.Responses;

namespace Boilerplate.Controllers.Converters
{
    /// <summary>
    /// The user session converter interface.
    /// </summary>
    public interface IUserSessionControllerConverter
    {
        /// <summary>
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        UserSessionContext Convert(UserSessionRequest source);

        /// <summary>
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        UserSessionResponse Convert(UserSessionResult source);
    }
}
