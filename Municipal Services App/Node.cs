using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7321_POE
{
    public class Node<T>
    {
        public T data {  get; set; }
        public Node<T> next { get; set; }
        public Node<T> previous { get; set; }

     
        public Node(T data)
        {
            this.data = data;
            next = null;
            previous = null;
        }
    }
}
