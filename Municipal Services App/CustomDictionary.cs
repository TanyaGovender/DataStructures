using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PROG7321_POE
{
    // CUSTOM SORTED DICTIONARY 

    // Code Attribution
    // Author: Stack Overflow
    // Link: https://stackoverflow.com/questions/654752/can-i-create-a-dictionary-of-generic-types
    public class CustomDictionary<TKey, TValue>
    {
        private List<TKey> keys; //list of keys 
        private List<CustomQueue<TValue>> values; // list of values >>> use priority queue >> keep events in order of importance
        ///  list of priority queues >> of type T >> replaced with event 
        
        public CustomDictionary()
        {
            keys = new List<TKey>();
            values = new List<CustomQueue<TValue>>();
        }

        // Add new value to dictionary
        public void Add(TKey key, TValue value, int priority)
        {
            if (key == null) { throw new ArgumentNullException("key can not be null"); }
            if (value == null) { throw new ArgumentNullException("value can not be null"); }
            if (priority == null) { throw new ArgumentNullException("priority can not be null"); }

            int keyIndex = keys.IndexOf(key); /// get index of current key in keys list 

            if (keyIndex == -1) // if key doesnt exist >>> add key to keys list 
            {
                keys.Add(key);
                var newQueue = new CustomQueue<TValue>();
                newQueue.Enqueue(value, priority);
                values.Add(newQueue);
                // create new queue  of values >>> add value to queue
               
                Sort(); // sort keys and values in dictionary
            }
            else
            {
                values[keyIndex].Enqueue(value, priority);     //else if key alreay exists >> add value to queue at this index

            }
        }

        public CustomQueue<TValue> getQueue(TKey key)
        {
            if (key == null) { throw new ArgumentNullException("key can not be null"); }
            int keyIndex = keys.IndexOf(key); /// get index of current key in keys list 

            if (keyIndex != -1)
            {
                return values[keyIndex];
            }
            else
            {
                throw new Exception("Key not found");
            }
        }

        // Removes value from dictionary 
        public TValue RemoveValue(TKey key)
        {
            if (key == null) { throw new ArgumentNullException("key can not be null"); }

            int keyIndex = keys.IndexOf(key); // index of current key in keys list 
            
            if (keyIndex == -1) // if key not found 
            {
                throw new Exception("Key not found");
            }

            var removed = values[keyIndex].Dequeue();
            return removed;
        }

        // Removes key and values from dictionary 
        public bool Remove(TKey key)
        {
            if (key == null) { throw new ArgumentNullException("key can not be null"); }

            int keyIndex = keys.IndexOf(key);
           
            if (keyIndex == -1)
            {
                throw new Exception("Key not found");
            }

            keys.RemoveAt(keyIndex);
            values.RemoveAt(keyIndex);
            return true;
        }

        public void Clear()
        {
            keys.Clear();
            values.Clear();
        }

        public int Size()
        {
            return keys.Count();
        }

      
        // Checks if the dictionary contains a specific key
        public bool ContainsKey(TKey key)
        {
            return keys.Contains(key);
        }


        // Indexer to access dictionary values by key
        public CustomQueue<TValue> this[TKey key]
        {
            get
            {
                int keyIndex = keys.IndexOf(key);
                if (keyIndex == -1)
                {
                    throw new KeyNotFoundException("The key does not exist.");
                }
                return values[keyIndex];
            }
            set
            {
                int keyIndex = keys.IndexOf(key);
                if (keyIndex == -1)
                {
                    keys.Add(key);
                    values.Add(value);
                }
                else
                {
                    values[keyIndex] = value;
                }
            }
        }

        // Gets all keys in the dictionary
        public List<TKey> Keys()
        {
             return keys; 
        }

        // Gets all values in the dictionary
        public List<CustomQueue<TValue>> Values()
        {
           return values; 
        }

       
        // method to sort dictionary 
        public void Sort()
        {
            var keyValuePairs = keys
                .Select((k, index) => new KeyValuePair<TKey, CustomQueue<TValue>>(k, values[index]))
                .OrderBy(pair => pair.Key) 
                .ToList();

            keys = keyValuePairs.Select(pair => pair.Key).ToList();
            values = keyValuePairs.Select(pair => pair.Value).ToList();
        }


        // method to return key valu pairs 
        public IEnumerable<KeyValuePair<TKey, CustomQueue<TValue>>> GetKeyValuePairs()
        {
            for (int i = 0; i < keys.Count; i++)
            {
                yield return new KeyValuePair<TKey, CustomQueue<TValue>>(keys[i], values[i]);
            }
        }

    }

    
}