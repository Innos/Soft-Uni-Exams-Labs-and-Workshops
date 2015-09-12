using System;

namespace BULSTests
{
    using BangaloreUniversityLearningSystem.Controllers;
    using BangaloreUniversityLearningSystem.Enums;
    using BangaloreUniversityLearningSystem.Interfaces;
    using BangaloreUniversityLearningSystem.Models;
    using NUnit.Framework;
    using BangaloreUniversityLearningSystem.Utilities;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

    [TestClass]
    public class UsersControllerTests
    {
        [TestMethod]
        public void Logout_WithValidInput_ShouldLogOutUser()
        {
            var user = new Mock<User>("Ivan Ivanov", "123456", Role.Student);
            var database = new Mock<IBangaloreUniversityDatabase>();

            var userController = new UsersController(database.Object, user.Object);
            Assert.AreEqual(user.Object, userController.CurrentUser);

            userController.Logout();

            Assert.AreEqual(null, userController.CurrentUser);
        }

        [TestMethod]
        public void Logout_WithNoLoggedInUser_ShouldThrowACorrectException()
        {
            var exception = NUnit.Framework.Assert.Catch<ArgumentException>(
                () =>
                {
                    var database = new Mock<IBangaloreUniversityDatabase>();

                    var userController = new UsersController(database.Object, null);

                    userController.Logout();
                });

            Assert.AreEqual(Constants.NoLoggedInUserMessage, exception.Message);
        }

        [TestMethod]
        public void Logout_WithValidInput_ShouldReturnAIViewObject()
        {
            var user = new Mock<User>("Ivan Ivanov", "123456", Role.Student);
            var database = new Mock<IBangaloreUniversityDatabase>();

            var userController = new UsersController(database.Object, user.Object);
            Assert.AreEqual(user.Object, userController.CurrentUser);

            var result = userController.Logout();

            NUnit.Framework.Assert.IsInstanceOf(typeof(IView), result);
        }
    }
}
