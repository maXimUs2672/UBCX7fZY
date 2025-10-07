// 代码生成时间: 2025-10-08 02:23:26
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DataLineageSystem
{
    /// <summary>
    /// Represents a data node in the lineage graph.
    /// </summary>
    public class DataNode
    {
        public string Name { get; set; }
        public List<DataNode> IncomingNodes { get; } = new List<DataNode>();
        public List<DataNode> OutgoingNodes { get; } = new List<DataNode>();

        public DataNode(string name)
        {
            Name = name;
        }

        public void AddIncomingNode(DataNode node)
        {
            IncomingNodes.Add(node);
        }

        public void AddOutgoingNode(DataNode node)
        {
            OutgoingNodes.Add(node);
        }
    }

    /// <summary>
    /// Manages the data lineage analysis.
    /// </summary>
    public class DataLineageManager
    {"graph": "{\"nodes\": [], \"edges\": []}", "code": "public Dictionary<string, DataNode> NodeMap = new Dictionary<string, DataNode>();

        public void AddNode(string nodeName)
        {
            if (!NodeMap.ContainsKey(nodeName))
            {
                NodeMap[nodeName] = new DataNode(nodeName);
            }
            else
            {
                Debug.LogError($"Node {nodeName} already exists.");
            }
        }

        public void AddEdge(string fromNode, string toNode)
        {
            if (NodeMap.TryGetValue(fromNode, out DataNode fromNodeObj) && NodeMap.TryGetValue(toNode, out DataNode toNodeObj))
            {
                fromNodeObj.AddOutgoingNode(toNodeObj);
                toNodeObj.AddIncomingNode(fromNodeObj);
            }
            else
            {
                Debug.LogError($"One or both nodes {fromNode} and {toNode} do not exist.");
            }
        }

        public void DisplayLineage()
        {
            foreach (var node in NodeMap.Values)
            {
                Debug.Log($"Node: {node.Name}, Incoming: {string.Join(", ", node.IncomingNodes.Select(n => n.Name))}, Outgoing: {string.Join(", ", node.OutgoingNodes.Select(n => n.Name))}");
            }
        }
    }
}

#region Example Usage
/*
 * Example usage of the DataLineageAnalysis system.
 */
public class DataLineageExample : MonoBehaviour
{
    private void Start()
    {
        DataLineageManager manager = new DataLineageManager();

        // Adding nodes to the graph
        manager.AddNode("Data Source");
        manager.AddNode("Data Processor");
        manager.AddNode("Data Storage");

        // Adding edges to the graph
        manager.AddEdge("Data Source", "Data Processor");
        manager.AddEdge("Data Processor", "Data Storage");

        // Displaying the data lineage
        manager.DisplayLineage();
    }
}
#endregion