// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserRegistrationValidator.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the UserRegistrationValidator type.
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
    /// The user registration validator.
    /// </summary>
    public class UserRegistrationValidator : IValidator<UserRegistration>
    {
        /// <inheritdoc />
        /// <summary>
        /// The validate.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="T:RemoteNotepad.BLL.Validator.Common.ValidationStatusInfo" />.
        /// </returns>
        public ValidationStatusInfo Validate(UserRegistration model)
        {
            var attachedList = new List<string>();

            if (model.Name.Length < 3)
            {
                attachedList.Add("Name should have minimum 3 characters.");
            }

            if (!Regex.IsMatch(model.Name, @"[+A-Za-z](-)*"))
            {
                attachedList.Add("Name should contain only letters (a-z) and dashes.");
            }

            if (model.LastName.Length < 3)
            {
                attachedList.Add("LastName should have minimum 3 characters.");
            }

            if (!Regex.IsMatch(model.LastName, @"[+A-Za-z](-)*"))
            {
                attachedList.Add("LastName should contain only letters (a-z) and dashes.");
            }

            if (model.Login.Length < 4)
            {
                attachedList.Add("Login should have minimum 4 characters.");
            }

            if (!Regex.IsMatch(model.Login, @"[+A-Za-z0-9]\W*"))
            {
                attachedList.Add("Login must contain letters (a-z) and also can contain numbers (0-9) or underscores (_).");
            }

            if (model.Password.Length < 4)
            {
                attachedList.Add("Password should have minimum 4 characters.");
            }

            if (!Regex.IsMatch(model.Password, @"[+A-Za-z0-9]\W+"))
            {
                attachedList.Add("Password should contain minimum one special symbol.");
            }

            return attachedList.Count == 0 ?
                       new ValidationStatusInfo(ValidationStatus.Success, "Success validate UserRegistration") :
                       new ValidationStatusInfo(ValidationStatus.Fail, string.Join("\n", attachedList.ToArray()));
        }
    }
}