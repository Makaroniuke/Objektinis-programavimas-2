using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPlab2
{
    /// <summary>
    /// Private node class
    /// </summary>
    public class Node<E> where E : IComparable<E>, IEquatable<E>
    {
        public E Data { get; set; }
        public Node<E> Link { get; set; }

        /// <summary>
        /// Node constructor
        /// </summary>
        /// <param name="value">Node's value</param>
        /// <param name="address">Shows to next node</param>
        public Node(E value, Node<E> address)
        {
            this.Data = value;
            this.Link = address;
        }

        /// <summary>
        /// Finds necessary node by index
        /// </summary>
        /// <param name="k">Index</param>
        /// <returns>Returns node</returns>
        public Node<E> FindNode(int k)
        {
            Node<E> data = this;
            for (int i = 0; i < k; i++)
            {
                data = data.Link;
            }
            return data;
        }
    }




    /// <summary>
    /// Linked list class
    /// </summary>
    public sealed class LinkedList<T> : IEnumerable<T> where T: IComparable<T>, IEquatable<T>
    {       
        private Node<T> head;
        private Node<T> tail;
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
        public void Add(T value)
        {
            if (this.head == null)
            {
                this.head = new Node<T>(value, this.head);
                this.tail = this.head;
            }
            else
            {
                Node<T> newNode = new Node<T>(value, null);
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
        public T Get(int k)
        {
            if (k < 0 || k >= size)
            {
                return default;
            }
            Node<T> current = this.head.FindNode(k);
            return current.Data;
        }


        /// <summary>
        /// Method to sort list 
        /// </summary>
        public void SortBubble()
        {
            if (this.head == null)
            {
                return;
            }
            for (Node<T> d = head; d != null; d = d.Link)
            {
                bool sorted = true;
                Node<T> element = this.head;
                for (Node<T> d2 = this.head.Link; d2 != null; d2 = d2.Link)
                {
                    if (element.Data.CompareTo(d2.Data) < 0)
                    {
                        T value = element.Data;
                        element.Data = d2.Data;
                        d2.Data = value;
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

        /// <summary>
        /// Get enumerator
        /// </summary>
        /// <returns>data</returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (Node<T> dd = head; dd != null; dd = dd.Link)
            {
                yield return dd.Data;
            }
        }

        /// <summary>
        /// get enumerator
        /// </summary>
        /// <returns>enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
    }
}