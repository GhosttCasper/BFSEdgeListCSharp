using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFSEdgeListCSharp
{
    public class Edge
    {
        public Vertex FirstVertex; // выходит (начало)
        public Vertex SecondVertex; // входит (конец)

        public Edge(Vertex firstVertex, Vertex secondVertex)
        {
            FirstVertex = firstVertex;
            SecondVertex = secondVertex;
        }

        public bool HasVertex(Vertex curVertex)
        {
            if (FirstVertex.Index == curVertex.Index || SecondVertex.Index == curVertex.Index)
                return true;
            return false;
        }

        public Vertex GetIncident(Vertex curVertex)
        {
            if (FirstVertex.Index == curVertex.Index)
                return FirstVertex;
            if (SecondVertex.Index == curVertex.Index)
                return SecondVertex;
            return null;
        }
    }
}
