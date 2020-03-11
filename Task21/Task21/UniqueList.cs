using System;

namespace Task21
{
    public class UniqueList : List
    {
        /// <summary>
        /// Initializes a new instance of <see cref="UniqueList"/> class.
        /// </summary>
        public UniqueList()
            : base()
        {

        }

        /// <summary>
        /// Inserts value to list to given position.
        /// </summary>
        /// <param name="position">Position of new list element</param>
        /// <param name="value">Value to be inserted</param>
        /// <exception cref="ValueAlreadyExistException">If element already contains in list</exception>
        public override void Insert(int position, int value)
        {
            if (base.ContainsValue(value) == true)
            {
                throw new ValueAlreadyExistException();
            }

            base.Insert(position, value);
        }
    }
}