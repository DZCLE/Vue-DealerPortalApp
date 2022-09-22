namespace Boilerplate.Models.Producers
{
    /// <summary>
    /// The remove car information.
    /// </summary>
    public sealed class RemoveCarInformation
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the car identifier.
        /// </summary>
        /// <value>
        /// The car identifier.
        /// </value>
        public int Id { get; set; }

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
        /// Gets or sets the remove from all locations flag.
        /// </summary>
        /// <value>
        /// The remove from all locations flag.
        /// </value>
        public bool RemoveFromAllLocations { get; set; }

        #endregion Public Properties
    }
}