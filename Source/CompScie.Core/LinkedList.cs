using System;

namespace CompScie.Core
{
    /// <summary>
    /// Represents a linear data structure for storing a list of objects in a sequential order.
    /// </summary>
    /// <remarks>Unlike arrays they can grow and shrink automatically.</remarks>
    public class LinkedList
    {
        /// <summary>
        /// Represents a basic building block of a <see cref="LinkedList"/>.
        /// </summary>
        /// <remarks>Each <see cref="Node"/> holds two pieces of information. A value and a reference to the next node or null. Conventionally, the first node is called a "head" and the last is called a "tail".</remarks>
        private class Node
        {
            /// <summary>
            /// A piece of information that each <see cref="Node"/> holds.
            /// </summary>
            public int Value { get; private set; }

            /// <summary>
            /// A reference to the next <see cref="Node"/> in a sequence.
            /// </summary>
            public Node Next { get; set; }

            /// <summary>
            /// Constructs a new instance of a <see cref="Node"/>.
            /// </summary>
            /// <param name="value">A piece of information to store.</param>
            public Node(int value) => Value = value;
        }

        /// <summary>
        /// A pointer to the first <see cref="Node"/>.
        /// </summary>
        private Node head;

        /// <summary>
        /// A pointer to the last <see cref="Node"/>.
        /// </summary>
        private Node tail;

        /// <summary>
        /// Keeps track of how many <see cref="Node"/>s we have in a <see cref="LinkedList"/>.
        /// </summary>
        /// <remarks>Time complexity: O(1)</remarks>
        public int Count { get; private set; }

        /// <summary>
        /// Adds a new <see cref="Node"/> to the end of a <see cref="LinkedList"/>.
        /// </summary>
        /// <param name="item">A piece of information to store.</param>
        /// <remarks>Time complexity: O(1)</remarks>
        public void AddLast(int item)
        {
            // Firstly, create a new node...
            var node = new Node(item);

            // then, check, if the list is empty...
            if (IsEmpty())
                // if so, point both head and tail to the newly created node.
                head = tail = node;
            // Otherwise...
            else
            {
                // make a reference from second to last node to the newly added node
                tail.Next = node;

                // finally, point tail to the newly added node.
                tail = node;
            }

            // Increment the amount of nodes in the list.
            Count++;
        }

        /// <summary>
        /// Adds a new <see cref="Node"/> to the beginning of a <see cref="LinkedList"/>.
        /// </summary>
        /// <param name="item">A piece of information to store.</param>
        /// <remarks>Time complexity: O(1)</remarks>
        public void AddFirst(int item)
        {
            // Firstly, create a new node...
            var node = new Node(item);

            // then, check, if the list is empty...
            if (IsEmpty())
                // if so, point both head and tail to the newly created node.
                head = tail = node;
            // Otherwise... 
            else
            {
                // pre-pend this item to the list
                node.Next = head;

                // finally, point head to the newly added node.
                head = node;
            }

            // Increment the amount of nodes in the list.
            Count++;
        }

        /// <summary>
        /// Traverses a whole <see cref="LinkedList"/> until it finds the desired <see cref="Node"/>.
        /// </summary>
        /// <param name="value">A value of a <see cref="Node"/> to search for.</param>
        /// <returns>A numerical value which represents a position in the sequence. -1 if an item wasn't found.</returns>
        /// <remarks>Time complexity: O(n)</remarks>
        public int IndexOf(int value)
        {
            // Unlike arrays there is no such concept of an "index" in a linked list. So we have to mock it.
            var index = 0;

            // Start traversing a list from the beginning...
            var current = head;

            // until we reach the end...
            while (current != null)
            {
                // if the value of the current node is equal to the desired value...
                if (current.Value == value)
                    // return its position immediately.
                    return index;

                // Otherwise; continue traversing a list...
                current = current.Next;

                // move on to the next "position"...
                index++;
            }

            // In case the given value does not exist, return -1 ("not found").
            return -1;
        }

        /// <summary>
        /// Traverses a whole <see cref="LinkedList"/> to see if a <see cref="Node"/> with the provided value exists.
        /// </summary>
        /// <param name="value">A value of a <see cref="Node"/> to search for.</param>
        /// <remarks>Time complexity: O(n)</remarks>
        /// <returns>True, if a <see cref="Node"/> with the provided value exists in a <see cref="LinkedList"/>.</returns>
        public bool Contains(int value) => IndexOf(value) != -1;

