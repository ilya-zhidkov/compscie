﻿using System;

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

            public override string ToString() => $"Prvek = {Value}";
        }

        private Node root;

        public void Insert(int value) => root = Insert(root, value);

        private Node Insert(Node root, int value)
        {
            if (root == null)
                return new Node(value);

            if (value < root.Value)
                root.LeftChild = Insert(root.LeftChild, value);
            if (value > root.Value)
                root.RightChild = Insert(root.RightChild, value);

            return root;
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
                throw new InvalidOperationException("Tento prvek neexistuje.");

            var current = root;
            var last = current;

            while (current != null)
            {
                last = current;
                current = current.LeftChild;
            }

            return last.Value;
        }

        public void Remove(int key) => Remove(root, key);

        public void TraversePreOrder() => TraversePreOrder(root);

        private void TraversePreOrder(Node root)
        {
            if (root == null)
                return;

            Console.Write($"{root.Value} ");
            TraversePreOrder(root.LeftChild);
            TraversePreOrder(root.RightChild);
        }

        private Node Remove(Node root, int value)
        {
            if (root == null)
                throw new InvalidOperationException("Tento prvek neexistuje.");

            if (value < root.Value)
                root.LeftChild = Remove(root.LeftChild, value);
            else if (value > root.Value)
                root.RightChild = Remove(root.RightChild, value);
            else
            {
                if (root.LeftChild == null)
                    return root.RightChild;
                else if (root.RightChild == null)
                    return root.LeftChild;

                root.Value = Min(root.RightChild);
                root.RightChild = Remove(root.RightChild, root.Value);
            }

            return root;
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
