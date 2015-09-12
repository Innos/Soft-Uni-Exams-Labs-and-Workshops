using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BULSTests
{
    using BangaloreUniversityLearningSystem.Data;
    using BangaloreUniversityLearningSystem.Enums;
    using BangaloreUniversityLearningSystem.Models;

    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void Get_WithANonExistingID_ShouldReturnDefaultElement()
        {
            var repository = new Repository<User>();
            var result = repository.Get(1);

            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void Get_WithAnExistingID_ShouldReturnElement()
        {
            var repository = new Repository<User>();
            var user = new User("Ivan Ivanov", "123456", Role.Student);
            repository.Add(user);
            var result = repository.Get(1);

            Assert.AreEqual(user, result);
        }

        [TestMethod]
        public void Get_WithManyEntries_ShouldReturnCorrectEntry()
        {
            var repository = new Repository<User>();
            var user = new User("Ivan Ivanov", "123456", Role.Student);
            var user2 = new User("Ivan Ivanov2", "123456", Role.Student);
            var user3 = new User("Ivan Ivanov3", "123456", Role.Student);
            repository.Add(user);
            repository.Add(user2);
            repository.Add(user3);
            var result = repository.Get(2);

            Assert.AreEqual(user2, result);
        }
    }
}
