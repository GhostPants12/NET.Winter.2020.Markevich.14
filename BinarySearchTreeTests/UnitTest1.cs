using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using BinarySearchTree;
using Notebook.Part1;
using NUnit.Framework;

namespace BinarySearchTreeTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BinarySearchTreeTest_Int_Standard()
        {
            Node<int> node = new Node<int>(10);
            Node<int> node5 = new Node<int>(5);
            Node<int> node8 = new Node<int>(8);
            Node<int> node13 = new Node<int>(13);
            Node<int> node1 = new Node<int>(1);
            Node<int> node15 = new Node<int>(15);
            Node<int> node12 = new Node<int>(12);
            Node<int> node11 = new Node<int>(11);
            BinarySearchTree<int> tree = new BinarySearchTree<int>(node);
            tree.Add(node5);
            tree.Add(node8);
            tree.Add(node13);
            tree.Add(node1);
            tree.Add(node15);
            tree.Add(node12);
            tree.Add(node11);
            var expected = new Node<int>[] {node, node5, node1, node8, node13, node12, node11, node15};
            var actual = tree.PreorderTree(node);
            CollectionAssert.AreEqual(expected, actual);
            expected = new Node<int>[] {node1, node8, node5, node11, node12, node15, node13, node};
            actual = tree.PostorderTree(node);
            CollectionAssert.AreEqual(expected, actual);
            expected = new Node<int>[] {node1, node5, node8, node, node11, node12, node13, node15};
            actual = tree.InorderTree(node);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BinarySearchTreeTest_Int_Custom()
        {
            Node<int> node = new Node<int>(10);
            Node<int> node5 = new Node<int>(5);
            Node<int> node8 = new Node<int>(8);
            Node<int> node13 = new Node<int>(13);
            Node<int> node1 = new Node<int>(1);
            Node<int> node15 = new Node<int>(15);
            Node<int> node12 = new Node<int>(12);
            Node<int> node11 = new Node<int>(11);
            BinarySearchTree<int> tree = new BinarySearchTree<int>(node, new IntComparer());
            tree.Add(node5);
            tree.Add(node8);
            tree.Add(node13);
            tree.Add(node1);
            tree.Add(node15);
            tree.Add(node12);
            tree.Add(node11);
            var expected = new Node<int>[] {node, node13, node15, node12, node11, node5, node8, node1};
            var actual = tree.PreorderTree(node);
            CollectionAssert.AreEqual(expected, actual);
            expected = new Node<int>[] {node15, node11, node12, node13, node8, node1, node5, node};
            actual = tree.PostorderTree(node);
            CollectionAssert.AreEqual(expected, actual);
            expected = new Node<int>[] {node15, node13, node12, node11, node, node8, node5, node1};
            actual = tree.InorderTree(node);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BinarySearchTreeTest_String_Standard()
        {
            Node<string> node = new Node<string>("abcdef");
            Node<string> node4 = new Node<string>("abcd");
            Node<string> node7 = new Node<string>("abcdefg");
            Node<string> node5 = new Node<string>("abcde");
            Node<string> node8 = new Node<string>("abcdefgh");
            Node<string> node9 = new Node<string>("abcdefghi");
            BinarySearchTree<string> tree = new BinarySearchTree<string>(node);
            tree.Add(node4);
            tree.Add(node7);
            tree.Add(node5);
            tree.Add(node8);
            tree.Add(node9);
            var expected = new Node<string>[] {node, node4, node5, node7, node8, node9};
            var actual = tree.PreorderTree(node);
            CollectionAssert.AreEqual(expected, actual);
            expected = new Node<string>[] { node5, node4, node9, node8, node7, node };
            actual = tree.PostorderTree(node);
            CollectionAssert.AreEqual(expected, actual);
            expected = new Node<string>[] { node4, node5, node, node7, node8, node9 };
            actual = tree.InorderTree(node);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BinarySearchTreeTest_String_Custom()
        {
            Node<string> node = new Node<string>("abcdef");
            Node<string> node4 = new Node<string>("abcd");
            Node<string> node7 = new Node<string>("abcdefg");
            Node<string> node5 = new Node<string>("abcde");
            Node<string> node8 = new Node<string>("abcdefgh");
            Node<string> node9 = new Node<string>("abcdefghi");
            BinarySearchTree<string> tree = new BinarySearchTree<string>(node, new StringComparer());
            tree.Add(node4);
            tree.Add(node7);
            tree.Add(node5);
            tree.Add(node8);
            tree.Add(node9);
            var expected = new Node<string>[] { node, node7, node8, node9, node4, node5 };
            var actual = tree.PreorderTree(node);
            CollectionAssert.AreEqual(expected, actual);
            expected = new Node<string>[] { node9, node8, node7, node5, node4, node };
            actual = tree.PostorderTree(node);
            CollectionAssert.AreEqual(expected, actual);
            expected = new Node<string>[] { node9, node8, node7, node, node5, node4 };
            actual = tree.InorderTree(node);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BinarySearchTreeTest_Note_Standard()
        {
            Node<Note> node6= new Node<Note>(new Note("6"));
            Node<Note> node5 = new Node<Note>(new Note("5"));
            Node<Note> node4 = new Node<Note>(new Note("4"));
            Node<Note> node3 = new Node<Note>(new Note("3"));
            Node<Note> node2 = new Node<Note>(new Note("2"));
            Node<Note> node1 = new Node<Note>(new Note("1"));
            BinarySearchTree<Note> tree = new BinarySearchTree<Note>(node4);
            tree.Add(node2);
            tree.Add(node1);
            tree.Add(node3);
            tree.Add(node6);
            tree.Add(node5);
            var expected = new Node<Note>[]{node4, node2, node1, node3, node6, node5};
            var actual = tree.PreorderTree(node4);
            CollectionAssert.AreEqual(expected, actual);
            expected = new Node<Note>[]{node1, node3, node2, node5, node6, node4};
            actual = tree.PostorderTree(node4);
            CollectionAssert.AreEqual(expected, actual);
            expected = new Node<Note>[] { node1, node2, node3, node4, node5, node6 };
            actual = tree.InorderTree(node4);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BinarySearchTreeTest_Note_Custom()
        {
            Node<Note> node1 = new Node<Note>(new Note("a"));
            Node<Note> node2 = new Node<Note>(new Note("ab"));
            Node<Note> node3 = new Node<Note>(new Note("abc"));
            Node<Note> node4 = new Node<Note>(new Note("abcd"));
            Node<Note> node5 = new Node<Note>(new Note("abcde"));
            Node<Note> node6 = new Node<Note>(new Note("abcdef"));
            BinarySearchTree<Note> tree = new BinarySearchTree<Note>(node4, new NoteComparer());
            tree.Add(node2);
            tree.Add(node1);
            tree.Add(node3);
            tree.Add(node6);
            tree.Add(node5);
            var expected = new Node<Note>[] { node4, node2, node1, node3, node6, node5 };
            var actual = tree.PreorderTree(node4);
            CollectionAssert.AreEqual(expected, actual);
            expected = new Node<Note>[] { node1, node3, node2, node5, node6, node4 };
            actual = tree.PostorderTree(node4);
            CollectionAssert.AreEqual(expected, actual);
            expected = new Node<Note>[] { node1, node2, node3, node4, node5, node6 };
            actual = tree.InorderTree(node4);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void BinarySearchTreeTest_CustomStruct()
        {
            Node<Point> node = new Node<Point>(new Point(1,10));
            Node<Point> node5 = new Node<Point>(new Point(1,5));
            Node<Point> node8 = new Node<Point>(new Point(1,8));
            Node<Point> node13 = new Node<Point>(new Point(1,13));
            Node<Point> node1 = new Node<Point>(new Point(1,1));
            Node<Point> node15 = new Node<Point>(new Point(1,15));
            Node<Point> node12 = new Node<Point> (new Point(1,12));
            Node<Point> node11 = new Node<Point>(new Point(1,11));
            BinarySearchTree<Point> tree = new BinarySearchTree<Point>(node, new PointComparer());
            tree.Add(node5);
            tree.Add(node8);
            tree.Add(node13);
            tree.Add(node1);
            tree.Add(node15);
            tree.Add(node12);
            tree.Add(node11);
            var expected = new Node<Point>[] { node, node5, node1, node8, node13, node12, node11, node15 };
            var actual = tree.PreorderTree(node);
            CollectionAssert.AreEqual(expected, actual);
            expected = new Node<Point>[] { node1, node8, node5, node11, node12, node15, node13, node };
            actual = tree.PostorderTree(node);
            CollectionAssert.AreEqual(expected, actual);
            expected = new Node<Point>[] { node1, node5, node8, node, node11, node12, node13, node15 };
            actual = tree.InorderTree(node);
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}