using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7321_POE
{
    /// PRIORITY QUEUE  <summary>

    // Code Attribution
    // Author: Stack overflow
    // Link: https://stackoverflow.com/questions/12507191/an-efficient-way-to-implement-a-custom-generic-list-queue-stack-combination

    public class CustomQueue<T>
    {
        private List<PriorityItem<T>> values; // list to hold queue elements 

        public CustomQueue()
        {
            values = new List<PriorityItem<T>>();
        }

        // Adds item to queue and sort in order of priority
        public void Enqueue(T value, int priority)
        {
            PriorityItem<T> newValue = new PriorityItem<T>(value, priority);
            values.Add(newValue);
            values.Sort((x, y) => y.priority.CompareTo(x.priority));
        }

        // Removes first item in queue and return it 
        public T Dequeue()
        {
            if (values.Count == 0)
            {
                throw new Exception("No Items in Queue");
            }

            T firstItem = values[0].value;
            values.RemoveAt(0); // remove first item in list >> first event 
            return firstItem; 
        }

        // Returns the item at the front of the queue without removing it
        public T Peek()
        {
            if (values.Count == 0)
            {
                throw new Exception("No Items in Queue");
            }

            return values[0].value;
        }

        // Returns the number of items in the queue
        public int Count()
        {
           return values.Count;
        }

        // Clears all items from the queue
        public void Clear()
        {
            values.Clear();
        }

        // adds queue elements to list and returns it 
        public List<T> toList()
        {
            if (values.Count == 0)
            {
                throw new Exception("No Items in Queue");
            }

            List<T> list = new List<T>();
            foreach (var item in values)
            {
               list.Add(item.value);
            }

            return list;
        }

       
    }
}
