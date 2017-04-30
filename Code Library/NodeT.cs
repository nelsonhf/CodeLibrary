using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLibrary
{
    public class Node<T, I> where T : IIdentifiable<I>
    {
        /// <summary>Object in this node</summary>
        public T ThisNode { get; private set; }

        /// <summary>This node's id</summary>
        public I Id
        {
            get { return ThisNode.Id;}
        }

        /// <summary>Retrieve a sub-node from this node</summary>
        /// <param name="id">Id of sub-node to retrieve</param>
        /// <returns>
        /// Requested sub-node; null, if there is no sub-node with the requested id
        /// </returns>
        public Node<T, I> this[I id]
        {
            get { return m_nodes.ContainsKey(id) ? m_nodes[id] : null; }
        }

        /// <summary>Number of sub-nodes under this node </summary>
        public int NodesCount { get { return(m_nodes.Count); } }

        /// <summary>Construct a node</summary>
        /// <param name="id">Node id</param>
        /// <param name="other">One or more sub-nodes to add to this node</param>
        public Node(T root, params Node<T, I>[] other)
        {
            if (root == null)
            {
                throw new ArgumentNullException("root", "Argument is null");
            }

            ThisNode = root;
            m_nodes = new Dictionary<I, Node<T, I>>();
            Add(other);
        }

        /// <summary>Add sub-nodes to this node</summary>
        /// <param name="subnodes">One or more sub-nodes to add to this node</param>
        public void Add(params Node<T, I>[] subnodes)
        {
            foreach (var node in subnodes)
            {
                if (node == null)
                {
                    throw new ArgumentNullException("other", "Sub-nodes cannot be null");
                }

                m_nodes[node.Id] = node;
            }
        }

        /// <summary>Remove one or more subnodes, given their names</summary>
        /// <param name="subnodes">Id of the sub-node(s) to remove</param>
        /// <returns>
        /// true if all nodes specified could be removed;
        /// false if at least one of them could not be removed.
        /// </returns>
        /// <remarks>
        /// All nodes in the list that can be removed will be, even if a id preceeding theirs
        /// cannot be.
        /// </remarks>
        public bool Remove(params I[] subnodes)
        {
            bool result = true;

            foreach (var node in subnodes)
            {
                if (!m_nodes.Remove(node))
                {
                    result = false;
                }
            }

            return result;
        }

        /// <summary>Remove all sub-nodes from this node </summary>
        public void Clear()
        {
            m_nodes.Clear();
        }

        /// <summary>Prints all information about a node and descendants</summary>
        /// <param name="level">
        /// Initial indentation level to use. Should be set to zero by external callers
        /// </param>
        /// <returns>
        /// A string containing all sub-nodes (and their sub-nodes, recursively)
        /// under the current node
        /// </returns>
        /// <remarks>NOT safe for cyclic graphs! Will go into an endless loop</remarks>
        public string Dump(int level)
        {
            string indent = new string(' ', Indentation * level++);
            string result = indent + Id + " =>";

            // Call the descendants (in the internal dictionary order) to Dump themselves
            foreach (var node in m_nodes)
            {
                result += "\n" + node.Value.Dump(level);
            }

            return result;
        }

        /// <summary>Prints all information about a node and descendants, ordered by id</summary>
        /// <param name="level">
        /// Initial indentation level to use. Should be set to zero by external callers
        /// </param>
        /// <returns>
        /// A string containing all sub-nodes (and their sub-nodes, recursively)
        /// under the current node
        /// </returns>
        /// <remarks>NOT safe for cyclic graphs! Will go into an endless loop</remarks>
        public string DumpById(int level)
        {
            string indent = new string(' ', Indentation * level++);
            string result = indent + Id + " =>";

            // Call the descendants (ordered by id, a=>a) to Dump themselves
            foreach (var id in m_nodes.Keys.OrderBy(a => a))
            {
                var node = m_nodes[id];
                result += "\n" + node.DumpById(level);
            }

            return result;
        }

        /// <summary>Nodes to which this one is connected</summary>
        private Dictionary<I, Node<T, I>> m_nodes;

        /// <summary>Number of spaces used to indent each level in the Dump methods</summary>
        private const int Indentation = 4;
    }
}
