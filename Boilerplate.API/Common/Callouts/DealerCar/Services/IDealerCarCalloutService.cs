using Boilerplate.Callouts.DealerCar.Results;
using Boilerplate.Producers.Contexts;
using System.Threading;
using System.Threading.Tasks;

namespace Boilerplate.Callouts.DealerCar.Services
{
    /// <summary>
    /// The producers callout service.
    /// </summary>
    public interface IDealerCarCalloutService
    {
        #region Public Methods        

        /// <summary>
        /// Gets the dealer information.
        /// </summary>
        /// <param name="context">The context.</param>
       /// <param name="cancellation">The cancellation.</param>
        /// <returns>A <see cref="Task{TResult}"/> containing <see cref="IProcessResult{T}"/> containing a <see cref="DealerResult"/>.</returns>
        DealerResult GetDealer(DealerDetailsContext context, CancellationToken cancellation);

        /// <summary>
        /// Saves the dealer information.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="cancellation">The cancellation.</param>
        /// <returns>A <see cref="Task{TResult}"/> containing <see cref="IProcessResult{T}"/> containing a <see cref="bool"/>.</returns>
        bool SaveDealer(DealerInformationContext context, CancellationToken cancellation);

        /// <summary>
        /// Gets the car list.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="cancellation">The cancellation.</param>
        /// <returns>A <see cref="Task{TResult}"/> containing <see cref="IProcessResult{T}"/> containing a <see cref="CarByBatchResult"/>.</returns>
        CarByBatchResult GetCarsByBatch(CarByBatchContext context, CancellationToken cancellation);

        /// <summary>
        /// Deletes cars.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="cancellation">The cancellation.</param>
        /// <returns>A <see cref="Task{TResult}"/> containing <see cref="IProcessResult{T}"/> containing a <see cref="bool"/>.</returns>
        bool DeleteCars(RemoveCarsContext context, CancellationToken cancellation);

        #endregion Public Methods
    }
}