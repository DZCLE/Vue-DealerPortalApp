using Boilerplate.Callouts.DealerCar.Responses;
using Boilerplate.Callouts.DealerCar.Results;

namespace Boilerplate.Callouts.DealerCar.Converters
{
    /// <summary>
    /// The dealer car callout converter interface.
    /// </summary>
    public interface IDealerCarCalloutConverter
    {
        /// <summary>
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        DealerResult Convert(DealerDataResponse source);

        /// <summary>
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        CarByBatchResult Convert(CarByBatchDataResponse source);
    }
}
