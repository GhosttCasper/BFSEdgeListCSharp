using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFSEdgeListCSharp
{
    public class Vertex //<T> where T : IComparable
    {
        public bool IsDiscovered;
        public int Distance;
        public int Index;

        public Vertex(int index)
        {
            Index = index;
            Distance = int.MinValue;
        }
    }
}
