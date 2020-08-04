using System;
using System.Collections;
using System.Collections.Generic;

namespace CompScie.Core
{
    /// <summary>
    /// Represents a linear data structure for storing a list of objects in a sequential order. 
    /// Unlike arrays they can grow and shrink automatically.
    /// </summary>
    /// <typeparam name="T">A type of value to store.</typeparam>
    public class LinkedList<T> : IEnumerable<T>
    {
        /// <summary>
        /// Represents a basic building block of a <see cref="LinkedList{T}"/>.
        /// </summary>
        /// <remarks>
        /// Each <see cref="Node"/> holds two pieces of information. A value and a reference to the next node or null. 
        /// Conventionally, the first node is called a "head" and the last is called a "tail".
        /// </remarks>
        public class Node
        {
            /// <summary>
            /// A piece of information that each <see cref="Node"/> holds.
            /// </summary>
            public T Data { get; private set; }

            /// <summary>
            /// A reference to the next <see cref="Node"/> in a sequence.
            /// </summary>
            public Node Next { get; set; }

            /// <summary>
            /// Constructs a new instance of a <see cref="Node"/>.
            /// </summary>
            /// <param name="value">A piece of information to store.</param>
            public Node(T value) => Data = value;
        }

        /// <summary>
        /// A pointer to the first <see cref="Node"/>.
        /// </summary>
        public Node Head { get; private set; }

        /// <summary>
        /// A pointer to the last <see cref="Node"/>.
        /// </summary>
        public Node Tail { get; private set; }

        /// <summary>
        /// Keeps track of how many nodes are presented in the <see cref="LinkedList{T}"/>.
        /// </summary>
        /// <remarks>Time complexity: O(1).</remarks>
        public int Count { get; private set; }

        /// <summary>
        /// Adds a new <see cref="Node"/> to the end of the <see cref="LinkedList{T}"/>.
        /// </summary>
        /// <param name="item">A piece of information to store.</param>
        /// <typeparam name="T">A type of value to store.</typeparam>
        /// <remarks>Time complexity: O(1).</remarks>
        public void AddLast(T item)
        {
            // Firstly, create a new node...
            var node = new Node(item);

            // then, check, if the list is empty...
            if (IsEmpty())
            {
                // if so, point both head and tail to the newly created node.
                Head = Tail = node;
            }
            // Otherwise...
            else
            {
                // make a reference from second to last node to the newly added node
                Tail.Next = node;

                // finally, point tail to the newly added node.
                Tail = node;
            }

            // Increment the amount of nodes in the list.
            Count++;
        }

        /// <summary>
        /// Adds a new <see cref="Node"/> to the beginning of the <see cref="LinkedList{T}"/>.
        /// </summary>
        /// <param name="item">A piece of information to store.</param>
        /// <typeparam name="T">A type of value to store.</typeparam>
        /// <remarks>Time complexity: O(1).</remarks>
        public void AddFirst(T item)
        {
            // Firstly, create a new node...
            var node = new Node(item);

            // then, check, if the list is empty...
            if (IsEmpty())
            {
                // if so, point both head and tail to the newly created node.
                Head = Tail = node;
            }
            // Otherwise... 
            else
            {
                // pre-pend this item to the list
                node.Next = Head;

                // finally, point head to the newly added node.
                Head = node;
            }

            // Increment the amount of nodes in the list.
            Count++;
        }

