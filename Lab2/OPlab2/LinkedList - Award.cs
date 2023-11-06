using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPlab2
{
    /// <summary>
    /// Linked list class
    /// </summary>
    public class LinkedListAwards
    {
        /// <summary>
        /// Private Node class
        /// </summary>
        private class Node
        {
            public Award Data { get; set; }
            public Node Link { get; set; }

            /// <summary>
            /// Node constructor
            /// </summary>
            /// <param name="value">Node's value</param>
            /// <param name="address">Shows to next node</param>
            public Node(Award value, Node address)
            {
                this.Data = value;
                this.Link = address;
            }

            /// <summary>
            /// Finds necessary node by index
            /// </summary>
            /// <param name="k">Index</param>
            /// <returns>Returns node</returns>
            public Node FindNode(int k)
            {
                Node data = this;
                for (int i = 0; i < k; i++)
                {
                    data = data.Link;
                }
                return data;
            }
        }

        private Node head;
        private Node tail;
        private int size;

        /// <summary>
        /// Linked list award constructor
        /// </summary>
        public LinkedListAwards()
        {
            this.head = null;
            this.tail = null;
            this.size = 0;
        }

        /// <summary>
        /// Counts size of linked list
        /// </summary>
        /// <returns>Size of linked list</returns>
        public int Count()
        {
            return this.size;
        }

        /// <summary>
        /// Add object to list
        /// </summary>
        /// <param name="award">An object</param>
        public void Add(Award award)
        {
            if (this.head == null)
            {
                this.head = new Node(award, this.head);
                this.tail = this.head;
            }
            else
            {
                Node newNode = new Node(award, null);
                this.tail.Link = newNode;
                this.tail = newNode;
            }
            size++;
        }

        /// <summary>
        /// Gets a specific object
        /// </summary>
        /// <param name="k">Index</param>
        /// <returns>Returns award object</returns>
        public Award Get(int k)
        {
            if (k < 0 || k >= size)
            {
                return null;
            }
             Node current = this.head.FindNode(k);
            return current.Data;
        }

        
        
    }
}