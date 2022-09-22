using System;

namespace Boilerplate.Callouts.DealerCar.Responses
{
    /// <summary>
    /// Response containing the car information.
    /// </summary>
    public class CarDataResponse
    {
        /// <summary>
        /// Gets or sets the car identifier.
        /// </summary>
        /// <value>
        /// The car identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the dealer ID.
        /// </summary>
        /// <value>
        /// The dealer ID.
        /// </value>
        public int DealerId { get; set; }

        /// <summary>
        /// Gets or sets the make.
        /// </summary>
        /// <value>
        /// The make.
        /// </value>
        public string Make { get; set; }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the fuel type.
        /// </summary>
        /// <value>
        /// The fuel type.
        /// </value>
        public string FuelType { get; set; }

        /// <summary>
        /// Gets or sets the transmission.
        /// </summary>
        /// <value>
        /// The transmission.
        /// </value>
        public string Transmission { get; set; }

        /// <summary>
        /// Gets or sets the body type.
        /// </summary>
        /// <value>
        /// The body type.
        /// </value>
        public string BodyType { get; set; }

        /// <summary>
        /// Gets or sets the condition.
        /// </summary>
        /// <value>
        /// The condition.
        /// </value>
        public string Condition { get; set; }
    }
}