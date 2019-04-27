using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * На вход программе подаётся описание простого связного графа.
 * Первая строка содержит два числа: число вершин V≤10000 и число рёбер E≤30000 графа.
 * Следующие E строк содержат номера пар вершин, соединенных рёбрами.
 * Вершины имеют номера от 0 до V−1.
 * Выведите список из V чисел — расстояний от вершины 0 до соответствующих вершин графа.
 */

namespace BFSEdgeListCSharp
{
    class Program
    {
        static List<List<Vertex>> _edgeList = new List<List<Vertex>>();
        static void Main(string[] args)
        {
            Input();
            List<Vertex> vertices = BreadthFirstSearch(GetVertex(0));
            string distances = "";
            foreach (var vertex in vertices)
            {
                distances += vertex.Distance.ToString();
                distances += " ";
            }
            Console.WriteLine(distances);
        }

        private static void Input()
        {
            int v, e;
            var str = Console.ReadLine();
            var array = str.Split();
            v = int.Parse(array[0]);
            e = int.Parse(array[1]);

            for (int i = 0; i < e; i++)
            {
                List<Vertex> list = new List<Vertex>();
                str = Console.ReadLine();
                array = str.Split();
                for (int j = 0; j < 2; j++)
                {
                    int intVar = int.Parse(array[j]);
                    Vertex vertex = new Vertex(intVar);
                    list.Add(vertex);
                }

                _edgeList.Add(list);
            }
        }

        public static Vertex GetVertex(int index)
        {
            foreach (var edge in _edgeList)
            {
                foreach (var vertex in edge)
                {
                    if (vertex.Index == index)
                        return vertex;
                }
            }

            return null;
        }

        /// <summary>
        /// Поиск в ширину. Сложность 0(V + Е)
        /// </summary>
        public static List<Vertex> BreadthFirstSearch(Vertex source)
        {
            foreach (var edge in _edgeList)
            {
                foreach (var vertex in edge)
                {
                    vertex.IsDiscovered = false;
                    vertex.Distance = int.MinValue;
                }
            }
            source.IsDiscovered = true;
            source.Distance = 0;

            List<Vertex> vertices = new List<Vertex>();
            vertices.Add(source);

            Queue<Vertex> queue = new Queue<Vertex>();
            queue.Enqueue(source);
            while (queue.Count != 0)
            {
                Vertex curVertex = queue.Dequeue();
                foreach (var edge in _edgeList)
                    for (int i = 0; i < 2; i++)
                    {
                        if (edge[i].Index == curVertex.Index)
                            edge[i].IsDiscovered = true;
                        int incident = i == 0 ? 1 : 0;
                        if (edge[i].Index == curVertex.Index && !edge[incident].IsDiscovered)
                        {
                            edge[incident].IsDiscovered = true;
                            edge[incident].Distance = curVertex.Distance + 1;
                            queue.Enqueue(edge[incident]);
                            vertices.Add(edge[incident]);
                            foreach (var edge2 in _edgeList)
                                for (int j = 0; j < 2; j++)
                                    if (edge2[j].Index == edge[incident].Index)
                                        edge2[j].IsDiscovered = true;
                        }
                    }
            }
            return vertices;
        }
    }
}
