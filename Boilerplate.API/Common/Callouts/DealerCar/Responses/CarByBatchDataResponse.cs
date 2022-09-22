using System.Collections.Generic;

namespace Boilerplate.Callouts.DealerCar.Responses
{
    /// <summary>
    /// Response containing the car information by batch.
    /// </summary>
    public class CarByBatchDataResponse
    {
        /// <summary>
        /// Gets or sets the total number of cars.
        /// </summary>
        /// <value>
        /// The total number of cars.
        /// </value>
        public int TotalNumberOfCars { get; set; }

        /// <summary>
        /// Gets or sets the cars.
        /// </summary>
        /// <value>
        /// The cars.
        /// </value>
        public List<CarDataResponse> Cars { get; set; }
    }
}