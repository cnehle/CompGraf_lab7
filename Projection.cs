// Projection.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompGraphicsLab06
{
    class Projection
    {
        private static float c = 1000;
        static private float[,] perspective =
        {
            { 1, 0, 0, 0 },
            { 0, 1, 0, 0 },
            { 0, 0, 0, -1 / c },
            { 0, 0, 0, 1 }
        };

        static private float[,] isometric =
            {  { (float)Math.Sqrt(0.5), 0, (float)-Math.Sqrt(0.5), 0 },
               { 1 / (float)Math.Sqrt(6), 2 /(float) Math.Sqrt(6), 1 / (float)Math.Sqrt(6), 0 },
               { 1 / (float)Math.Sqrt(3), -1 / (float)Math.Sqrt(3), 1 / (float)Math.Sqrt(3), 0 },
               { 0, 0, 0, 1 }};

        //перемножение матриц
        static public float[,] MultMatrix(float[,] m1, float[,] m2)
        {
            float[,] res = new float[m1.GetLength(0), m2.GetLength(1)];

            for (int i = 0; i < m1.GetLength(0); ++i)
                for (int j = 0; j < m2.GetLength(1); ++j)
                    for (int k = 0; k < m2.GetLength(0); k++)
                    {
                        res[i, j] += m1[i, k] * m2[k, j];
                    }

            return res;
        }

        /// <summary>
        /// Применяет матрицу проекции к одной точке
        /// </summary>
        private Point3D ApplyProjection(Point3D p, float[,] matr)
        {
            float[,] tmp = MultMatrix(new float[,] { { p.X, p.Y, p.Z, 1 } }, matr);
            // Применяем перспективное деление (деление на W-компоненту)
            return new Point3D(tmp[0, 0] / tmp[0, 3], tmp[0, 1] / tmp[0, 3]);
        }

        /// <summary>
        /// Выполняет проекцию для набора ребер (используется для осей)
        /// </summary>
        public List<Edge> ProjectEdges(List<Edge> inputEdges, int mode)
        {
            float[,] matr;
            switch (mode)
            {
                case 0:
                    matr = perspective;
                    break;
                case 1:
                    matr = isometric;
                    break;
                default:
                    throw new ArgumentException();
            }

            List<Edge> projectedEdges = new List<Edge>();
            foreach (var edge in inputEdges)
            {
                Point3D from = ApplyProjection(edge.From, matr);
                Point3D to = ApplyProjection(edge.To, matr);
                projectedEdges.Add(new Edge(from, to));
            }
            return projectedEdges;
        }


        /// <summary>
        /// Выполняет проекцию
        /// </summary>
        /// <param name="polyhedron">входной многогранник</param>
        /// <returns>Список точек на плоскости (для рисования на экране)</returns>
        public List<Edge> Project(Polyhedron polyhedron, int mode)
        {
            float[,] matr;
            switch (mode)
            {
                case 0:
                    matr = perspective;
                    break;
                case 1:
                    matr = isometric;
                    break;
                default:
                    throw new ArgumentException();
            }
            List<Edge> edges = new List<Edge>();

            int i = 0;
            // Для каждой вершины обрабатываем её и запускаем обработку смежных с ней
            foreach (Point3D p in polyhedron.Vertexes)
            {
                Point3D from = ApplyProjection(p, matr);

                // Обработка смежных с вершиной
                foreach (int index in polyhedron.Adjacency[i])
                {
                    Point3D t = polyhedron.Vertexes[index];
                    Point3D to = ApplyProjection(t, matr);
                    edges.Add(new Edge(from, to));
                }
                i++;
            }

            return edges;
        }
    }
}
