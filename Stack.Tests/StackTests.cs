using NUnit.Framework;
using StackDojoTest;
using System;

namespace StackDojo.Tests
{
    [TestFixture]
    public class StackTests
    {
        private Stack stack;

        [SetUp]
        public void SetupTests()
        {
            //Arrange
            stack = new Stack(5);
        }

        [Test]
        public void Construct_WithGivenSize_CreateStack()
        {
            Assert.IsNotNull(stack);
        }

        [Test]
        public void Push_GivenOneInt_LengthEquals1()
        {
            //Act
            stack.Push(5);
            //Assert
            var expected = 1;
            var actual = stack.Length;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Pop_Pushed5_Returns5()
        {
            //Arrange
            stack.Push(5);
            //Act
            int actual = stack.Pop();
            //Assert
            int expected = 5;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Pop_EmptyStack_ThrowInValidOperationException()
        {
            //Act
            var ex = Assert.Throws<InvalidOperationException>(() => stack.Pop());
            //Assert
            Assert.That(ex.Message, Is.EqualTo("It is an empty stack!"));
        }

        [Test]
        public void Pop_GivenTwoElement_ReturnsElementsInBackward()
        {
            //Arrange
            stack.Push(12);
            stack.Push(24);
            //Act
            int last = stack.Pop();
            int lastBefore = stack.Pop();
            //Assert
            Assert.AreEqual(24, last);
            Assert.AreEqual(12, lastBefore);
        }

        [Test]
        public void Push_GivenMoreElementThanSize_ThrowsStackOverflow()
        {
            //Arrange
            stack.Push(12);
            stack.Push(24);
            stack.Push(36);
            stack.Push(24);
            stack.Push(24);
            //Act
            var ex = Assert.Throws<StackOverflowException>(() => stack.Push(54));
            //Assert
            Assert.AreEqual("Stack is full", ex.Message);
        }

    }
}
