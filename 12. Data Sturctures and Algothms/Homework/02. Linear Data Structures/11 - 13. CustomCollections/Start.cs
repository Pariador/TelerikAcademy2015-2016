namespace CustomCollections
{
    using System;
    //using System.Linq;
    using System.Collections.Generic;

    internal static class Start
    {
        internal static void Main()
        {
            ConnectedList<int> list = new ConnectedList<int>();
            Stack<int> stack = new Stack<int>();
            LinkedQueue<int> queue = new LinkedQueue<int>();

            for (int i = 0; i < 15; i++)
            {
                list.AddLast(i);
                stack.Push(i);
                queue.Enqueue(i);
            }

            list.Remove(7);

            string listStr = string.Join(", ", list);
            Console.WriteLine("LinkedList: ");
            Console.WriteLine(listStr);

            Console.WriteLine("\nStack");
            while (stack.Count != 0)
            {
                Console.WriteLine(stack.Pop());
            }

            Console.WriteLine("\nLinkedQueue");
            while (queue.Count() != 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}