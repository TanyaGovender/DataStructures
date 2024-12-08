using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7321_POE
{
    //Code Attribution
    // Author: Stack Overflow
    // Link: https://stackoverflow.com/questions/2231796/heap-class-in-net
    public class CustomHeap<T>
    {
        private List<HeapNode<T>> heapNodes = new List<HeapNode<T>>(); // create list to keep track of ndes in heap

        public void Insert(HeapNode<T> node)
        {
            heapNodes.Add(node); // add node to list 
            heapNodes.Sort((x,y) => x.priority.CompareTo(y.priority)); // sort nodes in list in order of priority
        }

        public HeapNode<T> Pop()
        {
            if (heapNodes.Count == 0) { throw new Exception("Heap is empty"); } // throw exception if heap is empty

            var min = heapNodes[0]; // return and remove first elemebt in list >> higest priority node
            heapNodes.RemoveAt(0);
            return min;
        }

        public HeapNode<T> Peek()
        {
            if (heapNodes.Count == 0) { throw new Exception("Heap is empty"); }
            return heapNodes[0]; // return first element in list without removing it
        }

        public List<T> GetList()
        {
            // return data from nodes in a list
            List<T> list = new List<T>();
            foreach (var node in heapNodes) {
                list.Add(node.data);
            }

            return list;
        }
    }
}
