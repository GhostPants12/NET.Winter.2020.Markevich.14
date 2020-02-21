using System;
using BinarySearch;
using Notebook.Part1;
using NUnit.Framework;

namespace BinarySearchTests
{
    public class Tests
    {
        [Test]
        public void BinarySearchTests_Int()
        {
            int[] arr = new int[] {1, 2, 3, 4, 5, 6};
            int expected = 2;
            var actual = arr.BinarySearch(3);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void BinarySearchTests_String()
        {
            string[] arr = new string[] {"a", "ab", "abc", "abcd", "abcde"};
            int expected = 1;
            var actual = arr.BinarySearch("ab");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void BinarySearchTests_Class()
        {
            Note noteToSearch = new Note("3");
            Note[] arr = new Note[]{ noteToSearch, new Note("1"), new Note("2"),  new Note("4"), new Note("5"),     };
            int expected = 0;
            var actual = arr.BinarySearch(noteToSearch);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void BinarySearchTests_IncorrectValue()
        {
            int[] arr = new int[] { 1, 5, 3, 4, 2, 6 };
            Assert.Throws<ArgumentException>(() => arr.BinarySearch(5));
        }
    }
}