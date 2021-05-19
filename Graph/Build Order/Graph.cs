using System;
using System.Collections.Generic;
using System.Linq;

namespace Build_Order
{
    public class Graph
    {
        public LinkedList<Node> Nodes;
        public LinkedList<Node> UnDependentProjects;

        public Graph()
        {
            Nodes = new LinkedList<Node>();
            UnDependentProjects = new LinkedList<Node>();
        }

        public void BuildGraphFromProjects(List<string> projects)
        {
            for (int i = 0; i < projects.Count; i++)
            {
                Nodes.AddFirst(new Node(projects[i]));
            }
        }

        private Node GetNodeByValue(string value)
        {
            foreach (Node node in Nodes)
            {
                if (node.Value == value)
                    return node;
            }
            return new Node(value);
        }

        public void BuildEdgesFromDependencies(List<Dependency> dependencies)
        {
            foreach (Node node in Nodes)
            {
                List<Dependency> dependentProjects = dependencies.FindAll(d => d.MainProject == node.Value);
                foreach (Dependency dependency in dependentProjects)
                {
                    node.Childern.AddFirst(GetNodeByValue(dependency.DependentProject));
                }
                bool isProjectDependent = dependencies.Any(d => d.DependentProject == node.Value);
                if (!isProjectDependent)
                {
                    UnDependentProjects.AddFirst(node);
                }
            }
        }

        public void PrintBFS()
        {
            Console.Write("Build order : ");
            LinkedList<Node> queueToDisplay = new LinkedList<Node>();

            foreach (Node node in UnDependentProjects)
            {
                node.IsVisited = true;
                queueToDisplay.AddFirst(node);
            }

            while (queueToDisplay.Count != 0)
            {
                Node r = queueToDisplay.First.Value;
                queueToDisplay.RemoveFirst();
                Console.Write(r.Value + " ");
                foreach (Node n in r.Childern)
                {
                    if (n.IsVisited == false)
                    {
                        n.IsVisited = true;
                        queueToDisplay.AddLast(n);
                    }
                }
            }
        }
    }
}
