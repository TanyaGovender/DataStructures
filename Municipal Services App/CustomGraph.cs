using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PROG7321_POE
{
    //Code Attribution
    // Author: Stack Overflow
    // Link: https://stackoverflow.com/questions/7532882/is-there-any-graph-data-structure-implemented-for-c-sharp

    public class CustomGraph<T>
    {
        private Dictionary<T, GraphNode<T>> graphNodes = new Dictionary<T, GraphNode<T>>();
        // creat dictionar y to keep track of nodes and dependancies

        public void AddNode(T data)
        {
            if (data == null) { throw new ArgumentNullException("data"); } // if no data avaialble >> throw exception
            if (!graphNodes.ContainsKey(data)) { graphNodes[data] = new GraphNode<T>(data); }// if dictionary doesnt already contain node key
        }

        public void AddDependancy(T data, T dependancy)
        {
            if (graphNodes.ContainsKey(data) && graphNodes.ContainsKey(dependancy))// if the dictionary contains this key
            {
                graphNodes[data].dependencies.Add(graphNodes[dependancy]);// add dependancy to list of dependancies for this key
                graphNodes[dependancy].dependants.Add(graphNodes[data]);
            }
        }

        public List<T> GetDependants(T data)
        {
            if (graphNodes.ContainsKey(data))// if node exists in dictionary
            { return graphNodes[data].dependants.Select(dependent => dependent.data).ToList(); }// return all depandants  fro this node/key
            else { return null; }
        }

        public bool Execute(T data)
        {
            // determine if a tadk can be exectued >> i.e no depenancies
            if (graphNodes.ContainsKey(data))
            { return graphNodes[data].dependencies.All(d => d.dependants.Count == 0); }
           else { return false; }
        }

        public List<T> getList()
        {
            return graphNodes.Keys.ToList();
        }
    }
}
