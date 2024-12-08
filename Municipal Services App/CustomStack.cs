using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7321_POE
{
    // Code Attribution
    // Author: Stack Overflow
    // Link: https://stackoverflow.com/questions/29843085/creating-a-generic-stack-in-generic-stack-class

    public class CustomStack<T>
    {
        static int lastElement; // track last element in stack
        static int capacity = 100; // max number of elements in stack
        T[] stack = new T[capacity];

        public CustomStack()
        {
            lastElement = -1;
        }

        public bool isEmpty()
        {
            return lastElement < 0; // if -1 then no elements in stack 
        }

        public void Push(T data)
        {
            // add data to stack >>> add on top of stack 
            if (lastElement >= capacity - 1) 
            {
                throw new Exception("Stack is full");
            }
            else
            {
                lastElement++;
                stack[lastElement] = data;
            }
        }

        public T Pop()
        {
            // remove top element from stack >>> last element added >> last in first out
            if (lastElement < 0)
            {
                throw new Exception("No elements in stack");
            }
            else
            {
                T val = stack[lastElement];
                stack[lastElement] = default;
                lastElement--;
                return val;
            }
        }

        public T Peek()
        {
            // get last element in stack >> without removing it 
            if (lastElement < 0)
            {
                throw new Exception("No elements in stack");
            }
            else
            {
                return stack[lastElement];
            }
        }

        public int Count()
        {
            return lastElement + 1; // Return the count of elements
        }

        public List<T> toList()
        {
            // convert stack to list of type t
            List<T> list = new List<T>();
            for (int i = 0; i <= lastElement; i++) 
            {
                list.Add(stack[i]);
            }

            return list;
        }


        // method to analyse elemebts in stack 
        public T Analyze()
        {
            if (isEmpty()) return default;

            // Use a dictionary to keep track of how many times each item is searhed for 
            Dictionary<T, int> frequency = new Dictionary<T, int>();

            // Only analyze the top 5 elements in the stack (top 5 searches >> 5 most recent searches)
            int elementsToConsider = Math.Min(5, lastElement + 1); 

            for (int i = lastElement; i > lastElement - elementsToConsider; i--)
            {
                T item = stack[i];
                if (frequency.ContainsKey(item))
                {
                    frequency[item]++;
                }
                else
                {
                    frequency[item] = 1;
                }
            }

            // Identify the most frequently searched event
            T mostSearchedEvent = default;
            int maxCount = 0;

            foreach (var kvp in frequency)
            {
                if (kvp.Value > maxCount)
                {
                    maxCount = kvp.Value;
                    mostSearchedEvent = kvp.Key;
                }
            }

            return mostSearchedEvent;
        }


    }
}
