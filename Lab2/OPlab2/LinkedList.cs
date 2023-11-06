using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPlab2
{
    /// <summary>
    /// Linked list class
    /// </summary>
    public class LinkedList
    {
        /// <summary>
        /// Private node class
        /// </summary>
        private class Node
        {
            public Worker Data { get; set; }
            public Node Link { get; set; }

            /// <summary>
            /// Node constructor
            /// </summary>
            /// <param name="value">Node's value</param>
            /// <param name="address">Shows to next node</param>
            public Node(Worker value, Node address)
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
        /// Linked list constructor
        /// </summary>
        public LinkedList()
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
        /// <param name="worker">An object</param>
        public void Add(Worker worker)
        {
            if (this.head == null)
            {
                this.head = new Node(worker, this.head);
                this.tail = this.head;
            }
            else
            {
                Node newNode = new Node(worker, null);
                this.tail.Link = newNode;
                this.tail = newNode;
            }
            size++;
        }

        /// <summary>
        /// Gets a specific object
        /// </summary>
        /// <param name="k">Index</param>
        /// <returns>Returns worker object</returns>
        public Worker Get(int k)
        {
            if (k < 0 || k >= size)
            {
                return null;
            }
             Node current = this.head.FindNode(k);
            return current.Data;
        }

        /// <summary>
        /// Method to sort list 
        /// </summary>
        public void sortBubble()
        {
            if (this.head == null)
            {
                return;
            }
            for (Node d = head; d != null; d = d.Link)
            {
                bool sorted = true;
                Node element = this.head;
                for (Node d2 = this.head.Link; d2 != null; d2 = d2.Link)
                {
                    if (element.Data > d2.Data)
                    {
                        Worker worker = element.Data;
                        element.Data = d2.Data;
                        d2.Data = worker;
                        sorted = false;
                    }
                    element = d2;
                }
                if (sorted)
                {
                    return;
                }
            }
        }
    }
}