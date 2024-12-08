using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7321_POE
{

    // Code Attribution
    // Author: Stack overflow
    // Link: https://stackoverflow.com/questions/12507191/an-efficient-way-to-implement-a-custom-generic-list-queue-stack-combination

    public class PriorityItem<T> // created to use in priority queue
    {
        public T value { get; set; } // stores new event data
        public int priority { get; set; }// store priority of event >> eg 1,2,3,4 or 5

        public PriorityItem(T value, int priority) 
        { 
            this.value = value;
            this.priority = priority;
        }
    }
}
