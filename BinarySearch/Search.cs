using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BinarySearch
{
    public static class Search
    {
        /// <summary>  Searches for an element by binary search.</summary>
        /// <typeparam name="T">Type of sequence's elements.</typeparam>
        /// <param name="sequence">The sequence.</param>
        /// <param name="elementToSearch">The element to search.</param>
        /// <returns>Index of found element if it its found, -1 if it isn't.</returns>
        /// <exception cref="System.ArgumentException">Thrown when sequence is not sorted.</exception>
        public static int BinarySearch<T>(this IEnumerable<T> sequence, T elementToSearch)
        {
            var defaultComparer = Comparer<T>.Default;
            T[] array = sequence.ToArray();
            T[] arrayCopy = sequence.ToArray();
            Array.Sort(arrayCopy);
            int left = 0;
            int right = sequence.Length();
            for (int i = 0; i < array.Length; i++)
            {
                if (!array[i].Equals(arrayCopy[i]))
                {
                    throw new ArgumentException($"{nameof(sequence)} is not sorted.");
                }
            }

            while (left <= right)
            {
                var middle = (left + right) / 2;

                if (elementToSearch.Equals(array[middle]))
                {
                    return middle;
                }

                if (defaultComparer.Compare(elementToSearch, array[middle]) < 0)
                {
                    right = middle - 1;
                }

                if (defaultComparer.Compare(elementToSearch, array[middle]) > 0)
                {
                    left = middle + 1;
                }
            }

            return -1;
        }

        /// <summary>Lengthes the specified sequence.</summary>
        /// <param name="sequence">The sequence.</param>
        /// <returns>Length of enumerable sequence.</returns>
        private static int Length(this IEnumerable sequence)
        {
            int result = 0;
            foreach (var element in sequence)
            {
                result++;
            }

            return result;
        }

        /// <summary>Converts to array.</summary>
        /// <typeparam name="T">Type of sequence's elements.</typeparam>
        /// <param name="sequence">The sequence.</param>
        /// <returns>Array of sequence's elements.</returns>
        private static T[] ToArray<T>(this IEnumerable<T> sequence)
        {
            int i = 0;
            T[] array = new T[sequence.Length()];
            foreach (var element in sequence)
            {
                array[i] = element;
                i++;
            }

            return array;
        }
    }
}
