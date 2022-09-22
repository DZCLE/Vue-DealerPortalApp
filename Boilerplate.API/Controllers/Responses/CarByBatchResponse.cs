using System.Collections.Generic;

namespace Boilerplate.Controllers.Responses
{
    /// <summary>
    /// The car response by batch.
    /// </summary>
    public sealed class CarByBatchResponse
    {
        /// <summary>
        /// Gets or sets the totla number of cars.
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
        public IEnumerable<CarResponse> Cars { get; set; }
    }
}
