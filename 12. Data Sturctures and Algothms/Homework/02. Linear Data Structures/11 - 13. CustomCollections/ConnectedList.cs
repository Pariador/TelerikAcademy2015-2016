namespace CustomCollections
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ConnectedList<T> : IEnumerable<T>
    {
        public ConnectedListNode<T> First { get; set; }

        public ConnectedListNode<T> Last { get; set; }

        public void AddBefore(ConnectedListNode<T> node, T item)
        {
            ConnectedListNode<T> newNode = this.CreateNode(item);


            newNode.Next = node;
            newNode.Previous = node.Previous;

            newNode.Next.Previous = newNode;

            if (newNode.Previous != null)
            {
                newNode.Previous.Next = newNode;
            }
            else
            {
                this.First = newNode;
            }
        }

        public void AddAfter(ConnectedListNode<T> node, T item)
        {
            ConnectedListNode<T> newNode = this.CreateNode(item);

            newNode.Previous = node;
            newNode.Next = node.Next;

            newNode.Previous.Next = newNode;

            if (newNode.Next != null)
            {
                newNode.Next.Previous = newNode;
            }
            else
            {
                this.Last = newNode;
            }
        }

        public void AddFirst(T item)
        {
            if (this.First == null)
            {
                this.AddFirstInList(item);
                return;
            }

            this.AddBefore(this.First, item);
        }

        public void AddLast(T item)
        {
            if (this.Last == null)
            {
                this.AddFirstInList(item);
                return;
            }

            this.AddAfter(this.Last, item);
        }

        public ConnectedListNode<T> Find(T query)
        {
            ConnectedListNode<T> result = null;

            this.ForEachNode(node =>
            {
                if (node.Value.Equals(query))
                {
                    result = node;
                    return true;
                }

                return false;
            });

            return result;
        }

        public void Remove(ConnectedListNode<T> node)
        {
            if (node == this.First)
            {
                node.Next.Previous = null;
                this.First = this.First.Next;
            }
            else if (node == this.Last)
            {
                node.Previous.Next = null;
                this.Last = this.Last.Previous;
            }
            else
            {
                node.Previous.Next = node.Next;
                node.Next.Previous = node.Previous;
            }
        }

        public bool Remove(T item)
        {
            ConnectedListNode<T> node = this.Find(item);
            if (node == null)
            {
                return false;
            }

            this.Remove(node);

            return true;
        }

        public void RemoveFirst()
        {
            this.Remove(this.First);
        }

        public void RemoveLast()
        {
            this.Remove(this.Last);
        }

        public int Count()
        {
            int count = 0;

            foreach (T item in this)
            {
                count++;
            }

            return count;
        }

        public bool Contains(T query)
        {
            foreach (T item in this)
            {
                if (item.Equals(query))
                {
                    return true;
                }
            }

            return false;
        }

        public void Clear()
        {
            this.First = null;
            this.Last = null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (this.First != null)
            {
                ConnectedListNode<T> current = this.First;
                while (current != null)
                {
                    yield return current.Value;

                    current = current.Next;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void ForEachNode(Func<ConnectedListNode<T>, bool> func)
        {
            if (this.First == null)
            {
                return;
            }

            ConnectedListNode<T> current = this.First;
            while (current != null)
            {
                bool stopLoop = func(current);

                if (stopLoop)
                {
                    break;
                }

                current = current.Next;
            }
        }

        private void AddFirstInList(T item)
        {
            this.First = this.CreateNode(item);
            this.Last = this.First;
        }

        private ConnectedListNode<T> CreateNode(T value)
        {
            return new ConnectedListNode<T>(value, this);
        }
    }
}