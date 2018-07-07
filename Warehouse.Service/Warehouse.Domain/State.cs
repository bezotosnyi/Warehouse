// --------------------------------------------------------------------------------------------------------------------
// <copyright file="State.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the State type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.Domain
{
    /// <summary>
    /// The state.
    /// </summary>
    public class State
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="State"/> class.
        /// </summary>
        public State()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="State"/> class.
        /// </summary>
        /// <param name="stateId">
        /// The state id.
        /// </param>
        /// <param name="title">
        /// The title.
        /// </param>
        public State(int stateId, string title)
        {
            this.StateId = stateId;
            this.Title = title;
        }

        /// <summary>
        /// Gets or sets the state id.
        /// </summary>
        public int StateId { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }
    }
}