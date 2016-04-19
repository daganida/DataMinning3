using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ID3Project
{
    class ID3Classifier
    {
        private Tree _tree;
        private string _path;
        string[] _attributeNames;
        string[] _targetValues;
        DataTable _trainDataTable;
        DataTable _testDataTable;

        /// <summary>
        /// Create a new ID3Classifier.
        /// Creates the tree according to the train set, using the Gini Index as the splitting function.
        /// </summary>
        /// <param name="dataPath">Path to location of data files.</param>
        public ID3Classifier(string dataPath)
        {
            this._path = dataPath;
            
            

        }



        /// <summary>
        /// Classifies the test set according to the ID3 tree.
        /// </summary>
        public void Classify()
        {
            //Your Code Here
        }



        /// <summary>
        /// Prints the ID3 tree structure in an XML format to a file.
        /// </summary>
        public void CreateXMLTree()
        {
            File.WriteAllText(_path+@"\tree.xml", _tree.ToXMLString());
        }
        public void setAttributesFromStructureFile()
        {
            string[] attName;
            string[] attributesNames = File.ReadAllLines(_path + "\\Structure.txt");
            string[] attributeNamesAfter = new string[attributesNames.Length - 1];
            for (int i = 0; i < attributesNames.Length - 1; i++)
            {
                attName = attributesNames[i].Split(' ');
                for (int k = 1; k < attName.Length - 1; k++)
                {
                    attributeNamesAfter[i] += attName[k];
                }
            }
            _attributeNames = attributeNamesAfter;
            _targetValues = attributesNames[attributesNames.Length - 1].Replace("@ATTRIBUTE", "").Replace("{", "").Replace("}", "").Replace("class", "").Trim().Split(',');
        }



        internal void insertDataIntoTable(string fileName)
        {
            try
            {
                DataTable dTable = new DataTable();
                //create all columns of attributes
                foreach (string column in _attributeNames)
                {
                    dTable.Columns.Add(column, typeof(double));
                }
                //create column for target
                dTable.Columns.Add("class", typeof(string));
                string[] data = File.ReadAllLines(_path + "\\" + fileName);
                foreach (string row in data)
                {
                    dTable.Rows.Add(row.Split(','));

                }//in case we load train file
                if (fileName.Equals("train.txt"))
                    _trainDataTable = dTable;
                    //in case we load test file
                else if (fileName.Equals("test.txt"))
                {
                    _testDataTable = dTable;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
