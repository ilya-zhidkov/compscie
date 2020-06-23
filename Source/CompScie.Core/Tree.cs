using System;

namespace CompScie.Core
{
    public class Tree
    {
        private class Node
        {
            public int Value { get; set; }
            public Node LeftChild { get; set; }
            public Node RightChild { get; set; }

            public Node(int value) => Value = value;

            public override string ToString() => $"Node = {Value}";
        }

        private Node root;

        public void Insert(int value)
        {
            var node = new Node(value);

            if (root == null)
            {
                root = node;
                return;
            }

            var current = root;

            while (true)
            {
                if (value < current.Value)
                {
                    if (current.LeftChild == null)
                    {
                        current.LeftChild = node;
                        break;
                    }

                    current = current.LeftChild;
                }
                else
                {
                    if (current.RightChild == null)
                    {
                        current.RightChild = node;
                        break;
                    }

                    current = current.RightChild;
                }
            }
        }

        public bool Find(int value)
        {
            var current = root;

            while (current != null)
            {
                if (value < current.Value)
                    current = current.LeftChild;
                else if (value > current.Value)
                    current = current.RightChild;
                else
                    return true;
            }
            return false;
        }

        public int Min()
        {
            if (root == null)
                throw new InvalidOperationException("Tree is empty.");

            var current = root;
            var last = current;

            while (current != null)
            {
                last = current;
                current = current.LeftChild;
            }

            return last.Value;
        }

        private int Min(Node root)
        {
            if (IsLeaf(root))
                return root.Value;

            var left = Min(root.LeftChild);
            var right = Min(root.RightChild);

            return Math.Min(Math.Min(left, right), root.Value);
        }

        private bool IsLeaf(Node node) => node.LeftChild == null && node.RightChild == null;
    }
}
