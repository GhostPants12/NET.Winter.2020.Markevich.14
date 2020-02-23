using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace BinarySearchTree
{
    /// <summary>Contains the sides of the node.</summary>
    public enum Side
    {
        /// <summary>The left side.</summary>
        Left,

        /// <summary>The right side.</summary>
        Right,
    }

    public class Node<T>
    {
        /// <summary>Initializes a new instance of the <see cref="Node{T}"/> class.</summary>
        /// <param name="data">The data.</param>
        public Node(T data)
        {
            this.Data = data;
        }

        /// <summary>Gets or sets the left node.</summary>
        /// <value>The left node.</value>
        public Node<T> LeftNode { get; set; }

        /// <summary>Gets or sets the right node.</summary>
        /// <value>The right node.</value>
        public Node<T> RightNode { get; set; }

        /// <summary>Gets or sets the parent node.</summary>
        /// <value>The parent node.</value>
        public Node<T> ParentNode { get; set; }

        /// <summary>Gets or sets the data.</summary>
        /// <value>The data.</value>
        public T Data { get; set; }

        /// <summary>Gets the node side.</summary>
        /// <value>The node side.</value>
        public Side? NodeSide =>
            this.ParentNode == null
                ? (Side?)null
                : this.ParentNode.LeftNode == this
                    ? Side.Left
                    : Side.Right;
    }
}
