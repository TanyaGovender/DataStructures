using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7321_POE
{
    // Code Attribution
    // Author: GeeksForGeeks
    // Link:https://www.geeksforgeeks.org/introduction-to-avl-tree/

    public class CustomAVLTree<T> where T : IComparable<T> // compare values >> right node greater than root, left node less than root
    {
        private TreeNode<T> root; // create root node

        public void Insert(T data)
        {
            root = Insert(root, data);
        }

        private TreeNode<T> Insert(TreeNode<T> node, T data)
        {
            if (node == null) { return new TreeNode<T>(data); }

            // compare value of new node to existing node
            int comp = data.CompareTo(node.data);

            if (comp < 0) // if less than >> insert to left of node
            { node.left = Insert(node.left, data); }

            else if (comp > 0) // if greater than >> insert to right of node
            { node.right = Insert(node.right, data); }

            else // no duplicate nodes >> ie. no equal values
            { return node; }

            UpdateHeight(node); // update height of nodes
            return Balance(node); // balance tree >> with new mnode
        }

        private void UpdateHeight(TreeNode<T> node)
        {
            // get the max height of the left and right node and add 1
            node.height = 1 + Math.Max(getHeight(node.left), getHeight(node.right));
        }

        private int getHeight(TreeNode<T> node)
        {
            return node?.height ?? 0;
        }

        private int GetBalanceFactor(TreeNode<T> node)
        {
            return getHeight(node.left) - getHeight(node.right);
        }

        private TreeNode<T> Balance(TreeNode<T> node)
        {
            int balanceFactor = GetBalanceFactor(node);

            if (balanceFactor > 1)
            {
                if (GetBalanceFactor(node.left) < 0) { node.left = RotateLeft(node.left); }
                return RotateRight(node); // rotate tree to the right if it is squed to the left>> ie. balance factor less than 1
            }

            if (balanceFactor < -1)
            {
                if (GetBalanceFactor(node.right) > 0) { node.right = RotateRight(node.right); }
                return RotateLeft(node); // rotate tree to the left if it is squed to the right>> ie. balance factor greater than 1
            }

            return node; // if balance factor = 1 then tree is balanced
        }

        private TreeNode<T> RotateLeft(TreeNode<T> node)
        {
            // rotate tree nodes to the left to balance tree
            TreeNode<T> newRoot = node.right;
            node.right = newRoot.left;
            newRoot.left = node;

            UpdateHeight(node);
            UpdateHeight(newRoot);

            return newRoot;
        }

        private TreeNode<T> RotateRight(TreeNode<T> node)
        {
            // rotate tree nodes to the right to balance tree
            TreeNode<T> newRoot = node.left;
            node.left = newRoot.right;
            newRoot.right = node;

            UpdateHeight(node);
            UpdateHeight(newRoot);

            return newRoot;
        }

        public void Delete(T data)
        {
            root = Delete(root, data);
        }

        private TreeNode<T> Delete(TreeNode<T> node, T data)
        {
            if (node == null) { return null; } // if no node found

            // compare root node to node to be removed
            int comp = data.CompareTo(node.data);

            if (comp < 0) { node.left = Delete(node.left, data); } // if  greater than 0 >> remove left node
            else if (comp > 0) { node.right = Delete(node.right, data); } // if less than 0 << remove right node

            else
            {
                if (node.left == null || node.right == null) { node = (node.left ?? node.right); }
                else
                {
                    TreeNode<T> succ = FindMin(node.right);
                    node.data = succ.data;
                    node.right = Delete(node.right, succ.data);
                }
            }

            if (node == null) { return null; }

            UpdateHeight(node);
            return Balance(node);
        }

        private TreeNode<T> FindMin(TreeNode<T> node)
        {
            while (node.left != null) { node = node.left; }
            return node; // find smallest node
        }

        public TreeNode<T> Search(T data)
        {
            TreeNode<T> result = Search(root, data);
            if (result == null) { throw new Exception("Node not found"); }// throe exception if no node found
            else { return Search(root, data); }
        }

        public TreeNode<T> Search(TreeNode<T> node, T data)
        {
            if (node == null) { throw new ArgumentNullException("node can not be null"); }

            // compare search node to current node
            int comp = data.CompareTo(node.data);

            if (comp < 0) { return Search(node.left, data); } // if less than 0 >> search left side of tree
            else if (comp > 0) { return Search(node.right, data); } // if greater than 0 >> search right side of tree
            else { return node; }

        }

        public void InOrderTraversal(Action<T> action)
        {
            InOrderTraversal(root, action);
        }

        private void InOrderTraversal(TreeNode<T> node, Action<T> action)
        {
            if (node == null) { return; }

            InOrderTraversal(node.left, action);
            action(node.data);
            InOrderTraversal(node.right, action);
        }

        public List<T> getList()
        {
            // rerurn list of all nodes in tree using in order traversal
            List<T> list = new List<T>();
            InOrderTraversal(root, data => list.Add(data));
            return list;
        }

    }// class

}// ns