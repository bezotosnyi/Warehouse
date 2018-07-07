// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProviderValidator.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the ProviderValidation type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.BLL.Validator
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    using Warehouse.BLL.Validator.Common;
    using Warehouse.BLL.Validator.Contract;
    using Warehouse.DTO;

    /// <inheritdoc />
    /// <summary>
    /// The provider validation.
    /// </summary>
    public class ProviderValidator : IValidator<ProviderDto>
    {
        /// <inheritdoc />
        /// <summary>
        /// The validate.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="T:Warehouse.BLL.Validator.Common.ValidationStatusInfo" />.
        /// </returns>
        public ValidationStatusInfo Validate(ProviderDto model)
        {
            var attachedList = new List<string>();

            if (model.Name == string.Empty)
            {
                attachedList.Add("Field 'Name' is empty.");
            }

            if (Regex.IsMatch(model.Name, @"[^A-Za-z- ]"))
            {
                attachedList.Add("Field 'Name' contains a non-alpabetic symbol");
            }

            if (model.Phone == string.Empty)
            {
                attachedList.Add("Field 'Phone' is empty");
            }

            if (Regex.IsMatch(model.Phone, @"[^0-9+]"))
            {
                attachedList.Add("Field 'Phone' contains a alphabetic or other non-numeral symbol");
            }

            return attachedList.Count == 0 ?
                       new ValidationStatusInfo(ValidationStatus.Success, "Success validate Repairer") :
                       new ValidationStatusInfo(ValidationStatus.Fail, string.Join("\n", attachedList.ToArray()));
        }
    }
}