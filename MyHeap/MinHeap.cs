using System;
namespace MyHeap
{
    public class MinHeap
    {
        private int capacity;
        private int size;
        private int[] items;

        public MinHeap(int capacity, int size)
        {
            this.capacity = capacity;
            this.size = size;
            this.items = new int[capacity];
        }

        #region Get Heap Node Value
        private int GetParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        private int GetLeftChildIndex(int parentIndex)
        {
            return parentIndex * 2 + 1;
        }

        private int GetRightChildIndex(int parentIndex)
        {
            return parentIndex * 2 + 2;
        }
        #endregion

        #region Validate Node Methods
        private bool HasLeftChild(int index)
        {
            return GetLeftChildIndex(index) < this.size;
        }

        private bool HasRightChild(int index)
        {
            return GetRightChildIndex(index) < this.size;
        }

        private bool HasParent(int index)
        {
            return GetParentIndex(index) >= 0;
        }
        #endregion

        #region
        private int LeftChild(int index)
        {
            return items[GetLeftChildIndex(index)];
        }

        private int RightChild(int index)
        {
            return items[GetRightChildIndex(index)];
        }

        private int Parent(int index)
        {
            return items[GetParentIndex(index)];
        }
        #endregion

        private void Swap(int[] items, int indexOne, int indexTwo)
        {
            int temp = items[indexOne];
            items[indexOne] = items[indexTwo];
            items[indexTwo] = temp;
        }

        private void EnsureExtraCapacity()
        {
            if (this.size == this.capacity)
            {
                Array.Copy(items, items, this.capacity * 2);
                capacity *= 2;
            }
        }

        // Get the min heap's value.
        public int Peek()
        {
            if (this.size == 0)
            {
                throw new Exception();
            }

            return items[0];
        }

        public int Poll()
        {
            if (this.size == 0)
            {
                throw new Exception();
            }

            int item = items[0];
            items[0] = items[size - 1];
            size--;
            HeapifyDown();
            return item;
        }

        public void Add(int item)
        {
            EnsureExtraCapacity();
            items[size] = item;
            this.size++;
            HeapifyUp();
        }

        private void HeapifyUp()
        {
            int index = this.size - 1;

            while (HasParent(index) && Parent(index) > items[index])
            {
                int parentIndex = GetParentIndex(index);

                Swap(items, parentIndex, index);
                index = parentIndex;
            }
        }

        private void HeapifyDown()
        {
            throw new NotImplementedException();
        }
    }
}
