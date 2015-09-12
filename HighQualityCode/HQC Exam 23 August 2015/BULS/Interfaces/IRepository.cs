namespace BangaloreUniversityLearningSystem.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// A generic repository which stores data of a given type, has methods for adding an element, returning a specific element by ID and returning all elements stored.
    /// </summary>
    /// <typeparam name="T">The type that the repository will hold.</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// A method that returns all elements in the repository.
        /// </summary>
        /// <returns>Returns an IEnumerable of the same type as the type of the repository.</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// A method that returns a single element form the repository matching a specified integer ID.
        /// </summary>
        /// <param name="id">The ID of the element we want to return.</param>
        /// <returns>Returns a single element of the same type as the repository.</returns>
        T Get(int id);

        /// <summary>
        /// Adds an element of the repository type to the repository.
        /// </summary>
        /// <param name="item">The element to be added.</param>
        void Add(T item);
    }
}
