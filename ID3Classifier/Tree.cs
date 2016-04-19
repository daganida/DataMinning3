using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3Project
{
    class Tree
    {
        /// <summary>
        /// Root of tree
        /// </summary>
        public TreeNode root { get; set; }

        public Tree(DataTable trainingSet)
        {

        }

        public string ToXMLString()
        {
            return "<?xml version=\"1.0\" encoding=\"utf-8\" ?>"+root.XmlConverter();
        }
    }

    /// <summary>
    /// Represents a single node in an ID3 tree
    /// </summary>
    class TreeNode
    {
        /// <summary>
        /// Holds the instances relevant to the node
        /// </summary>
        public DataTable data { get; set; }

        /// <summary>
        /// child nodes of this node
        /// </summary>
        public List<TreeNode> children;

        /// <summary>
        /// Name of attribute to split the children by
        /// </summary>
        public string SplitByAttributeName;

        /// <summary>
        /// Value of current node attribute
        /// </summary>
        public string NodeAttributeValue;

        //Add Parameters As Needed Here
        public TreeNode(DataTable dataSet)
        {
            //Your Code Here
        }


        public string XmlConverter()
        {
            //your Code Here
            return "";
        }

    }
}
