using Boilerplate.Models.Producers;
using System.Collections.Generic;

namespace Boilerplate.Producers.Contexts
{
    /// <summary>
    /// The remove car context.
    /// </summary>
    public sealed class RemoveCarsContext
    {
        /// <summary>
        /// Gets or sets the list of remove car information.
        /// </summary>
        /// <value>
        /// The list of remove car information.
        /// </value>
        public IEnumerable<RemoveCarInformation> RemoveCarInformation { get; set; }
    }
}