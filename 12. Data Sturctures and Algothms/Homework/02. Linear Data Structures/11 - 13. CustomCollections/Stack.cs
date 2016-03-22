using System.Collections;

namespace CustomCollections
{
    using System;
    using System.Collections.Generic;

    public class Stack<T> : IEnumerable<T>
    {
        private const int InitialSize = 4;

        private const int SizeMultiplier = 2;

        private const int EmptyStackTopIndex = -1;

        public Stack()
        {
            this.Array = new T[Stack<T>.InitialSize];
            this.TopIndex = Stack<T>.EmptyStackTopIndex;
        }

        public int Count
        {
            get
            {
                return this.TopIndex + 1;
            }
        }

        private int TopIndex { get; set; }

        private T[] Array { get; set; }

        public void Push(T item)
        {
            this.TopIndex++;
            if (this.Array.Length == this.TopIndex)
            {
                this.ResizeArray();
            }

            this.Array[this.TopIndex] = item;
        }

        public T Pop()
        {
            if (this.TopIndex < 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            T item = this.Array[this.TopIndex];

            this.Array[this.TopIndex] = default(T);

            this.TopIndex--;

            return item;
        }

        public T Peek()
        {
            return this.Array[this.TopIndex];
        }

        public bool Contains(T item)
        {
            for (int i = 0; i <= this.TopIndex; i++)
            {
                if (this.Array[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public void Clear()
        {
            for (int i = 0; i <= this.TopIndex; i++)
            {
                this.Array[i] = default(T);
            }

            this.TopIndex = Stack<T>.EmptyStackTopIndex;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.TopIndex; i >= 0; i--)
            {
                yield return this.Array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void ResizeArray()
        {
            int size = this.Array.Length * Stack<T>.SizeMultiplier;
            T[] newArray = new T[size];

            this.Array.CopyTo(newArray, 0);

            this.Array = newArray;
        }
    }
}