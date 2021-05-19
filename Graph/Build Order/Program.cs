using System.Collections.Generic;

namespace Build_Order
{

    class Program
    {
        static void Main()
        {
            List<string> projects = new List<string>()
            {
                "a","b","c","d","e","f"
            };
            List<Dependency> dependencies = new List<Dependency>()
            {
                new Dependency(){MainProject = "a",DependentProject="d"},
                new Dependency(){MainProject = "f",DependentProject="b"},
                new Dependency(){MainProject = "b",DependentProject="d"},
                new Dependency(){MainProject = "f",DependentProject="a"},
                new Dependency(){MainProject = "d",DependentProject="c"}
            };

            Graph graph = new Graph();
            graph.BuildGraphFromProjects(projects);
            graph.BuildEdgesFromDependencies(dependencies);
            graph.PrintBFS();

        }
    }
}
