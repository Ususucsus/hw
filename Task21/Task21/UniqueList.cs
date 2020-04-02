// <copyright file="UniqueList.cs" company="Artur Usmanov">
//      Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace Task21
{
    /// <summary>
    /// Represents list with only unique values.
    /// </summary>
    public class UniqueList : List
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UniqueList"/> class.
        /// </summary>
        public UniqueList()
            : base()
        {
        }

        /// <summary>
        /// Inserts value to list to given position.
        /// </summary>
        /// <param name="position">Position of new list element.</param>
        /// <param name="value">Value to be inserted.</param>
        /// <exception cref="ValueAlreadyExistException">If element already contains in list.</exception>
        public override void Insert(int position, int value)
        {
            if (this.ContainsValue(value))
            {
                throw new ValueAlreadyExistException();
            }

            base.Insert(position, value);
        }
    }
}