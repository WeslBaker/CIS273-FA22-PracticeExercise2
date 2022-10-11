﻿using System;
using System.Runtime.InteropServices;

namespace PracticeExercise2
{

    public class LinkedListNode<T>
    {
        public T Data { get; set; }
        public LinkedListNode<T> Next { get; set; }

        public LinkedListNode(T data = default(T), LinkedListNode<T> next=null)
        {
            Data = data;
            Next = next;
        }

        public override string ToString()
        {
            return Data.ToString();
        }

    }

	public class LinkedList<T>: IList<T>
    {
        public LinkedListNode<T> Head { get; set; }
        public LinkedListNode<T> Tail { get; set; }

        public LinkedList()
        {
            Head = null;
            Tail = null;
        }

        public T? First => throw new NotImplementedException();

        public T? Last => throw new NotImplementedException();

        public bool IsEmpty => throw new NotImplementedException();

        private int length = 0;
        public int Length => length;

        public void Append(T value)
        {

            var newNode = new LinkedListNode<T>(value);

            if (IsEmpty)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                Tail = newNode;
            }

            length++;
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            length = 0;
        }

        public bool Contains(T value)
        {
            throw new NotImplementedException();
        }

        public int FirstIndexOf(T value)
        {
            int index = 0;

            var currentNode = Head;

            while(currentNode!=null)
            {
                if( currentNode.Data.Equals(value) )
                {
                    return index;
                }
                index++;
                currentNode = currentNode.Next;

            }

            return -1;
        }

        public T Get(int index)
        {
            throw new NotImplementedException();
        }

        public void InsertAfter(T newValue, int existingValue)
        {
            throw new NotImplementedException();
            length++;
        }

        public void InsertAt(T value, int index)
        {
            throw new NotImplementedException();
            length++;
        }

        public void Prepend(T value)
        {
            throw new NotImplementedException();
            length++;
        }

        public void Remove(T value)
        {
            //Handle an empty list
            if(IsEmpty)
            {
                return;
            }

            //If removing the head
            if(Head.Data.Equals(value))
            {
                //1-element list
                if (Head == Tail)
                {
                    Tail = null;
                    Head = null;
                }
                else
                {
                Head = Head.Next;
                }
                length--;
                return;
            }

            var currentNode = Head;
            while(currentNode != null)
            {
                if(currentNode.Next != null && currentNode.Next.Data.Equals(value))
                {
                    var nodeToDelete = currentNode.Next;
                    length--;
                    if(nodeToDelete == Tail)
                    {
                        currentNode.Next = null;
                        Tail = currentNode;
                    }
                    else
                    {
                        currentNode.Next = currentNode.Next.Next;
                        nodeToDelete.Next = null;
                    }
                    return;
                }
                currentNode = currentNode.Next;
            }
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
            length--;

        }

        public IList<T> Reverse()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string result = "[ ";

            for(var currentNode = Head; currentNode != null; currentNode = currentNode.Next)
            {
                if (currentNode != Tail)
                {
                    result += $"{currentNode.ToString()}, ";
                }
                else
                {
                    result += $"{currentNode.ToString()} ]";
                }
            }
            return result;
        }
    }
}

