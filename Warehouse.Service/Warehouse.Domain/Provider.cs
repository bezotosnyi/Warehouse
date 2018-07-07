// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Provider.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the Provider type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.Domain
{
    /// <summary>
    /// The provider.
    /// </summary>
    public class Provider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Provider"/> class.
        /// </summary>
        public Provider()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Provider"/> class.
        /// </summary>
        /// <param name="providerId">
        /// The provider id.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="address">
        /// The address.
        /// </param>
        /// <param name="phone">
        /// The phone.
        /// </param>
        public Provider(int providerId, string name, string address, string phone)
        {
            this.ProviderId = providerId;
            this.Name = name;
            this.Address = address;
            this.Phone = phone;
        }

        /// <summary>
        /// Gets or sets the provider id.
        /// </summary>
        public int ProviderId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        public string Phone { get; set; }
    }
}