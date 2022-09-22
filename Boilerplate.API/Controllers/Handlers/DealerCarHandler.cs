using System.Threading;
using Boilerplate.Controllers.Responses;
using Boilerplate.Controllers.Requests;
using Boilerplate.Controllers.Converters;
using Boilerplate.Callouts.DealerCar.Services;

namespace Boilerplate.Controllers.Handlers
{
    /// <inheritDoc />
    public sealed class DealerCarHandler : IDealerCarHandler
    {
        #region Private Fields

        private readonly IDealerCarControllerConverter _dealerCarControllerConverter;
        private readonly IDealerCarCalloutService _dealerCarCalloutService;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DealerCarHandler"/> class.
        /// </summary>
        /// <param name="dealerCarControllerConverter">The converter.</param>
        /// <param name="dealerCarCalloutService">The callout service.</param>
        public DealerCarHandler(IDealerCarControllerConverter dealerCarControllerConverter,
            IDealerCarCalloutService dealerCarCalloutService
)
        {
            _dealerCarControllerConverter = dealerCarControllerConverter;
            _dealerCarCalloutService = dealerCarCalloutService;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <inheritDoc />
        public DealerResponse LoadDealer(DealerDetailsRequest command, CancellationToken cancellation)
        {
            var context = _dealerCarControllerConverter.Convert(command);

            var response = _dealerCarCalloutService.GetDealer(context, cancellation);

            return _dealerCarControllerConverter.Convert(response);
        }

        /// <inheritDoc />
        public bool SaveDealer(DealerInformationRequest command, CancellationToken cancellation)
        {
            var context = _dealerCarControllerConverter.Convert(command);

            return _dealerCarCalloutService.SaveDealer(context, cancellation);
        }

        /// <inheritDoc />
        public CarByBatchResponse GetCarsByBatch(CarByBatchRequest command, CancellationToken cancellation)
        {
            var context = _dealerCarControllerConverter.Convert(command);

            var response = _dealerCarCalloutService.GetCarsByBatch(context, cancellation);

            return _dealerCarControllerConverter.Convert(response);
        }

        /// <inheritDoc />
        public bool DeleteCars(RemoveCarsRequest command, CancellationToken cancellation)
        {
            var context = _dealerCarControllerConverter.Convert(command);

            return _dealerCarCalloutService.DeleteCars(context, cancellation);
        }

        #endregion Public Methods


    }
}