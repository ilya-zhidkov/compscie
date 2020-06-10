using System;
using System.Linq;

namespace CompScie.Core
{
    public class Stack
    {
        private readonly int[] items;
        private int count;

        public Stack(int size) => items = new int[size];

        public void Push(int item)
        {
            if (IsFull())
                throw new StackOverflowException("Stack is full.");

            items[count++] = item;
        }

        public int Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty.");

            return items[--count];
        }

        public bool IsEmpty() => count == 0;

        public bool IsFull() => count == items.Length;

        public override string ToString()
        {
            return $"[{string.Join(", ", items.Take(count).Reverse())}]";
        }
    }
}
