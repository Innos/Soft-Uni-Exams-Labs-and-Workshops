using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BULSTests
{
    using BangaloreUniversityLearningSystem.Enums;
    using BangaloreUniversityLearningSystem.Interfaces;
    using BangaloreUniversityLearningSystem.Models;
    using BangaloreUniversityLearningSystem.Views;
    using BangaloreUniversityLearningSystem.Views.Courses;
    using BangaloreUniversityLearningSystem.Views.Users;

    using Moq;

    [TestClass]
    public class ViewTests
    {
        [TestMethod]
        public void Display_ShouldReturnAStringResult()
        {
            var test = "Test";
            var createView = new MockView(test);
            var result = createView.Display();

            Assert.IsInstanceOfType(result, typeof(string));
        }

        [TestMethod]
        public void Display_ShouldReturnCorrectResult()
        {
            var test = "Test";
            var createView = new MockView(test);
            var result = createView.Display();

            Assert.AreEqual(test, result);
        }

        [TestMethod]
        public void Display_ShouldTrimResult()
        {
            var test = " Test ";
            var createView = new MockView(test);
            var result = createView.Display();

            Assert.AreEqual("Test", result);
        }
    }
}