        /// <summary>
        /// Removes a <see cref="Node"/> from the beginning of a <see cref="LinkedList"/>.
        /// </summary>
        /// <remarks>Time complexity: O(1)</remarks>
        public void RemoveFirst()
        {
            // If we don't have any nodes in the list...
            if (IsEmpty())
                // raise an exception saying that the list is empty.
                throw new InvalidOperationException($"{nameof(LinkedList)} is empty.");

            // If we have only a single node in the list...
            if (head == tail)
            {
                // point both head and tail to null so that garbage collector can free the unlinked node from memory.
                head = tail = null;
            }
            // Otherwise...
            else
            {
                // Keep a reference to the second node in a sequence so that GC (garbage collector) doesn't free it.
                var second = head.Next;

                // Unlink the removed node.
                head.Next = null;

                // Point head to the second node in the list.
                head = second;
            }

            // Decrement the amount of nodes in the list.
            Count--;
        }

        /// <summary>
        /// Removes a <see cref="Node"/> from the end of a <see cref="LinkedList"/>.
        /// </summary>
        /// <remarks>Time complexity: O(n).</remarks>
        public void RemoveLast()
        {
            // If we don't have any nodes in the list...
            if (IsEmpty())
                // raise an exception saying that the list is empty.
                throw new InvalidOperationException($"{nameof(LinkedList)} is empty.");

            // If we have only a single node in the list...
            if (head == tail)
            {
                // point both head and tail to null so that garbage collector can free the unlinked node from memory.
                head = tail = null;
            }
            // Otherwise...
            else
            {
                // get the previous node before tail
                var previous = GetPrevious(tail);

                // shrink the list by pointing to the previous node
                tail = previous;

                // unlink the last node so that GC can free it.
                tail.Next = null;
            }


            // Finally, decrement the amount of nodes in the list.
            Count--;
        }

        /// <summary>
        /// Converts a <see cref="LinkedList"/> to <see cref="Array"/>.
        /// </summary>
        /// <returns>An <see cref="Array"/> representation of a <see cref="LinkedList"/>.</returns>
        public int[] ToArray()
        {
            // The result array that contains linked list's nodes as elements.
            var array = new int[Count];

            // Keep track of the current node position.
            var index = 0;

            // Start iterating from the beginning...
            var current = head;

            // until we reach the end...
            while (current != null)
            {
                // assign the value of the current node to the appropriate array position (index).
                array[index++] = current.Value;

                // Move on to the next node.
                current = current.Next;
            }

            return array;
        }

        /// <summary>
        /// Reverses a <see cref="LinkedList"/>.
        /// </summary>
        public void Reverse()
        {
            // If we don't have any nodes in the list...
            if (IsEmpty())
                // short circuit the execution.
                return;

            // Initially, point head to the first node.
            var previous = head;

            // Start traversing a list from the beginning...
            var current = head.Next;

            // until we reach the end...
            while (current != null)
            {
                // point to the upcoming node in a sequence
                var next = current.Next;

                // reverse the initial direction
                current.Next = previous;
                previous = current;
                current = next;
            }

            // Point tail to the first node.
            tail = head;

            // Unlink the initial direction.
            tail.Next = null;

            // Point head to the last node.
            head = previous;
        }

        /// <summary>
        /// Outputs nicely formatted <see cref="LinkedList"/>.
        /// </summary>
        /// <example>
        /// <code>
        /// var list = new LinkedList();
        /// list.AddLast(10);
        /// list.AddLast(20);
        /// list.AddLast(30);
        /// Console.WriteLine(list); // 10 -> 20 -> 30
        /// </code>
        /// </example>
        /// <returns>A "chain like" representation of the entire <see cref="LinkedList"/>.</returns>
        public override string ToString() => $"{string.Join(" -> ", ToArray())}";

        /// <summary>
        /// A helper method that finds out a previous <see cref="Node"/> in a sequence.
        /// </summary>
        /// <param name="node">The current <see cref="Node"/>.</param>
        /// <returns>A previous <see cref="Node"/> before the given one.</returns>
        private Node GetPrevious(Node node)
        {
            // Start traversing a list from the beginning...
            var current = head;

            // until we reach the end...
            while (current != null)
            {
                // if we have reached the desired node...
                if (current.Next == node)
                    // return the previous node.
                    return current;

                // Otherwise; keep traversing a list.
                current = current.Next;
            }

            // If we couldn't find a node before the current node, return null.
            return null;
        }

        /// <summary>
        /// A helper method that determines if a <see cref="LinkedList"/> is empty.
        /// </summary>
        /// <returns>True, if a <see cref="LinkedList"/> is empty.</returns>
        private bool IsEmpty() => head == null;
    }
}
