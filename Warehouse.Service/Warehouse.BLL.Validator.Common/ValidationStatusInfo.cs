// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidationStatusInfo.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the ValidationStatusInfo type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.BLL.Validator.Common
{
    /// <summary>
    /// The validation status info.
    /// </summary>
    public class ValidationStatusInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationStatusInfo"/> class.
        /// </summary>
        /// <param name="validationStatus">
        /// The validation status.
        /// </param>
        /// <param name="attachedInfo">
        /// The attached info.
        /// </param>
        public ValidationStatusInfo(ValidationStatus validationStatus, string attachedInfo)
        {
            this.ValidationStatus = validationStatus;
            this.AttachedInfo = attachedInfo;
        }

        /// <summary>
        /// Gets the validation status.
        /// </summary>
        public ValidationStatus ValidationStatus { get; }

        /// <summary>
        /// Gets the attached info.
        /// </summary>
        public string AttachedInfo { get; }
    }
}