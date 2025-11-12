using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CompGraphicsLab06
{
    class ObjFileHandler
    {
        public static Polyhedron LoadFromObj(string filePath)
        {
            try
            {
                Polyhedron polyhedron = new Polyhedron();
                List<Point3D> vertices = new List<Point3D>();
                List<List<int>> faces = new List<List<int>>();

                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string trimmedLine = line.Trim();
                    if (string.IsNullOrEmpty(trimmedLine) || trimmedLine.StartsWith("#"))
                        continue;

                    if (trimmedLine.StartsWith("v "))
                    {
                        string[] parts = trimmedLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length >= 4)
                        {
                            float x = float.Parse(parts[1], System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture);
                            float y = float.Parse(parts[2], System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture);
                            float z = float.Parse(parts[3], System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture);
                            vertices.Add(new Point3D(x, y, z));
                        }
                    }
                    else if (trimmedLine.StartsWith("f "))
                    {
                        string[] parts = trimmedLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        List<int> faceVertices = new List<int>();

                        for (int i = 1; i < parts.Length; i++)
                        {
                            string[] vertexData = parts[i].Split('/');
                            int vertexIndex = int.Parse(vertexData[0]) - 1;
                            faceVertices.Add(vertexIndex);
                        }

                        faces.Add(faceVertices);
                    }
                }

                polyhedron.Vertexes = vertices;

                // Создаем ребра и грани
                foreach (var face in faces)
                {
                    for (int i = 0; i < face.Count; i++)
                    {
                        int current = face[i];
                        int next = face[(i + 1) % face.Count];
                        polyhedron.AddEdge(current, next);
                    }
                    polyhedron.AddFace(face);
                }

                // Автоматическое масштабирование и центрирование модели
                NormalizePolyhedron(polyhedron);

                return polyhedron;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading OBJ file: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                return null;
            }
        }

        // Новый метод для нормализации полигона
        private static void NormalizePolyhedron(Polyhedron polyhedron)
        {
            if (polyhedron.Vertexes.Count == 0) return;

            // Находим границы модели
            float minX = float.MaxValue, maxX = float.MinValue;
            float minY = float.MaxValue, maxY = float.MinValue;
            float minZ = float.MaxValue, maxZ = float.MinValue;

            foreach (var vertex in polyhedron.Vertexes)
            {
                minX = Math.Min(minX, vertex.X);
                maxX = Math.Max(maxX, vertex.X);
                minY = Math.Min(minY, vertex.Y);
                maxY = Math.Max(maxY, vertex.Y);
                minZ = Math.Min(minZ, vertex.Z);
                maxZ = Math.Max(maxZ, vertex.Z);
            }

            // Вычисляем центр и размеры
            float centerX = (minX + maxX) / 2;
            float centerY = (minY + maxY) / 2;
            float centerZ = (minZ + maxZ) / 2;

            float sizeX = maxX - minX;
            float sizeY = maxY - minY;
            float sizeZ = maxZ - minZ;
            float maxSize = Math.Max(sizeX, Math.Max(sizeY, sizeZ));

            // Масштабируем модель к размеру ~200 единиц и центрируем
            float scale = 200.0f / maxSize;

            for (int i = 0; i < polyhedron.Vertexes.Count; i++)
            {
                var vertex = polyhedron.Vertexes[i];
                // Центрируем и масштабируем
                polyhedron.Vertexes[i] = new Point3D(
                    (vertex.X - centerX) * scale,
                    (vertex.Y - centerY) * scale,
                    (vertex.Z - centerZ) * scale
                );
            }
        }

        public static bool SaveToObj(Polyhedron polyhedron, string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (Point3D vertex in polyhedron.Vertexes)
                    {
                        writer.WriteLine($"v {vertex.X} {vertex.Y} {vertex.Z}");
                    }

                    foreach (List<int> face in polyhedron.Faces)
                    {
                        writer.Write("f");
                        foreach (int vertexIndex in face)
                        {
                            writer.Write($" {vertexIndex + 1}");
                        }
                        writer.WriteLine();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving OBJ file: {ex.Message}");
                return false;
            }
        }
    }
}