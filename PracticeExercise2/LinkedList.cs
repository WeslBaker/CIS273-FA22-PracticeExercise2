using System;
using System.Reflection;
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

        public T? First => IsEmpty ? default(T) : Head.Data;

        public T? Last => IsEmpty ? default(T) : Tail.Data;

        public bool IsEmpty => length == 0;

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
            for(var currentNode = Head; currentNode != null; currentNode = currentNode.Next)
            {
                if(currentNode.Data.Equals(value))
                {
                    return true;
                }
            }
            return false;
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
            if(index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                int currentIndex = 0;
                for(var currentNode = Head; currentNode != null; currentNode = currentNode.Next, currentIndex++)
                {
                    if(currentIndex.Equals(index))
                    {
                        return currentNode.Data;
                    }
                }
            }
            return default(T);
        }

        public void InsertAfter(T newValue, int existingValue)
        {
            var currentNode = Head;
            var newNode = new LinkedListNode<T>(newValue);

            while (currentNode != null)
            {
                if (currentNode.Data.Equals(existingValue))
                {
                    if(currentNode == Tail)
                    {
                        currentNode.Next = newNode;
                        Tail = newNode;
                        length++;
                        return;
                    }
                    newNode.Next = currentNode.Next;
                    currentNode.Next = newNode;
                    length++;
                    return;
                }
                currentNode = currentNode.Next;
            }
            Append(newValue);
        }

        public void InsertAt(T value, int index)
        {
            var currentNode = Head;
            int currentIndex = 0;

            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
            if (index == 0)
            {
                Prepend(value);
            }
            while(currentNode != null)
            {
                if(currentIndex == index - 1)
                {
                    var newNode = new LinkedListNode<T>(value);
                    newNode.Next = currentNode.Next;
                    currentNode.Next = newNode;
                    length++;

                    if(currentNode == Tail)
                    {
                        Tail = newNode ;
                    }
                }
                
                currentNode = currentNode.Next;
                currentIndex++;
            }
        }

        public void Prepend(T value)
        {
            var newNode = new LinkedListNode<T>(value);
            if(IsEmpty)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head = newNode;
            }
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
            if(index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }

            //Handle an empty list
            if(IsEmpty)
            {
                return;
            }

            //If removing the head
            if(index == 0)
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
            int currentIndex = 0;
            while (currentNode != null)
            {
                if (currentNode.Next != null && currentIndex == index - 1)
                {
                    var nodeToDelete = currentNode.Next;
                    if (nodeToDelete == Tail)
                    {
                        currentNode.Next = null;
                        Tail = currentNode;
                    }
                    else
                    {
                        currentNode.Next = currentNode.Next.Next;
                        nodeToDelete.Next = null;
                    }
                    length--;
                    return;
                }
                currentNode = currentNode.Next;
                currentIndex++;
            }
        }

        public IList<T> Reverse()
        {
            IList<T> reversed = new LinkedList<T>();
            var currentNode = Head;

            //Handle an empty list
            if(IsEmpty)
            {
                return reversed;
            }
            while(currentNode != null)
            {
                reversed.Prepend(currentNode.Data);
                currentNode = currentNode.Next;
            }
            return reversed;
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
                    result += $"{currentNode.ToString()}";
                }
            }
            result += " ]";

            return result;
        }
    }
}


