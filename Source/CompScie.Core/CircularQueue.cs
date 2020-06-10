using System;

namespace CompScie.Core
{
    public class CircularQueue
    {
        private readonly int[] items;
        private int rear;
        private int front;
        private int count;

        public CircularQueue(int size) => items = new int[size];

        public void Enqueue(int item)
        {
            if (IsFull())
                throw new InvalidOperationException("Queue is full.");

            items[rear] = item;
            rear = (rear + 1) % items.Length;
            count++;
        }

        public int Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty.");

            var item = items[front];
            items[front] = 0;
            front = (front + 1) % items.Length;
            count--;

            return item;
        }
        public bool IsEmpty() => count == 0;

        public bool IsFull() => count == items.Length;

        public override string ToString() => $"[{string.Join(", ", items)}]";
    }
}
