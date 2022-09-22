using System.Collections.Generic;
namespace Boilerplate.Callouts.DealerCar.Results
{
    /// <summary>
    /// Response containing the car information by batch.
    /// </summary>
    public class CarByBatchResult
    {
        /// <summary>
        /// Gets or sets the totla number of cars.
        /// </summary>
        /// <value>
        /// The total number of cars.
        /// </value>
        public int TotalNumberOfCars { get; set; }

        /// <summary>
        /// Gets or sets the car name.
        /// </summary>
        /// <value>
        /// The car name.
        /// </value>
        public List<CarResult> Cars { get; set; }
    }
}