﻿using System;
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
        static List<Edge> _edgeList = new List<Edge>();
        public static List<Vertex> VerticesList = new List<Vertex>();
        private static int _numberVerticies;

        static void Main(string[] args)
        {
            Input();
            BreadthFirstSearch(0);
            StringBuilder sb = new StringBuilder("", _numberVerticies * 5);
            foreach (var vertex in VerticesList)
            {
                sb.Append(vertex.Distance.ToString() + " ");
            }
            Console.WriteLine(sb);
        }

        private static void Input()
        {
            int v, e;
            var str = Console.ReadLine();
            var array = str.Split();
            v = int.Parse(array[0]);
            e = int.Parse(array[1]);
            _numberVerticies = v;

            for (int i = 0; i < v; i++)
            {
                VerticesList.Add(new Vertex(i));
            }

            for (int i = 0; i < e; i++)
            {
                str = Console.ReadLine();
                array = str.Split();
                int firstIndex = int.Parse(array[0]);
                int secondIndex = int.Parse(array[1]);

                Edge edge = new Edge(VerticesList[firstIndex], VerticesList[secondIndex]);
                _edgeList.Add(edge);
            }
        }

        /// <summary>
        /// Поиск в ширину. Сложность 0(V + Е)
        /// </summary>
        public static void BreadthFirstSearch(int sourceIndex)
        {
            foreach (var vertex in VerticesList)
            {
                vertex.IsDiscovered = false;
                vertex.Distance = int.MinValue;
            }

            Vertex source = VerticesList[sourceIndex];

            source.IsDiscovered = true;
            source.Distance = 0;

            Queue<Vertex> queue = new Queue<Vertex>();
            queue.Enqueue(source);
            while (queue.Count > 0)
            {
                Vertex curVertex = queue.Dequeue();
                foreach (var edge in _edgeList)
                {
                    if (edge.IncidentFrom.Index == curVertex.Index || edge.IncidentTo.Index == curVertex.Index)
                    {
                        if (edge.IncidentFrom.Index == curVertex.Index && !edge.IncidentTo.IsDiscovered)
                        {
                            edge.IncidentFrom.IsDiscovered = true;
                            edge.IncidentTo.IsDiscovered = true;
                            edge.IncidentTo.Distance = curVertex.Distance + 1;
                            queue.Enqueue(edge.IncidentTo);
                        }
                        else
                        {
                            if (edge.IncidentTo.Index == curVertex.Index && !edge.IncidentFrom.IsDiscovered)
                            {
                                edge.IncidentTo.IsDiscovered = true;
                                edge.IncidentFrom.IsDiscovered = true;
                                edge.IncidentFrom.Distance = curVertex.Distance + 1;
                                queue.Enqueue(edge.IncidentFrom);
                            }
                        }
                    }
                }
            }
        }
    }
}
