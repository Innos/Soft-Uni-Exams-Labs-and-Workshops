namespace PhonebookTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Phonebook.Data;
    using Phonebook.Models;

    [TestClass]
    public class PhonebookTests
    {
        [TestMethod]
        public void AddPhone_WithValidNewInput_ShouldAddANewEntryToTheDatabase()
        {
            var database = new PhonebookRepository();
            var name = "Pesho";
            var phones = new string[] { "0999 (222) 333", "+ 333 12 24 55", "0009990 24-55-66" };

            database.AddPhone(name, phones);

            Assert.AreEqual(1, database.ListEntries(0, 1).Length);
        }

        [TestMethod]
        public void AddPhone_WithValidNewInput_ShouldAddANewEntryWithValidData()
        {
            var database = new PhonebookRepository();
            var name = "Pesho";
            var phones = new string[] { "0999 (222) 333", "+ 333 12 24 55", "0009990 24-55-66" };

            database.AddPhone(name, phones);

            var expectedEntry = "[Pesho: + 333 12 24 55, 0009990 24-55-66, 0999 (222) 333]";

            Assert.AreEqual(name, database.ListEntries(0, 1)[0].Name);
            Assert.AreEqual(expectedEntry, database.ListEntries(0, 1)[0].ToString());
        }

        [TestMethod]
        public void AddPhone_WithNewUser_ShouldReturnTrue()
        {
            var database = new PhonebookRepository();
            var name = "Pesho";
            var phones = new string[] { "0999 (222) 333", "+ 333 12 24 55", "0009990 24-55-66" };

            var isNew = database.AddPhone(name, phones);

            Assert.AreEqual(true, isNew);
        }

        [TestMethod]
        public void AddPhone_WithAlreadyExistingUser_ShouldReturnFalse()
        {
            var database = new PhonebookRepository();
            var name = "Pesho";
            var phones = new string[] { "0999 (222) 333", "+ 333 12 24 55", "0009990 24-55-66" };
            var phones2 = new string[] { "0111111222", "+359222333444", "0888 444 444" };

            database.AddPhone(name, phones);
            var isNew = database.AddPhone(name, phones2);

            Assert.AreEqual(false, isNew);
        }

        [TestMethod]
        public void AddPhone_WithRepeatingEntries_ShouldKeepOnlyUniqueEntries()
        {
            var database = new PhonebookRepository();
            var name = "Pesho";
            var phones1 = new[] { "0888 444 444" };
            var phones2 = new string[] { "0111333222", "0888 444 444" };
            var phones3 = new[] { "0111 222 333", "0444 555 666", "0888 444 444" };

            database.AddPhone(name, phones1);
            database.AddPhone(name, phones2);
            database.AddPhone(name, phones3);
            database.ChangePhone("0888 444 444", "0888 555 555");

            var expectedResult = "[Pesho: 0111 222 333, 0111333222, 0444 555 666, 0888 555 555]";

            Assert.AreEqual(expectedResult, database.ListEntries(0, 1)[0].ToString());
        }

        [TestMethod]
        public void List_WithDatabaseData_ShouldReturnCorrectResults()
        {
            var database = new PhonebookRepository();
            var name = "Pesho";
            var phones = new string[] { "0999 (222) 333", "+ 333 12 24 55", "0009990 24-55-66" };

            database.AddPhone(name, phones);

            var expectedEntry = "[Pesho: + 333 12 24 55, 0009990 24-55-66, 0999 (222) 333]";
            var resultName = database.ListEntries(0, 1)[0].Name;
            var result = database.ListEntries(0, 1)[0].ToString();

            Assert.AreEqual(name, resultName);
            Assert.AreEqual(expectedEntry, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void List_WithIncorrectParameters_ShouldThrowArgumentException()
        {
            var database = new PhonebookRepository();
            var name = "Pesho";
            var phones = new string[] { "0999 (222) 333", "+ 333 12 24 55", "0009990 24-55-66" };

            database.AddPhone(name, phones);

            var expectedEntry = "[Pesho: + 333 12 24 55, 0009990 24-55-66, 0999 (222) 333]";

            Assert.AreEqual(name, database.ListEntries(-1, 10)[0].Name);
            Assert.AreEqual(expectedEntry, database.ListEntries(0, 1)[0].ToString());
        }

        [TestMethod]
        public void List_WithMultipleDatabaseEntries_ShouldReturnCorrectlySortedData()
        {
            var database = new PhonebookRepository();
            var name = "Pesho";
            var name2 = "Ivan";
            var phones = new string[] { "0999 (222) 333", "+ 333 12 24 55", "0009990 24-55-66" };
            var phones2 = new string[] { "0111333222", "+359222333444", "0888 444 444" };

            database.AddPhone(name, phones);
            database.AddPhone(name2, phones2);

            var expectedResult = string.Format("[Ivan: +359222333444, 0111333222, 0888 444 444]{0}[Pesho: + 333 12 24 55, 0009990 24-55-66, 0999 (222) 333]", Environment.NewLine);

            Assert.AreEqual(expectedResult, string.Join<PhoneEntry>(Environment.NewLine, database.ListEntries(0, 2)));
        }

        [TestMethod]
        public void ChangePhone_WithValidInput_ShouldChangePhone()
        {
            var database = new PhonebookRepository();
            var name = "Pesho";
            var phones2 = new string[] { "0111333222", "+359222333444", "0888 444 444" };

            database.AddPhone(name, phones2);
            database.ChangePhone("0111333222", "+359 111 222 333");

            var expectedResult = "[Pesho: +359 111 222 333, +359222333444, 0888 444 444]";

            Assert.AreEqual(expectedResult, database.ListEntries(0, 1)[0].ToString());
        }     

        [TestMethod]
        public void ChangePhone_WithSamePhoneInMultipleEntries_ShouldChangePhoneInAllEntries()
        {
            var database = new PhonebookRepository();
            var name = "Pesho";
            var name2 = "Gosho";
            var phones1 = new[] { "0888 444 444" };
            var phones2 = new string[] { "0111333222", "0888 444 444" };

            database.AddPhone(name, phones1);
            database.AddPhone(name2, phones2);
            database.ChangePhone("0888 444 444", "0888 555 555");

            var expectedResult = "[Gosho: 0111333222, 0888 555 555]\n[Pesho: 0888 555 555]";

            Assert.AreEqual(expectedResult, string.Join<PhoneEntry>("\n", database.ListEntries(0, 2)));
        }


    }
}
