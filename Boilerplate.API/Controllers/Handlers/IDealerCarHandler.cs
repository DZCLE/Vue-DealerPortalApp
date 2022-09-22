using Boilerplate.Controllers.Requests;
using Boilerplate.Controllers.Responses;
using System.Threading;

namespace Boilerplate.Controllers.Handlers
{
    /// <summary>
    /// The dealer car handler interface.
    /// </summary>
    public interface IDealerCarHandler
    {
        #region Public Methods

        /// <summary>
        /// Gets the dealer information.
        /// </summary>
        /// <param name="request">The command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        DealerResponse LoadDealer(DealerDetailsRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Saves the dealer information.
        /// </summary>
        /// <param name="request">The command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        bool SaveDealer(DealerInformationRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the list of cars by batch information.
        /// </summary>
        /// <param name="request">The command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        CarByBatchResponse GetCarsByBatch(CarByBatchRequest request, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes cars.
        /// </summary>
        /// <param name="request">The command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        bool DeleteCars(RemoveCarsRequest request, CancellationToken cancellationToken);

        #endregion Public Methods
    }
}