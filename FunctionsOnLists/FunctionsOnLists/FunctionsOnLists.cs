// <copyright file="FunctionsOnLists.cs" company="Artur Usmanov">
//      Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

namespace FunctionsOnLists
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class provides methods on lists such as map, filter, fold.
    /// </summary>
    public static class FunctionsOnLists
    {
        /// <summary>
        /// Returns a new list by applying function to each element.
        /// </summary>
        /// <param name="list">Original list.</param>
        /// <param name="function">Function which will be applied.</param>
        /// <typeparam name="TValue">Type of original list elements.</typeparam>
        /// <typeparam name="TResult">Type of the new list.</typeparam>
        /// <returns>New list.</returns>
        public static List<TResult> Map<TValue, TResult>(List<TValue> list, Func<TValue, TResult> function)
        {
            var modifiedList = new List<TResult>();

            foreach (var listElement in list)
            {
                modifiedList.Add(function(listElement));
            }

            return modifiedList;
        }

        /// <summary>
        /// Filters list elements by function. Returns list with values where function is true.
        /// </summary>
        /// <param name="list">Original list.</param>
        /// <param name="function">Function which will be applied.</param>
        /// <typeparam name="TValue">Type of list elements.</typeparam>
        /// <returns>New List.</returns>
        public static List<TValue> Filter<TValue>(List<TValue> list, Func<TValue, bool> function)
        {
            var filteredList = new List<TValue>();

            foreach (var listElement in list)
            {
                if (function(listElement))
                {
                    filteredList.Add(listElement);
                }
            }

            return filteredList;
        }

        /// <summary>
        /// Recurrently calculate folding value by function.
        /// </summary>
        /// <param name="list">Original list.</param>
        /// <param name="startValue">Start value.</param>
        /// <param name="function">Folding function.</param>
        /// <typeparam name="TValue">Type of original list elements.</typeparam>
        /// <typeparam name="TResult">Type of folded value.</typeparam>
        /// <returns>Folding value.</returns>
        public static TResult Fold<TValue, TResult>(List<TValue> list, TResult startValue, Func<TResult, TValue, TResult> function)
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
