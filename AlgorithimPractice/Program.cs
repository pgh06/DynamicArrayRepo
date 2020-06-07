using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithimPractice
{
    class DynamicArray
    {
        public int[] Numbers { get; set; }
        public int InitialCapacity { get; set; }
        public int Size { get; set; }

        public DynamicArray(int initialCapacity)
        {
            InitialCapacity = initialCapacity;
            Numbers = new int[initialCapacity];
        }

        public int Get(int index)
        {
            return Numbers[index];
        }

        public void Set(int index, int value)
        {
            bool isOutOfRange = index >= InitialCapacity || index < 0;

            if (!isOutOfRange)
            {
                Numbers[index] = value;
            }

            UpdateSize();
        }

        public void Insert(int index, int value)
        {
            // check size
            if (Size == InitialCapacity)
            {
                Resize();
            }

            for (int i = Size; i > index; i--)
            {
                Numbers[i] = Numbers[i - 1];
            }

            Numbers[index] = value;
            Size++;
        }

        public void Delete(int index)
        {
            bool isOutOfRange = index > InitialCapacity || index < 0;

            if (!isOutOfRange)
            {
                for (int i = index; i < Size; i++)
                {
                    Numbers[i] = Numbers[i + 1];
                }
            }

            Size--;
        }

        public void Resize()
        {
            var tempArray = Numbers;
            Numbers = new int[InitialCapacity * 2];

            for (int i = 0; i < InitialCapacity; i++)
            {
                Numbers[i] = tempArray[i];
            }

            UpdateSize();
            InitialCapacity = InitialCapacity * 2;
        }

        public void Add(int value)
        {
            // check size
            if (Size == InitialCapacity)
            {
                Resize();
            }

            Numbers[Size] = value;
            UpdateSize();
        }

        public bool Contains(int value)
        {
            bool hasValue = false;

            for (int i = 0; i < Size; i++)
            {
                hasValue = Numbers[i].Equals(value);

                if (hasValue)
                    return hasValue;
            }

            return false;
        }

        public int GetSize()
        {
            return Size;
        }

        private void UpdateSize()
        {
            Size = 0;

            for (int i = 0; i < InitialCapacity; i++)
            {
                if (Numbers[i] > 0)
                    Size++;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var dynamicArray = new DynamicArray(10);
            dynamicArray.Set(0, 10);
            dynamicArray.Set(1, 20);
            dynamicArray.Set(2, 30);
            dynamicArray.Set(3, 40);
            dynamicArray.Set(4, 50);
            dynamicArray.Set(5, 60);
            dynamicArray.Set(6, 70);
            dynamicArray.Set(7, 80);
            dynamicArray.Set(8, 90);
            dynamicArray.Set(9, 100);
            dynamicArray.Set(10, 110);
            dynamicArray.Set(11, 120);

            dynamicArray.Insert(2, 3456);
            dynamicArray.Insert(7, 123456789);

            dynamicArray.Delete(4);
            dynamicArray.Delete(6);

            dynamicArray.Add(453436);

            var contains = dynamicArray.Contains(453436);
            var arraySize = dynamicArray.GetSize();

            foreach (var item in dynamicArray.Numbers)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
