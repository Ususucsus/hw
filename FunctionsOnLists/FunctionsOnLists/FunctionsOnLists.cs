namespace FunctionsOnLists
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class provides methods on lists such as map, filter, fold.
    /// </summary>
    /// <typeparam name="T1">Type of list elements</typeparam>
    /// <typeparam name="T2">Type of returns elements (if actual)</typeparam>
    public class FunctionsOnLists<T1, T2>
    {
        /// <summary>
        /// Returns a new list by applying function to each element.
        /// </summary>
        /// <param name="list">Original list</param>
        /// <param name="function">Function which will be applied</param>
        /// <returns>New list</returns>
        public static List<T2> Map(List<T1> list, Func<T1, T2> function)
        {
            var modifiedList = new List<T2>();

            foreach (var listElement in list)
            {
                modifiedList.Add(function(listElement));
            }

            return modifiedList;
        }

        /// <summary>
        /// Filters list elements by function. Returns list with values where function is true.
        /// </summary>
        /// <param name="list">Original list</param>
        /// <param name="function">Function which will be applied</param>
        /// <returns>New List</returns>
        public static List<T1> Filter(List<T1> list, Func<T1, bool> function)
        {
            var filteredList = new List<T1>();

            foreach (var listElement in list)
            {
                if (function(listElement) == true)
                {
                    filteredList.Add(listElement);
                }
            }

            return filteredList;
        }

        /// <summary>
        /// Recurrently calculate folding value by function.
        /// </summary>
        /// <param name="list">Original list</param>
        /// <param name="startValue">Start value</param>
        /// <param name="function">Folding function</param>
        /// <returns>Folding value</returns>
        public static T2 Fold(List<T1> list, T2 startValue, Func<T2, T1, T2> function)
        {
            var resultValue = startValue;

            foreach (var listElement in list)
            {
                resultValue = function(resultValue, listElement);
            }

            return resultValue;
        }
    }
}
