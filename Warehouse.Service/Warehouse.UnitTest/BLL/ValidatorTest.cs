
namespace Warehouse.UnitTest.BLL
{
    using System;

    using NUnit.Framework;

    using Warehouse.BLL.Validator.Common;
    using Warehouse.BLL.Validator.Contract;
    using Warehouse.Common.Container;
    using Warehouse.DTO;

    /// <summary>
    /// The validator test.
    /// </summary>
    [TestFixture]
    public class ValidatorTest
    {
        /// <summary>
        /// The user validator.
        /// </summary>
        private IValidator<UserLogin> userValidator;

        /// <summary>
        /// The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.userValidator = DIContainer.Resolve<IValidator<UserLogin>>("UserLogin");
        }

        /// <summary>
        /// The user login validator valid test.
        /// </summary>
        [Test]
        public void UserLoginValidatorValidTest()
        {
            var userLogin = new UserLogin("admin", "admin$");
            var result = this.userValidator.Validate(userLogin);
            Console.WriteLine(result.AttachedInfo);
            Assert.AreEqual(ValidationStatus.Success, result.ValidationStatus);
        }

        /// <summary>
        /// The user login validator not valid test.
        /// </summary>
        [Test]
        public void UserLoginValidatorNotValidTest()
        {
            var userLogin = new UserLogin("adn", "adminfsd8754VBN&*fe");
            var result = this.userValidator.Validate(userLogin);
            Assert.AreEqual(ValidationStatus.Fail, result.ValidationStatus);
        }
    }
}
