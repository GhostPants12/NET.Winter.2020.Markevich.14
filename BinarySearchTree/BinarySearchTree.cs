using System;
using System.Collections.Generic;

namespace BinarySearchTree
{
    public class BinarySearchTree<T>
    {
        private readonly IComparer<T> comparer;

        /// <summary>Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.</summary>
        /// <param name="root">The root.</param>
        public BinarySearchTree(Node<T> root)
            : this(root, Comparer<T>.Default) { }

        /// <summary>Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.</summary>
        /// <param name="root">The root.</param>
        /// <param name="comparer">The comparer.</param>
        public BinarySearchTree(Node<T> root, IComparer<T> comparer)
        {
            this.RootNode = root;
            this.comparer = comparer;
        }

        /// <summary>Gets the root node.</summary>
        /// <value>The root node.</value>
        public Node<T> RootNode { get; private set; }

        /// <summary>Adds the specified node to the tree.</summary>
        /// <param name="node">The node.</param>
        /// <param name="currentNode">The current node.</param>
        /// <returns>The added node.</returns>
        public Node<T> Add(Node<T> node, Node<T> currentNode = null)
        {
            currentNode = currentNode ?? this.RootNode;
            node.ParentNode = currentNode;
            int result = this.comparer.Compare(node.Data, currentNode.Data);
            return (result == 0)
                ? currentNode
                : result < 0
                    ? currentNode.LeftNode == null
                        ? (currentNode.LeftNode = node)
                        : this.Add(node, currentNode.LeftNode)
                    : currentNode.RightNode == null
                        ? (currentNode.RightNode = node)
                        : this.Add(node, currentNode.RightNode);
        }

        /// <summary>Adds the node with the specified data.</summary>
        /// <param name="data">The data.</param>
        /// <returns>The added note.</returns>
        public Node<T> Add(T data)
        {
            return this.Add(new Node<T>(data));
        }

        /// <summary>Gets the sequence of the nodes in tree by preorder tree walk.</summary>
        /// <param name="startNode">The start node.</param>
        /// <returns>The sequence of the nodes in tree.</returns>
        public IEnumerable<Node<T>> PreorderTree(Node<T> startNode)
        {
            if (startNode != null)
            {
                yield return startNode;
                foreach (var node in this.PreorderTree(startNode.LeftNode))
                {
                    yield return node;
                }

                foreach (var node in this.PreorderTree(startNode.RightNode))
                {
                    yield return node;
                }
            }
        }

        /// <summary>Gets the sequence of the nodes in tree by postorder tree walk.</summary>
        /// <param name="startNode">The start node.</param>
        /// <returns>The sequence of the nodes in tree.</returns>
        public IEnumerable<Node<T>> PostorderTree(Node<T> startNode)
        {
            if (startNode != null)
            {
                foreach (var node in this.PostorderTree(startNode.LeftNode))
                {
                    yield return node;
                }

                foreach (var node in this.PostorderTree(startNode.RightNode))
                {
                    yield return node;
                }

                yield return startNode;
            }
        }

        /// <summary>Gets the sequence of the nodes in tree by inorder tree walk.</summary>
        /// <param name="startNode">The start node.</param>
        /// <returns>The sequence of the nodes in tree.</returns>
        public IEnumerable<Node<T>> InorderTree(Node<T> startNode)
        {
            if (startNode != null)
            {
                foreach (var node in this.InorderTree(startNode.LeftNode))
                {
                    yield return node;
                }

                yield return startNode;
                foreach (var node in this.InorderTree(startNode.RightNode))
                {
                    yield return node;
                }
            }
        }

        /// <summary>Removes the specified node from the tree.</summary>
        /// <param name="node">The node.</param>
        public void Remove(Node<T> node)
        {
            if (node == null)
            {
                return;
            }

            var currentNodeSide = node.NodeSide;
            if (node.LeftNode == null && node.RightNode == null)
            {
                if (currentNodeSide == Side.Left)
                {
                    node.ParentNode.LeftNode = null;
                }
                else
                {
                    node.ParentNode.RightNode = null;
                }
            }
            else if (node.LeftNode == null)
            {
                if (currentNodeSide == Side.Left)
                {
                    node.ParentNode.LeftNode = node.RightNode;
                }
                else
                {
                    node.ParentNode.RightNode = node.RightNode;
                }

                node.RightNode.ParentNode = node.ParentNode;
            }
            else if (node.RightNode == null)
            {
                if (currentNodeSide == Side.Left)
                {
                    node.ParentNode.LeftNode = node.LeftNode;
                }
                else
                {
                    node.ParentNode.RightNode = node.LeftNode;
                }

                node.LeftNode.ParentNode = node.ParentNode;
            }
            else
            {
                switch (currentNodeSide)
                {
                    case Side.Left:
                        node.ParentNode.LeftNode = node.RightNode;
                        node.RightNode.ParentNode = node.ParentNode;
                        this.Add(node.LeftNode, node.RightNode);
                        break;
                    case Side.Right:
                        node.ParentNode.RightNode = node.RightNode;
                        node.RightNode.ParentNode = node.ParentNode;
                        this.Add(node.LeftNode, node.RightNode);
                        break;
                    default:
                        var bufLeft = node.LeftNode;
                        var bufRightLeft = node.RightNode.LeftNode;
                        var bufRightRight = node.RightNode.RightNode;
                        node.Data = node.RightNode.Data;
                        node.RightNode = bufRightRight;
                        node.LeftNode = bufRightLeft;
                        this.Add(bufLeft, node);
                        break;
                }
            }
        }
    }
}
