using System;
using GenericsDemo;
using Moq;
using NUnit.Framework;

namespace EnumerableSequencesTest
{
    public class Tests
    {
        private Predicate<int> intPredicate;
        private Predicate<string> stringPredicate;
        private Predicate<PointStruct> pointPredicate;
        private Predicate<Message> messagePredicate;
        private Converter<int, string> intToStringConverter;
        private Converter<int, PointStruct> intToPointConverter;
        private Comparison<int> intComparison;
        private Comparison<PointStruct> pointComparison;
        private Comparison<Message> messageComparison;
        private Mock<ITransformer<double, string>> mockTransformerDoubleToString;
        private Mock<ITransformer<int, PointStruct>> mockTransformerIntToPoint;
        private ITransformer<double, string> transformer;
        private ITransformer<int, PointStruct> intToPointTransformer;

        [SetUp]
        public void Setup()
        {
            intPredicate = i => i % 2 == 0;
            stringPredicate = s => s.Contains('f');
            pointPredicate = p => p.x == p.y;
            messagePredicate = m => m.Id <= 2;
            intToStringConverter = input => input.ToString();
            intToPointConverter = value => new PointStruct(value, value+1);
            intComparison = (i, i1) => (i < i1) ? 1 : -1;
            pointComparison = (point1, point2) => (point1.x < point2.x) ? 1 : -1;
            messageComparison = (message, message1) => (message.Id < message1.Id) ? 1 : -1;
            mockTransformerDoubleToString = new Mock<ITransformer<double, string>>();
            mockTransformerDoubleToString.Setup(p => p.Transform(It.Is<double>(i => i > 0))).Returns("double");
            mockTransformerIntToPoint = new Mock<ITransformer<int, PointStruct>>();
            mockTransformerIntToPoint.Setup(p => p.Transform(It.IsAny<int>())).Returns(new PointStruct(1, 1));
            transformer = mockTransformerDoubleToString.Object;
            intToPointTransformer = mockTransformerIntToPoint.Object;
        }

        [Test]
        public void FilterByTests_Int()
        {
            int[] source = new int[] { 12, 35, -65, 543, 23 };

            var expected = new int[] { 12 };

            var actual = source.FilterBy(intPredicate);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void FilterByTests_String()
        {
            string[] source = new string[] {"abc", "bcd", "cde", "def", "efg"};
            var expected = new string[] {"def", "efg"};
            var actual = source.FilterBy(stringPredicate);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void FilterByTests_Struct()
        {
            PointStruct[] source = new PointStruct[] {new PointStruct(1,1), new PointStruct(2,2), new PointStruct(2,4), new PointStruct(5,6), new PointStruct(2,6)};
            var expected = new PointStruct[] { new PointStruct(1, 1), new PointStruct(2, 2) };
            var actual = source.FilterBy(pointPredicate);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void FilterByTests_Class()
        {
            Message bMessage = new Message("b");
            Message dMessage = new Message("d");
            Message[] source = new Message[] {new Message("a"), bMessage, new Message("c"), dMessage,    };
            var expected = new Message[] {bMessage, dMessage};
            var actual = source.FilterBy(messagePredicate);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TransformTests_DoubleToStringInterface()
        {
            double[] source = new double[] { 5, -1, 6, 20, 14 };

            var expected = new string[] { "double", null, "double", "double", "double" };

            var actual = source.Transform(transformer);

            CollectionAssert.AreEqual(actual, expected);

        }

        [Test]
        public void TransformTests_IntToPointInterface()
        {
            int[] source = new int[] { 1, 2, 3, 1, 2 };

            var expected = new PointStruct[] { new PointStruct(1, 1), new PointStruct(1, 1), new PointStruct(1, 1), new PointStruct(1, 1), new PointStruct(1, 1) };

            var actual = source.Transform(intToPointTransformer);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TransformTests_IntToString()
        {
            int[] source = new int[] { 1, 2, 3, 1, 2 };

            var expected = new string[] { "1", "2", "3", "1", "2" };

            var actual = source.Transform(intToStringConverter);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TransformTests_IntToPoint()
        {
            int[] source = new int[] { 1, 2, 3, 1, 2 };

            var expected = new PointStruct[] { new PointStruct(1,2), new PointStruct(2,3), new PointStruct(3,4), new PointStruct(1,2), new PointStruct(2,3) };

            var actual = source.Transform(intToPointConverter);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void OrderingTests_Int()
        {
            int[] source = new int[] { 5, 4, -1, -2, 0 };

            var expected = new int[] { -2, -1, 0, 4 , 5 };

            var actual = source.OrderAccordingTo(intComparison);

            CollectionAssert.AreEqual(actual, expected);
        }

        [Test]
        public void OrderingTests_Point()
        {
            PointStruct[] source = new PointStruct[] { new PointStruct(1,1), new PointStruct(2, 10), new PointStruct(3,100), new PointStruct(-1,500)     };

            var expected = new PointStruct[] { new PointStruct(-1, 500), new PointStruct(1, 1), new PointStruct(2, 10), new PointStruct(3, 100) };

            var actual = source.OrderAccordingTo(pointComparison);

            CollectionAssert.AreEqual(actual, expected);
        }

        [Test]
        public void OrderingTests_Message()
        {
            Message aMessage = new Message("a");
            Message bMessage = new Message("b");
            Message cMessage = new Message("c");
            Message dMessage = new Message("d");
            Message[] source = new Message[] {dMessage, cMessage, aMessage, bMessage};

            var expected = new Message[] {aMessage, bMessage, cMessage, dMessage};

            var actual = source.OrderAccordingTo(messageComparison);

            CollectionAssert.AreEqual(actual, expected);
        }
    }
}