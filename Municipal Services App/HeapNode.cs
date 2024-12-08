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
    public class HeapNode<T>
    {
        public T data {  get; set; }
        public int priority { get; set; }

        public HeapNode(T data, int priority)
        {
            this.data = data;
            this.priority = priority;
        }
    }
}
