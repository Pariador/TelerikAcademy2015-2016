namespace CustomCollections
{
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedQueue<T> : IEnumerable<T>
    {
        public LinkedQueue()
        {
            this.List = new LinkedList<T>();
        }

        private LinkedList<T> List { get; set; }

        public void Enqueue(T item)
        {
            this.List.AddLast(item);
        }

        public T Dequeue()
        {
            T item = this.List.First.Value;
            this.List.RemoveFirst();
            return item;
        }

        public T Peek()
        {
            return this.List.First.Value;
        }

        public int Count()
        {
            return this.List.Count;
        }

        public bool Contains(T item)
        {
            return this.List.Contains(item);
        }

        public void Clear()
        {
            this.List.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.List.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}