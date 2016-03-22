namespace GenericClass.ObjectLibrary
{
    using System;
    using System.Text;

    public class GenericList<T> where T : IComparable
    {
        private static readonly IndexOutOfRangeException indexOutOfRange = new IndexOutOfRangeException("The index was out of bounds of the list.");

        //The array given as a parametar is the starting array the the list uses
        public GenericList(params T[] arr)
        {
            this.Arr = arr;
            this.Count = this.Arr.Length;
        }

        public int Capacity 
        {
            get
            {
                return this.Arr.Length;
            }
        }
        private T[] Arr { get; set; }
        //Count is the total of used elements in the array
        //When an element is added in any way the array[Count] is used and Count++
        //If Count becomes equal to the Capacity of the array as a result of adding elements the
        //Capacity of the array is doubled with Expand().
        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                if (index >= this.Count || index < 0)
                {
                    throw GenericList<T>.indexOutOfRange;
                }

                return this.Arr[index];
            }
            set
            {
                if (index >= this.Count || index < 0)
                {
                    throw GenericList<T>.indexOutOfRange;
                }

                this.Arr[index] = value;
            }
        }

        //Adds an element at the end of the array
        public void Add(T item)
        {
            if (this.Count == this.Arr.Length)
            {
                this.Expand();
            }

            this.Arr[Count] = item;
            this.Count++;
        }
        //Removes an element at the spcific index.
        public void RemoveAt(int index)
        {
            for (int i = index + 1; i < this.Count; i++)
            {
                this.Arr[i - 1] = this.Arr[i];
            }

            this.Count--;
        }
        //Adds an element at the specific index moving all other elements to thereIndex + 1
        public void Insert(int index, T item)
        {
            if (this.Count == this.Arr.Length)
            {
                this.Expand();
            }

            for (int i = this.Count; i > index; i--)
            {
                this.Arr[i] = this.Arr[i - 1];
            }
            this.Count++;

            this[index] = item;
        }
        //Index of uses Array.IndexOf()
        public int IndexOf(T item)
        {
            return Array.IndexOf<T>(this.Arr, item);
        }
        public int IndexOf(T item, int startIndex)
        {
            return Array.IndexOf<T>(this.Arr, item, startIndex);
        }
        public int IndexOf(T item, int startIndex, int count)
        {
            return Array.IndexOf<T>(this.Arr, item, startIndex, count);
        }
        //Clear replaces the array with a new array with the same Capacity
        public void Clear()
        {
            this.Arr = new T[this.Arr.Length];
            this.Count = 0;
        }
        //Min() and Max() find the smallest or biggest element in the array using CompareTo
        public T Max()
        {
            if (this.Count != 0)
            {
                T maxValue = this[0];

                for (int i = 1; i < this.Count; i++)
                {
                    if (this[i].CompareTo(maxValue) == 1)
                    {
                        maxValue = this[i];
                    }
                }

                return maxValue;
            }
            else
            {
                return default(T);
            }
        }
        public T Min()
        {
            if (this.Count != 0)
            {
                T minValue = this[0];

                for (int i = 1; i < this.Count; i++)
                {
                    if (this[i].CompareTo(minValue) == -1)
                    {
                        minValue = this[i];
                    }
                }

                return minValue;
            }
            else
            {
                return default(T);
            }
        }
        public override string ToString()
        {
            var result = new StringBuilder();

            for (int i = 0; i < this.Count; i++)
            {
                result.Append(this[i]);

                if (i != this.Count - 1)
                {
                    result.Append(", ");
                }
            }

            return result.ToString();
        }
        //Makes a new array with the double the size of Arr,
        //all elements from Arr are copied to the new array and it replaces Arr.
        private void Expand()
        {
            T[] newArr = new T[this.Arr.Length > 4 ? this.Arr.Length * 2 : 8];
            this.Arr.CopyTo(newArr, 0);
            this.Arr = newArr;
        }
    }
}