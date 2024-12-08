using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7321_POE
{
    // Code attribution
    // Author: Stack Overflow
    // link: https://stackoverflow.com/questions/42887274/return-hashsett-from-hashset-of-generic-type-in-generic-function

    public class CustomHashSet<T>
    {
        private const int InitialCapacity = 50;  // capacity of set
        private List<T>[] set;   // array to hold elements              
        private int count;  // num items in hash set                     

        public CustomHashSet()
        {
            set = new List<T>[InitialCapacity]; 
            count = 0; // set count to zero
        }

        // Add value to set
        public bool Add(T value)
        {
            if (Contains(value)) // Check if value already exists >> if value already in set >> return false
            {
                return false;                     
            }

            int setIndex = GetBucketIndex(value); // Get the index for the set

            // Initialize the set if its null
            if (set[setIndex] == null)
            {
                set[setIndex] = new List<T>();
            }

            set[setIndex].Add(value); // Add the value to the set
            count++;                                
            return true;                           
        }

        // Removes an item from the set
        public bool Remove(T value)
        {
            int setIndex = GetBucketIndex(value); // Get the index for the set

            if (set[setIndex] != null)  // if set not null
            {
                var hset = set[setIndex];

                if (hset.Remove(value))   // Remove the item from the set
                {
                    count--;                        
                    return true;                   
                }
            }

            return false;  // val not found in set
        }

        // Checks if a value is in the set
        public bool Contains(T value)
        {
            int setIndex = GetBucketIndex(value); // Get the index for the set

            if (set[setIndex] != null)  // Check if the set is not null
            {
                return set[setIndex].Contains(value); // Use List.Contains() to check for the value
            }

            return false;                          
        }

        
        public void Clear()
        {
            set = new List<T>[InitialCapacity]; // Reinitialize set
            count = 0;// Reset count to zero
        }

        
        public int Count()
        {
           return count;               
        }

        // returns the hash code of value based on index in set
        private int GetBucketIndex(T value)
        {
            int hash = value == null ? 0 : value.GetHashCode(); // Get the hash code of the val
            return Math.Abs(hash % set.Length);  /// calculate the hash for the set
        }

        public List<T> toList()
        {
            List<T> resultList = new List<T>(); // create list 

            foreach (var bucket in set)
            {
                if (bucket != null)
                {
                    foreach (var item in bucket)
                    {
                        resultList.Add(item); 
                    }
                }
            }

            return resultList; // return list with all values
        }

    }
}
