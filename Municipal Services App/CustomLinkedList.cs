using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PROG7321_POE
{
    public class CustomLinkedList<T>
    {
        // Code Attribution
        //Link: https://www.c-sharpcorner.com/article/linked-list-implementation-in-c-sharp/
        //Author: C# Corner
        //Link: https://www.geeksforgeeks.org/deletion-in-linked-list/
        //Author: GeeksforGeeks
        //Link: https://stackoverflow.com/questions/3150381/generic-linked-list
        //Author: StackOverflow


        private Node<T> head; // stores first node 
        private Node<T> tail; // stores last node 

        private static int count; // num nodes in list 

        public CustomLinkedList()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public void insertLast(T data) // insert at the end of the list 
        {
            Node<T> newNode = new Node<T>(data);

            try {
                if (head == null) 
                    // if nothing in list yet add >> make new node the head and tail >> since only node in list 
                {
                    newNode.previous = null;
                    head = newNode;
                    tail = newNode;
                }
                else
                {
                    // add new node after tail >> tail next >>  and make new node the new tail
                    tail.next = newNode;
                    newNode.previous = tail;
                    tail = newNode;
                }
                count++; // inc count 
            }
            catch { throw new Exception("Could not add new node"); }

        }// insert after


        internal void InsertAfter(Node<T> current, T data) //insert new node afer specific node 
        {
            if (current == null)
            { throw new Exception("The given prevoius node cannot be null"); }
            else
            {
                Node<T> newNode = new Node<T>(data); // create new node

                // current node >> new node >> current node . next 
                newNode.next = current.next;
                current.next = newNode;
                newNode.previous = current;

                if (newNode.next != null)
                {
                    newNode.next.previous = newNode;
                }
            } 
        }

        internal void InsertFront(T data) // insert at front of the list 
        {
            Node<T> newNode = new Node<T>(data);
            // make new node the new head >> and make the previous node of the current head the new node 
            newNode.next = head;
            head.previous = newNode;
            newNode.previous = null;
            head = newNode; // make the new node the new head
        }

        public int Count()
        { return count; } // return num items in list 

        public Node<T> Search(T data)
        {
            if (count == 0) { throw new Exception("Empty List"); }

            Node<T> current = head;

            while (current != null)
            {
                if (current.data.Equals(data)) { return current; }
                current = current.next;
            }
            return null;
        }

        public void Remove(Node<T> node)
        {
            if (node == null) { throw new ArgumentNullException(); }
            if (Search(node.data) == null) { throw new Exception("Object could not be found"); }// search for node first 

            if (node == head)
            { // if node to remove is head >> make the new head >> head.next >>> remove previous from new head 
                head = head.next;
                if (head != null)
                { head.previous = null; }
            }
            else if (node == tail)
            { // if node to remove is tail >> make the new tail >> tail. previous>> remove next from new tail
                tail = tail.previous;
                if (tail != null)
                { tail.next = null; }
            }
            else
            {
                Node<T> previousNode = node.previous; // store previous of node to be removed 
                Node<T> nextNode = node.next; // store next of node to be removed 
                previousNode.next = nextNode; // previous node will now point to >> node.next
                nextNode.previous = previousNode; // next node will now point to >> node.previous
            }

            count--; // dec num of items in list
        }

        

        public void RemoveFirst()
        {
            if (count == 0) { throw new Exception("Empty List"); }
            Remove(head); // remove head
        }


        public void RemoveLast()
        {

            if (count == 0) { throw new Exception("Empty List"); }
            Remove(tail); // remove tail
        }


        public T GetIndex(int index)
        {
            // Check if the index is out of bounds
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException("Index is out of bounds.");
            }

            Node<T> current = head; // start list at head 
            int currentIndex = 0;

            while (current != null) // while there is another element in list 
            {
                if (currentIndex == index)
                {
                    return current.data; // return data stored in current node 
                }

                current = current.next; // make current the next node in list 
                currentIndex++; // inc index 
            }
            throw new Exception("Can not find index");
        }

        public List<T> GetList()
        {
            List<T> list = new List<T>(); // create list to hold all elements 
            Node<T> current = head;// start list at head 

            if (head == null) { throw new Exception("List is empty"); }
            // Traverse the linked list and add each element to the list
            while (current != null) // while there is another element in list 
            {
                list.Add(current.data); // add current node to list 
                current = current.next; // make current node the next node in the lit 
            }

            return list; // retrn list of all elements
        }

    }
}
