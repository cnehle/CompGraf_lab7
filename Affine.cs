using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompGraphicsLab06
{
    class Affine
    {
        static private float[,] matrixColumnFromPoint3D(Point3D point)
        {
            return new float[,] { { point.X }, { point.Y }, { point.Z }, { 1 } };

        }

        /// <summary>
        /// Применения матрицы преобразований к каждой точке многогранника
        /// </summary>
        static private void ChangePolyhedron(Polyhedron polyhedron, float[,] matrix)
        {
            List<Point3D> points = new List<Point3D>();
            for (int i = 0; i < polyhedron.Vertexes.Count; ++i) // применяем преобразования к каждой точке
            {
                var matrixPoint = Projection.MultMatrix(matrix, matrixColumnFromPoint3D(polyhedron.Vertexes[i]));
                Point3D newPoint = new Point3D(matrixPoint[0, 0] / matrixPoint[3, 0], matrixPoint[1, 0] / matrixPoint[3, 0], matrixPoint[2, 0] / matrixPoint[3, 0]);
                polyhedron.Vertexes[i] = newPoint;
            }
        }
        /// <summary>
        /// Сдвинуть многогранник
        /// </summary>
        static public void translate(Polyhedron polyhedron, float tx, float ty, float tz)
        {
            float[,] translation = { { 1, 0, 0, tx },
                                     { 0, 1, 0, ty },
                                     { 0, 0, 1, tz },
                                     { 0, 0, 0,  1 }};

            ChangePolyhedron(polyhedron, translation);
        }

        /// <summary>
        /// Масштабирование относительно оси
        /// </summary>
        static public void scale(Polyhedron polyhedron, float mx, float my, float mz)
        {
            float[,] scale = { { mx,  0,  0,  0 },
                               {  0, my,  0,  0 },
                               {  0,  0, mz,  0 },
                               {  0,  0,  0,  1 }};

            ChangePolyhedron(polyhedron, scale);
        }

        /// <summary>
        /// Поворот
        /// </summary>
        /// <param name="polyhedron"></param>
        /// <param name="angleX">угол поворота по OX в градусах</param>
        /// <param name="angleY">угол поворота по OY в градусах</param>
        /// <param name="angleZ">угол поворота по OZ в градусах</param>
        static public void rotation(Polyhedron polyhedron, float angleX, float angleY, float angleZ)
        {
            Point3D shiftPoint = polyhedron.Center();
            float shiftX = shiftPoint.X,
                  shiftY = shiftPoint.Y,
                  shiftZ = shiftPoint.Z;

            translate(polyhedron, -shiftX, -shiftY, -shiftZ);

            float sin = (float)Math.Sin(angleX * Math.PI / 180);
            float cos = (float)Math.Cos(angleX * Math.PI / 180);
            float[,] matrixX = { { 1,  0,   0,  0},
                                 { 0, cos,-sin, 0},
                                 { 0, sin, cos, 0},
                                 { 0,  0,   0,  1}};

            sin = (float)Math.Sin(angleY * Math.PI / 180);
            cos = (float)Math.Cos(angleY * Math.PI / 180);
            float[,] matrixY = { { cos, 0, sin, 0},
                                 {  0,  1,  0,  0},
                                 {-sin, 0, cos, 0},
                                 {  0,  0,  0,  1}};

            sin = (float)Math.Sin(angleZ * Math.PI / 180);
            cos = (float)Math.Cos(angleZ * Math.PI / 180);
            float[,] matrixZ = { { cos, -sin, 0, 0},
                                 { sin,  cos, 0, 0},
                                 {  0,    0,  1, 0},
                                 {  0,    0,  0, 1}};

            ChangePolyhedron(polyhedron, Projection.MultMatrix(Projection.MultMatrix(matrixX, matrixY), matrixZ));

            translate(polyhedron, shiftX, shiftY, shiftZ);
        }

        // Отражение относительно выбранной координатной плоскости
        public static void reflection(Polyhedron polyhedron, string plane)
        {
            float[,] matrix;
            switch (plane)
            {
                case "xy":
                    matrix = new float[,] {{ 1, 0,  0, 0 },
                                           { 0, 1,  0, 0 },
                                           { 0, 0, -1, 0 },
                                           { 0, 0,  0, 1 }};
                    break;
                case "xz":
                    matrix = new float[,] {{ 1,  0, 0, 0 },
                                           { 0, -1, 0, 0 },
                                           { 0,  0, 1, 0 },
                                           { 0,  0, 0, 1 }};
                    break;
                case "yz":
                    matrix = new float[,] {{ -1, 0, 0, 0 },
                                           {  0, 1, 0, 0 },
                                           {  0, 0, 1, 0 },
                                           {  0, 0, 0, 1 }};
                    break;
                default:
                    matrix = new float[,] {{ 1, 0, 0, 0 },
                                           { 0, 1, 0, 0 },
                                           { 0, 0, 1, 0 },
                                           { 0, 0, 0, 1 }};
                    break;
            }
            ChangePolyhedron(polyhedron, matrix);
        }

        // Масштабирование относительно центра
        public static void scaleCenter(Polyhedron polyhedron, float a)
        {
            Point3D shiftPoint = polyhedron.Center();
            float shiftX = shiftPoint.X,
                  shiftY = shiftPoint.Y,
                  shiftZ = shiftPoint.Z;

            translate(polyhedron, -shiftX, -shiftY, -shiftZ);

            float[,] scale = { { a, 0, 0, 0 },
                               { 0, a, 0, 0 },
                               { 0, 0, a, 0 },
                               { 0, 0, 0, 1 }};

            ChangePolyhedron(polyhedron, scale);
            translate(polyhedron, shiftX, shiftY, shiftZ);
        }

        /// <summary>
        /// Вращение многогранника вокруг прямой, проходящей через центр, параллельно выбранно координатной оси
        /// </summary>
        /// <param name="polyhedron"></param>
        /// <param name="angleX"></param>
        /// <param name="angleY"></param>
        /// <param name="angleZ"></param>
        public static void rotateCenter(Polyhedron polyhedron, float angleX, float angleY, float angleZ)
        {
            var center = polyhedron.Center();
            translate(polyhedron, -center.X, -center.Y, -center.Z);
            rotation(polyhedron, angleX, angleY, angleZ);
            translate(polyhedron, center.X, center.Y, center.Z);
        }

public static void rotateAboutLine(Polyhedron polyhedron, float angle, Edge line)
{
    // 1. Перенести прямую L в центр координат на –А (-a,-b,-c)
    Point3D A = line.From;
    translate(polyhedron, -A.X, -A.Y, -A.Z);

    // 2. Совместить прямую L с осью Z
    Point3D direction = line.To - line.From;
    
    // Вычисляем углы для совмещения с осью Z
    // Длина проекции на плоскость XY
    float lengthXY = (float)Math.Sqrt(direction.X * direction.X + direction.Y * direction.Y);
    
    // Угол поворота вокруг оси Z (чтобы спроецировать на плоскость XZ)
    float angleZ = 0;
    if (lengthXY > 0.0001f)
    {
        angleZ = -(float)(Math.Atan2(direction.Y, direction.X) * 180 / Math.PI);
    }

    // Поворачиваем вокруг Z
    rotation(polyhedron, 0, 0, angleZ);

    // Обновляем направление после первого поворота
    direction = rotatePoint(direction, 0, 0, angleZ);
    
    // Угол поворота вокруг оси Y (чтобы совместить с осью Z)
    float length = (float)Math.Sqrt(direction.X * direction.X + direction.Y * direction.Y + direction.Z * direction.Z);
    float angleY = 0;
    if (length > 0.0001f && Math.Abs(direction.X) > 0.0001f)
    {
        angleY = -(float)(Math.Atan2(direction.Z, direction.X) * 180 / Math.PI);
    }

    // Поворачиваем вокруг Y
    rotation(polyhedron, 0, angleY, 0);

    // 3. Выполнить поворот объекта вокруг прямой L (теперь это ось Z)
    rotation(polyhedron, 0, 0, angle);

    // 4. Выполнить повороты 2 в обратной последовательности на обратные углы
    rotation(polyhedron, 0, -angleY, 0);  // Обратный поворот вокруг Y
    rotation(polyhedron, 0, 0, -angleZ);  // Обратный поворот вокруг Z

    // 5. Выполнить перенос на А (a, b, c)
    translate(polyhedron, A.X, A.Y, A.Z);
}

// Вспомогательный метод для поворота точки
private static Point3D rotatePoint(Point3D point, float angleX, float angleY, float angleZ)
{
    // Создаем временный полиэдр из одной точки
    Polyhedron temp = new Polyhedron(new List<Point3D> { point });
    rotation(temp, angleX, angleY, angleZ);
    return temp.Vertexes[0];
}
    }
}
