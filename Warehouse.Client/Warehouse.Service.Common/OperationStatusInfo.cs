// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationStatusInfo.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the OperationStatusInfo type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.Service.Common
{
    using System;

    /// <summary>
    /// The operation status info.
    /// </summary>
    [Serializable]
    public class OperationStatusInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OperationStatusInfo"/> class.
        /// </summary>
        public OperationStatusInfo()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationStatusInfo"/> class.
        /// </summary>
        /// <param name="operationStatus">
        /// The operation status.
        /// </param>
        /// <param name="attachedInfo">
        /// The attached info.
        /// </param>
        /// <param name="attachedObject">
        /// The attached object.
        /// </param>
        public OperationStatusInfo(OperationStatus operationStatus, string attachedInfo, object attachedObject)
        {
            this.OperationStatus = operationStatus;
            this.AttachedInfo = attachedInfo;
            this.AttachedObject = attachedObject;
        }

        /// <summary>
        /// Gets the speration status.
        /// </summary>
        public OperationStatus OperationStatus { get; }

        /// <summary>
        /// Gets the attached.
        /// </summary>
        public string AttachedInfo { get; }

        /// <summary>
        /// Gets the attached object.
        /// </summary>
        public object AttachedObject { get; }
    }
}