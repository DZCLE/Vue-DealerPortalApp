using System.Collections.Generic;
using Boilerplate.Models.Producers;

namespace Boilerplate.Controllers.Requests
{
    /// <summary>
    /// The remove cars request.
    /// </summary>
    public sealed class RemoveCarsRequest
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the list of cars being deleted.
        /// </summary>
        /// <value>
        /// The the list of cars being deleted.
        /// </value>
        public IEnumerable<RemoveCarInformation> RemovedCars { get; set; }

        /// <summary>
        /// Gets or sets the dealer identifier.
        /// To use this when notifying other dealers about removing cars in multiple locations
        /// </summary>
        /// <value>
        /// The dealer identifier.
        /// </value>
        public int DealerId { get; set; }

        /// <summary>
        /// Gets or sets the dealer name.
        /// To use this when notifying other dealers about removing cars in multiple locations
        /// </summary>
        /// <value>
        /// The dealer name.
        /// </value>
        public string DealerName { get; set; }

        #endregion Public Properties
    }
}