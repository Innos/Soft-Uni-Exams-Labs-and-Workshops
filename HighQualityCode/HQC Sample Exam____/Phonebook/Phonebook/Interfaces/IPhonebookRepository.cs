namespace Phonebook.Interfaces
{
    using Phonebook.Models;

    /// <summary>
    /// The interface that is implemented by the PhonebookRepository class.
    /// </summary>
    public interface IPhonebookRepository
    {
        /// <summary>
        /// Adds a phone to the database and returns a bool signifying if the user already exists in the database.
        /// </summary>
        /// <param name="name">The name of the person to whom the phonenumbers belong.</param>
        /// <param name="phones">A phone array containing the user's phones in canonical form.</param>
        /// <returns>Returns a bool indicating if the user is a new entry or already exists in the database. True if it's a new entry, false if the user was already present in the database.</returns>
        bool AddPhone(string name, params string[] phones);

        /// <summary>
        /// Changes all instances of a given phone number in the database with a new phone number.
        /// </summary>
        /// <param name="oldPhoneNumber">The number to be changed.</param>
        /// <param name="newPhoneNumber">The new number which will replace the old one.</param>
        /// <returns>An integer signifying how many instances of the old number were changed.</returns>
        int ChangePhone(string oldPhoneNumber, string newPhoneNumber);

        /// <summary>
        /// Creates a PhoneEntry subarray from the database starting from a specified index and having a specified length.
        /// </summary>
        /// <param name="startIndex">The starting index specifying where the starting point of the sub array should be from the database entries sorted by username.</param>
        /// <param name="count">The amound ot elements in the returned sub array.</param>
        /// <returns>Returns a PhoneEntry Array of a specified length and size. </returns>
        PhoneEntry[] ListEntries(int startIndex, int count);
    }
}
