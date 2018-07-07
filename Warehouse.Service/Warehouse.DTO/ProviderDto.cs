// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProviderDto.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the ProviderDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.DTO
{
    /// <summary>
    /// The provider dto.
    /// </summary>
    [System.Serializable]
    public class ProviderDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProviderDto"/> class.
        /// </summary>
        public ProviderDto()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProviderDto"/> class.
        /// </summary>
        /// <param name="providerId">
        /// The id.
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
        public ProviderDto(int providerId, string name, string address, string phone)
        {
            this.ProviderId = providerId;
            this.Name = name;
            this.Address = address;
            this.Phone = phone;
        }

        /// <summary>
        /// Gets or sets the id.
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