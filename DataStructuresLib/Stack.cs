using System;
using System.Collections.Generic;

namespace DataStructuresLib
{
    public class Stack<T>
    {
       /// Stack Linked list implementation

       class Node<T> 
        {
            public T value;
            public Node<T> next;

            public Node(T val, Node<T> next)
            {
                this.value = val;
                this.next = next;
            }
        }

        private Node<T> head;
        public int Count = 0;

        public void Push(T item)
        {
            Node<T> newNode = new Node<T>(item, head);
            this.head = newNode;
            this.Count++;
        }

        public T Pop()
        {
            CheckNotEmpty();

            var top = this.head;
            this.head = this.head.next;
            this.Count--;
            return top.value;
        }
        
        public T Peek()
        {
            return this.head.value;
        }

        private void CheckNotEmpty()
        {
            if (this.Count <= 0)
            {
                throw new Exception("Stack is empty.");
            }
        }

    }
}
