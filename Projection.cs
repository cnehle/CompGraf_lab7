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
                // Все многогранники начинаются в (0, 0, 0). Добавляем смещение, чтобы фигуры были примерно по центру
                Point3D p1 = p;// + new Point3D(250 , 150, 200 );
                float[,] tmp = MultMatrix(new float[,] { { p1.X, p1.Y, p1.Z, 1 } }, matr);
                Point3D from = new Point3D(tmp[0, 0] / tmp[0, 3], tmp[0, 1] / tmp[0, 3]);


                // Обработка смежных с вершиной
                foreach (int index in polyhedron.Adjacency[i])
                {
                    // Все многогранники начинаются в (0, 0, 0). Добавляем смещение, чтобы фигуры были примерно по центру
                    Point3D t = polyhedron.Vertexes[index];// + new Point3D(250 , 150, 200 ); 

                    float[,] tmp1 = MultMatrix(new float[,] { { t.X, t.Y, t.Z, 1 } }, matr);
                    Point3D to = new Point3D(tmp1[0, 0] / tmp1[0, 3], tmp1[0, 1] / tmp1[0, 3]);
                    edges.Add(new Edge(from, to));
                }
                i++;
            }

            return edges;
        }
    }
}
