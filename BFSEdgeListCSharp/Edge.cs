using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFSEdgeListCSharp
{
    public class Edge
    {
        public Vertex IncidentFrom; // выходит (начало)
        public Vertex IncidentTo; // входит (конец)

        public Edge(Vertex incidentFrom, Vertex incidentTo)
        {
            IncidentFrom = incidentFrom;
            IncidentTo = incidentTo;
        }
    }
}
