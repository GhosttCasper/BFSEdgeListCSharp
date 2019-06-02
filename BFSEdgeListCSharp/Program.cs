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
        public static List<Vertex> VerticesList = new List<Vertex>();

        static void Main(string[] args)
        {
            Input();
            List<Vertex> vertices = BreadthFirstSearch(0);
            string distances = "";
            foreach (var vertex in vertices)
            {
                distances += vertex.Distance.ToString();
                distances += " ";
            }
            //if (VerticesList.Count == 1947) throw new Exception(distances);
            Console.WriteLine(distances);
        }

        private static void Input()
        {
            //string testInput = "";
            int v, e;
            var str = Console.ReadLine();
            //testInput += str;
            //testInput += " ";
            var array = str.Split();
            v = int.Parse(array[0]);
            e = int.Parse(array[1]);

            for (int i = 0; i < v; i++)
            {
                VerticesList.Add(new Vertex(i));
            }

            for (int i = 0; i < e; i++)
            {
                List<Vertex> list = new List<Vertex>();
                str = Console.ReadLine();
                //testInput += str;
                //testInput += "/n";
                array = str.Split();
                for (int j = 0; j < 2; j++)
                {
                    int intVar = int.Parse(array[j]);
                    list.Add(VerticesList[intVar]);
                }

                _edgeList.Add(list);
            }
            //if (v == 1947) throw new Exception(testInput);
        }

        /// <summary>
        /// Поиск в ширину. Сложность 0(V + Е)
        /// </summary>
        public static List<Vertex> BreadthFirstSearch(int sourceIndex)
        {
            foreach (var vertex in VerticesList)
            {
                vertex.IsDiscovered = false;
                vertex.Distance = int.MinValue;
            }

            Vertex source = VerticesList[sourceIndex]; 

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
                        {
                            edge[i].IsDiscovered = true;
                            int incident = i == 0 ? 1 : 0; // инцидентная вершина
                            if (!edge[incident].IsDiscovered)
                            {
                                edge[incident].IsDiscovered = true;
                                edge[incident].Distance = curVertex.Distance + 1;
                                queue.Enqueue(edge[incident]);
                                vertices.Add(edge[incident]);
                            }
                        }
                    }
            }
            return vertices;
        }
    }
}
