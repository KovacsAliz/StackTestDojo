using System;

namespace StackDojoTest
{
    public class Stack
    {
        private readonly int _size;
        private readonly int[] _elements;

        public int Length { get; private set; }

        public Stack(int size)
        {
            _size = size;
            _elements = new int[_size];
        }

        public void Push(int value)
        {
            if (Length+1 > _size)
            {
                throw new StackOverflowException("Stack is full");
            }
            _elements[Length] = value;
            Length++;
        }

        public int Pop()
        {
            if (Length == 0)
            {
                throw new InvalidOperationException("It is an empty stack!");
            }
            
            return _elements[--Length];
        }
    }
}
