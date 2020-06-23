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
                throw new StackOverflowException("Zasobnik je plny.");

            items[count++] = item;
        }

        public int Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Zasobnik je prazdny.");

            return items[--count];
        }

        public bool IsEmpty() => count == 0;

        public bool IsFull() => count == items.Length;

        public override string ToString() => $"[{string.Join(", ", items.Take(count).Reverse())}]";
    }
}
