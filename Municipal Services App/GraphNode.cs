using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7321_POE
{
    //Code Attribution
    // Author: Stack Overflow
    // Link: https://stackoverflow.com/questions/7532882/is-there-any-graph-data-structure-implemented-for-c-sharp
    public class GraphNode<T>
    {
        public T data {  get; set; }
        public List<GraphNode<T>> dependencies { get; set; }
        public List<GraphNode<T>> dependants { get; set; }

        public GraphNode(T data)
        {
            this.data = data;
            dependencies = new List<GraphNode<T>>();
            dependants = new List<GraphNode<T>>();
        }

    }
}
