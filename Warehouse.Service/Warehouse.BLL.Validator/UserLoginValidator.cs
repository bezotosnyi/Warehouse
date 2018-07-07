// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserLoginValidator.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the UserLoginValidator type.
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
    /// The user login validator.
    /// </summary>
    public class UserLoginValidator : IValidator<UserLogin>
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
        public ValidationStatusInfo Validate(UserLogin model)
        {
            var attachedList = new List<string>();

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
                new ValidationStatusInfo(ValidationStatus.Success, "Success validate UserLogin") : 
                new ValidationStatusInfo(ValidationStatus.Fail, string.Join("\n", attachedList.ToArray()));
        }
    }
}