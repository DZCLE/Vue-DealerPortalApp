namespace Boilerplate.Producers.Contexts
{
    /// <summary>
    /// The car by batch context.
    /// </summary>
    public sealed class CarByBatchContext
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the dealer identifier.
        /// </summary>
        /// <value>
        /// The dealer identifier.
        /// </value>
        public int DealerId { get; set; }

        /// <summary>
        /// Gets or sets the batch size.
        /// </summary>
        /// <value>
        /// The batch size.
        /// </value>
        public int BatchSize { get; set; }

        /// <summary>
        /// Gets or sets the batch number.
        /// </summary>
        /// <value>
        /// The batch number.
        /// </value>
        public int BatchNumber { get; set; }

        /// <summary>
        /// Gets or sets the sort method.
        /// </summary>
        /// <value>
        /// The sort method.
        /// </value>
        public int SortMethod { get; set; }

        /// <summary>
        /// Gets or sets the condition.
        /// </summary>
        /// <value>
        /// The car type.
        /// </value>
        public int Condition { get; set; }

        #endregion Public Properties
    }
}
