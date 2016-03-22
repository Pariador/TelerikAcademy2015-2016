namespace CustomCollections
{
    public class ConnectedListNode<T>
    {
        public ConnectedListNode(T value, ConnectedList<T> list)
        {
            this.List = list;

            this.Value = value;
        }

        public ConnectedListNode<T> Next { get; set; }

        public ConnectedListNode<T> Previous { get; set; }

        public ConnectedList<T> List { get; private set; }

        public T Value { get; set; }
    }
}