        /// <summary>
        /// Traverses the whole <see cref="LinkedList{T}"/> until it finds the desired <see cref="Node"/>.
        /// </summary>
        /// <param name="value">A value of a <see cref="Node"/> to search for.</param>
        /// <typeparam name="T">A type of value to store.</typeparam>
        /// <remarks>Time complexity: O(n).</remarks>
        /// <returns>A numerical value which represents a position in the sequence. -1 if an item wasn't found.</returns>
        public int IndexOf(T value)
        {
            // Unlike arrays there is no such concept of an "index" in a linked list. So we have to mock it.
            var index = 0;

            // Start traversing a list from the beginning...
            var current = Head;

            // until we reach the end...
            while (current != null)
            {
                // if the value of the current node is equal to the desired value...
                if (Equals(current.Data, value))
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
        /// <typeparam name="T">A type of value to store.</typeparam>
        /// <remarks>Time complexity: O(n).</remarks>
        /// <returns>True, if a <see cref="Node"/> with the provided value exists in a <see cref="LinkedList{T}"/>.</returns>
        public bool Contains(T value) => IndexOf(value) != -1;

        /// <summary>
        /// Removes a <see cref="Node"/> from the <see cref="LinkedList{T}"/>.
        /// </summary>
        /// <param name="item">An item to remove.</param>
        /// <remarks>Time complexity: O(n).</remarks>
        public void Remove(T item)
        {
            // If we don't have any nodes in the list...
            if (IsEmpty())
                // raise an exception saying that the list is empty.
                throw new InvalidOperationException($"{nameof(LinkedList<T>)} is empty.");

            // If it's the first node...
            if (Equals(Head.Data, item))
            {
                // remove it.
                RemoveFirst();

                // Short circuit the execution.
                return;
            }

            // Otherwise; start traversing the list from the beginning...
            var current = Head;

            // keep track of the previous node so that we can
            // shrink the list by pointing to the upcoming node
            // when an item is removed.
            var previous = null as Node;

            // until we reach the end...
            while (current != null)
            {
                // if values don't match...
                if (!Equals(current.Data, item))
                {
                    // remember the previously visited node
                    previous = current;

                    // move on the to the next node.
                    current = current.Next;

                    // In case we didn't find the match at all...
                    if (current == null)
                        // raise an exception saying that a node with this value wasn't found.
                        throw new InvalidOperationException($"{item} wasn't found in the list.");
                }
                // Otherwise; if values match...
                else
                {
                    // unlink a node with this value from the list
                    // by pointing to the upcoming node in a sequence.
                    previous.Next = current.Next;

                    // Decrease the amount of nodes in the list.
                    Count--;

                    // No need to loop further.
                    break;
                }
            }
        }

        /// <summary>
        /// Removes a <see cref="Node"/> from the beginning of a <see cref="LinkedList{T}"/>.
        /// </summary>
        /// <remarks>Time complexity: O(1).</remarks>
        public void RemoveFirst()
        {
            // If we don't have any nodes in the list...
            if (IsEmpty())
                // raise an exception saying that the list is empty.
                throw new InvalidOperationException($"{nameof(LinkedList<T>)} is empty.");

            // If we have only a single node in the list...
            if (Head == Tail)
            {
                // point both head and tail to null so that garbage collector can free the unlinked node from memory.
                Head = Tail = null;
            }
            // Otherwise...
            else
            {
                // Keep a reference to the second node in a sequence so that GC (garbage collector) doesn't free it.
                var second = Head.Next;

                // Unlink the removed node.
                Head.Next = null;

                // Point head to the second node in the list.
                Head = second;
            }

            // Decrease the amount of nodes in the list.
            Count--;
        }

        /// <summary>
        /// Removes a <see cref="Node"/> from the end of a <see cref="LinkedList"/>.
        /// </summary>
        /// <typeparam name="T">A type of value to store.</typeparam>
        /// <remarks>Time complexity: O(n).</remarks>
        public void RemoveLast()
        {
            // If we don't have any nodes in the list...
            if (IsEmpty())
                // raise an exception saying that the list is empty.
                throw new InvalidOperationException($"{nameof(LinkedList<T>)} is empty.");

            // If we have only a single node in the list...
            if (Head == Tail)
            {
                // point both head and tail to null so that garbage collector can free the unlinked node from memory.
                Head = Tail = null;
            }
            // Otherwise...
            else
            {
                // get the previous node before tail
                var previous = GetPrevious(Tail);

                // shrink the list by pointing to the previous node
                Tail = previous;

                // unlink the last node so that GC can free it.
                Tail.Next = null;
            }

            // Finally, decrease the amount of nodes in the list.
            Count--;
        }

        /// <summary>
        /// Converts a <see cref="LinkedList{T}"/> to an <see cref="Array"/>.
        /// </summary>
        /// <returns>An <see cref="Array"/> representation of a <see cref="LinkedList{T}"/>.</returns>
        public T[] ToArray()
        {
            // The result array that contains linked list's nodes as elements.
            var array = new T[Count];

            // Keep track of the current node position.
            var index = 0;

            // Start iterating from the beginning...
            var current = Head;

            // until we reach the end...
            while (current != null)
            {
                // assign the value of the current node to the appropriate array position (index).
                array[index++] = current.Data;

                // Move on to the next node.
                current = current.Next;
            }

            // Return the final transformed linked list to the array data structure.
            return array;
        }

        /// <summary>
        /// Reverses a <see cref="LinkedList{T}"/>.
        /// </summary>
        public void Reverse()
        {
            // If we don't have any nodes in the list...
            if (IsEmpty())
                // short circuit the execution.
                return;

            // Initially, point head to the first node.
            var previous = Head;

            // Start traversing a list from the beginning...
            var current = Head.Next;

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
            Tail = Head;

            // Unlink the initial direction.
            Tail.Next = null;

            // Point head to the last node.
            Head = previous;
        }

        /// <summary>
        /// Outputs "nicely" formatted <see cref="LinkedList{T}"/>.
        /// </summary>
        /// <example>
        /// <code>
        /// var list = new LinkedList<int>();
        /// list.AddLast(10);
        /// list.AddLast(20);
        /// list.AddLast(30);
        /// Console.WriteLine(list); // 10 -> 20 -> 30
        /// </code>
        /// </example>
        /// <returns>A "chain like" representation of the entire <see cref="LinkedList{T}"/>.</returns>
        public override string ToString() => $"{string.Join<T>(" -> ", ToArray())}";

        /// <summary>
        /// Allows an elegant iteration over a generic collection.
        /// </summary>
        /// <example>
        /// <code>
        /// var list = new LinkedList<int>();
        /// list.AddLast(10);
        /// list.AddLast(20);
        /// list.AddLast(30);
        /// 
        /// foreach (var node in list)
        ///     Console.Write($"{node} "); // 10 20 30
        /// </code>
        /// </example>
        /// <returns>A current value of a <see cref="Node"/>.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            // Start iterating from the beginning of the list.
            var current = Head;

            // As long as there are nodes...
            while (current != null)
            {
                // return the value of a current node
                yield return current.Data;

                // move on to the next node.
                current = current.Next;
            }
        }

        /// <summary>
        /// Allows an elegant iteration over a non-generic collection.
        /// </summary>
        /// <example>
        /// <code>
        /// var list = new LinkedList();
        /// list.AddLast(10);
        /// list.AddLast(20);
        /// list.AddLast(30);
        /// 
        /// foreach (var node in list)
        ///     Console.Write($"{node} "); // 10 20 30
        /// </code>
        /// </example>
        /// <returns>A current value of a <see cref="Node"/>.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return GetEnumerator();
        }

        /// <summary>
        /// A helper method that finds out a previous <see cref="Node"/> in a sequence.
        /// </summary>
        /// <param name="node">The current <see cref="Node"/>.</param>
        /// <returns>A previous <see cref="Node"/> before the given one.</returns>
        private Node GetPrevious(Node node)
        {
            // Start traversing a list from the beginning...
            var current = Head;

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
        /// A helper method that determines if a <see cref="LinkedList{T}"/> is empty.
        /// </summary>
        /// <returns>True, if the head node does not point to any node in a sequence.</returns>
        private bool IsEmpty() => Head == null;
    }
}
