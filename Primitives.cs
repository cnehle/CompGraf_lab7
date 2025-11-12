using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompGraphicsLab06
{
    /// <summary>
    /// Класс точки в пространстве 
    /// </summary>
    public class Point3D
    {
        public float X { get; set; } = 0;
        public float Y { get; set; } = 0;
        public float Z { get; set; } = 0;

        public Point3D(float x, float y, float z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }

        static public bool operator ==(Point3D point1, Point3D point2)
        {
            if (ReferenceEquals(point1, point2))
                return true;
            if (point1 is null || point2 is null)
                return false;
            return point1.X == point2.X && point1.Y == point2.Y && point1.Z == point2.Z;
        }

        static public bool operator !=(Point3D point1, Point3D point2)
        {
            return !(point1 == point2);
        }

        static public Point3D operator +(Point3D point1, Point3D point2)
        {
            return new Point3D(point1.X + point2.X, point1.Y + point2.Y, point1.Z + point2.Z);
        }

        static public Point3D operator -(Point3D point1, Point3D point2)
        {
            return new Point3D(point1.X - point2.X, point1.Y - point2.Y, point1.Z - point2.Z);
        }

        public override bool Equals(object obj)
        {
            if (obj is Point3D other)
                return this == other;
            return false;
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + X.GetHashCode();
                hash = hash * 23 + Y.GetHashCode();
                hash = hash * 23 + Z.GetHashCode();
                return hash;
            }
        }

        public Point ConvertToPoint()
        {
            return new Point((int)X, (int)Y);
        }
    }

    /// <summary>
    /// Класс ребра в пространтсве
    /// </summary>
    public class Edge
    {
        public Point3D From { get; set; }
        public Point3D To { get; set; }

        public Edge(Point3D point1, Point3D point2)
        {
            From = point1;
            To = point2;
        }
        public Edge(float x1, float y1, float z1, float x2, float y2, float z2)
        {
            From = new Point3D(x1, y1, z1);
            To = new Point3D(x2, y2, z2);
        }
    }

    /// <summary>
    /// Класс многогранника
    /// </summary>
    public class Polyhedron
    {
        /// <summary>
        /// Список вершин
        /// </summary>
        public List<Point3D> Vertexes { get; set; } = new List<Point3D>();

        /// <summary>
        /// Список ребер
        /// </summary>
        public List<Edge> Edges { get; set; } = new List<Edge>();

        /// <summary>
        /// Список граней. Грани заданы списком вершин (вершины заданы индексами в списке вершин)
        /// </summary>
        public List<List<int>> Faces { get; set; } = new List<List<int>>();

        /// <summary>
        /// Матрица смежности - для каждой точки хранит список смежных с ней
        /// </summary>
        public Dictionary<int, List<int>> Adjacency { get; set; } = new Dictionary<int, List<int>>();

        /// <summary>
        /// Находит центр многогранника
        /// </summary>
        public Point3D Center()
        {
            float x = Vertexes.Average(point => point.X);
            float y = Vertexes.Average(point => point.Y);
            float z = Vertexes.Average(point => point.Z);
            return new Point3D(x, y, z);
        }

        public bool IsEmpty() => Vertexes.Count < 1;

        public void Clear()
        {
            Vertexes.Clear();
            Edges.Clear();
            Faces.Clear();
            Adjacency.Clear();
        }

        /// <summary>
        /// Конструктор многогранника от списка вершин
        /// </summary>
        /// <param name="points"></param>
        public Polyhedron(List<Point3D> points)
        {
            Vertexes = points;
            int i = 0;
            foreach (Point3D point in points)
            {
                Adjacency.Add(i, new List<int>());
                i++;
            }
        }
        public Polyhedron() { }

        /// <summary>
        /// Добавить ребро
        /// </summary>
        /// <param name="from">Начало ребра</param>
        /// <param name="to">Конец ребра</param>
        public void AddEdge(int from, int to)
        {
            if (!Adjacency.ContainsKey(from))
                Adjacency.Add(from, new List<int> { to });
            else
                Adjacency[from].Add(to);
        }

        /// <summary>
        /// Добавить множество ребер из точки FROM в каждую точку списка LST
        /// </summary>
        /// <param name="from">Индекс начальной точки</param>
        /// <param name="lst">Индексы конечных точек, в которые идут ребра из начальной</param>
        public void AddEdges(int from, List<int> lst)
        {
            foreach (int to in lst)
                AddEdge(from, to);
        }

        /// <summary>
        /// Добавляет грань
        /// </summary>
        /// <param name="lst"></param>
        public void AddFace(List<int> lst)
        {
            Faces.Add(lst);
        }
    }
}