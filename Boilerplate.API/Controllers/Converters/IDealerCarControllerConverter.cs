using Boilerplate.Callouts.DealerCar.Results;
using Boilerplate.Controllers.Requests;
using Boilerplate.Controllers.Responses;
using Boilerplate.Producers.Contexts;

namespace Boilerplate.Controllers.Converters
{
    /// <summary>
    /// The dealr car converter interface.
    /// </summary>
    public interface IDealerCarControllerConverter
    {
        /// <inheritDoc/>
        public DealerDetailsContext Convert(DealerDetailsRequest source);

        /// <inheritDoc/>
        public DealerResponse Convert(DealerResult source);

        /// <inheritDoc/>
        public DealerInformationContext Convert(DealerInformationRequest source);

        /// <inheritDoc/>
        public CarByBatchContext Convert(CarByBatchRequest source);

        /// <inheritDoc/>
        public CarByBatchResponse Convert(CarByBatchResult source);

        /// <inheritDoc/>
        public RemoveCarsContext Convert(RemoveCarsRequest source);
    }
}
