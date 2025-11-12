using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CompGraphicsLab06
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private Pen pen;
        private Projection projection;
        private List<Point3D> pointsRotate;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;

        /// <summary>
        /// Текущий многогранник
        /// </summary>
        private Polyhedron curPolyhedron;

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);
            graphics.Clear(Color.White);
            pen = new Pen(Color.DarkRed, 2);
            projection = new Projection();
            radioButton1.Checked = true;
            projBox.SelectedIndex = 0;
            pointsRotate = new List<Point3D>();
        }

        /// <summary>
        /// Создает ребра для осей координат (X, Y, Z)
        /// </summary>
        private List<Edge> GetAxesEdges(float length = 200)
        {
            Point3D origin = new Point3D(0, 0, 0);
            Point3D xEnd = new Point3D(length, 0, 0);
            Point3D yEnd = new Point3D(0, length, 0);
            Point3D zEnd = new Point3D(0, 0, length);

            return new List<Edge>
            {
                new Edge(origin, xEnd), // 0: X-axis (Red)
                new Edge(origin, yEnd), // 1: Y-axis (Green)
                new Edge(origin, zEnd)  // 2: Z-axis (Blue)
            };
        }

        /// <summary>
        /// Отрисовывает оси координат
        /// </summary>
        private void DrawAxes(float offsetX, float offsetY)
        {
            List<Edge> axes3D = GetAxesEdges(600);
            List<Edge> axesProjected = projection.ProjectEdges(axes3D, projBox.SelectedIndex);

            // X-axis: Red
            Pen penX = new Pen(Color.Red, 2);
            // Y-axis: Green
            Pen penY = new Pen(Color.Green, 2);
            // Z-axis: Blue
            Pen penZ = new Pen(Color.Blue, 2);

            // Рисуем X
            var p1X = axesProjected[0].From.ConvertToPoint();
            var p2X = axesProjected[0].To.ConvertToPoint();
            graphics.DrawLine(penX, p1X.X + offsetX, p1X.Y + offsetY, p2X.X + offsetX, p2X.Y + offsetY);

            // Рисуем Y
            var p1Y = axesProjected[1].From.ConvertToPoint();
            var p2Y = axesProjected[1].To.ConvertToPoint();
            graphics.DrawLine(penY, p1Y.X + offsetX, p1Y.Y + offsetY, p2Y.X + offsetX, p2Y.Y + offsetY);

            // Рисуем Z
            var p1Z = axesProjected[2].From.ConvertToPoint();
            var p2Z = axesProjected[2].To.ConvertToPoint();
            graphics.DrawLine(penZ, p1Z.X + offsetX, p1Z.Y + offsetY, p2Z.X + offsetX, p2Z.Y + offsetY);
        }

        private void Draw()
        {
            graphics.Clear(Color.White);

            var centerX = pictureBox1.Width / 2;
            var centerY = pictureBox1.Height / 2;

            if (curPolyhedron == null || curPolyhedron.IsEmpty())
            {
                DrawAxes(centerX, centerY);
                pictureBox1.Invalidate();
                return;
            }

            // Проецируем фигуру
            pen = new Pen(Color.Black, 2);
            List<Edge> edges = projection.Project(curPolyhedron, projBox.SelectedIndex);

            // Для больших моделей используем фиксированное смещение
            float offsetX = centerX;
            float offsetY = centerY;

            // Рисуем оси
            DrawAxes(offsetX, offsetY);

            // Рисуем фигуру
            foreach (Edge line in edges)
            {
                var p1 = line.From.ConvertToPoint();
                var p2 = line.To.ConvertToPoint();

                graphics.DrawLine(pen,
                    p1.X + offsetX, p1.Y + offsetY,
                    p2.X + offsetX, p2.Y + offsetY);
            }

            pictureBox1.Invalidate();
        }

        /// <summary>
        /// Построение куба
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            Point3D start = new Point3D(0, 0, 0); //new Point3D(250, 150, 200);
            float len = 150;

            List<Point3D> points = new List<Point3D>
            {
                start,
                start + new Point3D(len, 0, 0),
                start + new Point3D(len, 0, len),
                start + new Point3D(0, 0, len),

                start + new Point3D(0, len, 0),
                start + new Point3D(len, len, 0),
                start + new Point3D(len, len, len),
                start + new Point3D(0, len, len)
            };

            curPolyhedron = new Polyhedron(points);
            curPolyhedron.AddEdges(0, new List<int> { 1, 4 });
            curPolyhedron.AddEdges(1, new List<int> { 2, 5 });
            curPolyhedron.AddEdges(2, new List<int> { 6, 3 });
            curPolyhedron.AddEdges(3, new List<int> { 7, 0 });
            curPolyhedron.AddEdges(4, new List<int> { 5 });
            curPolyhedron.AddEdges(5, new List<int> { 6 });
            curPolyhedron.AddEdges(6, new List<int> { 7 });
            curPolyhedron.AddEdges(7, new List<int> { 4 });

            Draw();
        }

        /// <summary>
        /// Построение тетраэдра
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            Point3D start = new Point3D(0, 0, 0);  //= new Point3D(250, 150, 200);
            float len = 150;

            List<Point3D> points = new List<Point3D>
            {
                start,
                start + new Point3D(len, 0, len),
                start + new Point3D(len, len, 0),
                start + new Point3D(0, len, len),
            };

            curPolyhedron = new Polyhedron(points);
            curPolyhedron.AddEdges(0, new List<int> { 1, 3, 2 });
            curPolyhedron.AddEdges(1, new List<int> { 3 });
            curPolyhedron.AddEdges(2, new List<int> { 1, 3 });

            Draw();
        }

        /// <summary>
        /// Очистить экран
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
            pictureBox1.Invalidate();
        }

        /// <summary>
        /// Построение и рисование октаэдра
        /// </summary>
        private void button4_Click(object sender, EventArgs e)
        {
            Point3D start = new Point3D(0, 0, 0); //= new Point3D(250 + 75, 150, 200 + 75);
            float len = 150;

            List<Point3D> points = new List<Point3D>
            {
                start,
                start + new Point3D(len , len , 0),
                start + new Point3D(-len, len , 0),
                start + new Point3D(0, len , -len ),
                start + new Point3D(0, len , len ),
                start + new Point3D(0,  2 *len, 0),
            };

            curPolyhedron = new Polyhedron(points);
            curPolyhedron.AddEdges(0, new List<int> { 1, 3, 2, 4 });
            curPolyhedron.AddEdges(5, new List<int> { 1, 3, 2, 4 });
            curPolyhedron.AddEdges(1, new List<int> { 3 });
            curPolyhedron.AddEdges(3, new List<int> { 2 });
            curPolyhedron.AddEdges(2, new List<int> { 4 });
            curPolyhedron.AddEdges(4, new List<int> { 1 });
            Draw();
        }

        /// <summary>
        /// Создание икосаэдра
        /// </summary>
        private void createIcosahedron_Click(object sender, EventArgs e)
        {
            float r = 100 * (1 + (float)Math.Sqrt(5)) / 4; // радиус полувписанной окружности 

            List<Point3D> points = new List<Point3D>
            {
                new Point3D(0, -50, -r),
                new Point3D(0, 50, -r),
                new Point3D(50, r, 0),
                new Point3D(r, 0, -50),
                new Point3D(50, -r, 0),
                new Point3D(-50, -r, 0),
                new Point3D(-r, 0, -50),
                new Point3D(-50, r, 0),
                new Point3D(r, 0, 50),
                new Point3D(-r, 0, 50),
                new Point3D(0, -50, r),
                new Point3D(0, 50, r)
            };

            Polyhedron iko = new Polyhedron(points);

            iko.AddEdges(0, new List<int> { 1, 3, 4, 5, 6 });
            iko.AddEdges(1, new List<int> { 2, 3, 6, 7 });
            iko.AddEdges(2, new List<int> { 3, 7, 8, 11 });
            iko.AddEdges(3, new List<int> { 4, 8 });
            iko.AddEdges(4, new List<int> { 5, 8, 10 });
            iko.AddEdges(5, new List<int> { 6, 9, 10 });
            iko.AddEdges(6, new List<int> { 7, 9 });
            iko.AddEdges(7, new List<int> { 9, 11 });
            iko.AddEdges(8, new List<int> { 10, 11 });
            iko.AddEdges(9, new List<int> { 10, 11 });
            iko.AddEdges(10, new List<int> { 11 });

            curPolyhedron = iko;
            Draw();
        }

        /// <summary>
        /// Создание додекаэдра
        /// </summary>
        private void createDodecahedron_Click(object sender, EventArgs e)
        {
            float r = 100 * (3 + (float)Math.Sqrt(5)) / 4; // радиус полувписанной окружности 
            float x = 100 * (1 + (float)Math.Sqrt(5)) / 4; // половина стороны пятиугольника в сечении 

            List<Point3D> points = new List<Point3D>
            {
                new Point3D(0, -50, -r),
                new Point3D(0, 50, -r),
                new Point3D(x, x, -x),
                new Point3D(r, 0, -50),
                new Point3D(x, -x, -x),
                new Point3D(50, -r, 0),
                new Point3D(-50, -r, 0),
                new Point3D(-x, -x, -x),
                new Point3D(-r, 0, -50),
                new Point3D(-x, x, -x),
                new Point3D(-50, r, 0),
                new Point3D(50, r, 0),
                new Point3D(-x, -x, x),
                new Point3D(0, -50, r),
                new Point3D(x, -x, x),
                new Point3D(0, 50, r),
                new Point3D(-x, x, x),
                new Point3D(x, x, x),
                new Point3D(-r, 0, 50),
                new Point3D(r, 0, 50)
            };

            Polyhedron dode = new Polyhedron(points);

            dode.AddEdges(0, new List<int> { 1, 4, 7 });
            dode.AddEdges(1, new List<int> { 2, 9 });
            dode.AddEdges(2, new List<int> { 3, 11 });
            dode.AddEdges(3, new List<int> { 4, 19 });
            dode.AddEdges(4, new List<int> { 5 });
            dode.AddEdges(5, new List<int> { 6, 14 });
            dode.AddEdges(6, new List<int> { 7, 12 });
            dode.AddEdges(7, new List<int> { 8 });
            dode.AddEdges(8, new List<int> { 9, 18 });
            dode.AddEdges(9, new List<int> { 10 });
            dode.AddEdges(10, new List<int> { 11, 16 });
            dode.AddEdges(11, new List<int> { 17 });
            dode.AddEdges(12, new List<int> { 13, 18 });
            dode.AddEdges(13, new List<int> { 14, 15 });
            dode.AddEdges(14, new List<int> { 19 });
            dode.AddEdges(15, new List<int> { 16, 17 });
            dode.AddEdges(16, new List<int> { 18 });
            dode.AddEdges(17, new List<int> { 19 });

            //Affine.translate(dode, 200, 200, 0);
            curPolyhedron = dode;

            Draw();
        }


        // Применить преобразования
        private void button5_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked) // Смещение по оси
            {
                float x = float.Parse(textBox1.Text);
                float y = float.Parse(textBox2.Text);
                float z = float.Parse(textBox3.Text);

                Affine.translate(curPolyhedron, x, y, z);
                Draw();
            }
            if (radioButton2.Checked) // Масштаб
            {
                float x = float.Parse(textBox1.Text) / 100;
                float y = float.Parse(textBox2.Text) / 100;
                float z = float.Parse(textBox3.Text) / 100;
                if (x > 0 && y > 0 && z > 0)
                {
                    Affine.scale(curPolyhedron, x, y, z);
                    Draw();
                }
            }
            if (radioButton3.Checked) // Поворот
            {
                float x = float.Parse(textBox1.Text);
                float y = float.Parse(textBox2.Text);
                float z = float.Parse(textBox3.Text);
                Affine.rotation(curPolyhedron, x, y, z);
                Draw();
            }
            if (radioButton4.Checked) // Отражение
            {
                string plane = "";
                switch (comboBox1.Text)
                {
                    case "Плоскость Oxy":
                        plane = "xy";
                        break;
                    case "Плоскость Oxz":
                        plane = "xz";
                        break;
                    case "Плоскость Oyz":
                        plane = "yz";
                        break;
                    default:
                        break;
                }
                if (plane!="")
                {
                    Affine.reflection(curPolyhedron, plane);
                    Draw();
                }
            }
            if (radioButton5.Checked) // Масштабирование относительно центра
            {
                float a = float.Parse(textBox4.Text) / 100;
                Affine.scaleCenter(curPolyhedron, a);
                Draw();
            }
        }

        private void radioButton1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            comboBox1.Text = "";
            textBox4.Text = "100";
        }

        private void radioButton2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "100";
            textBox2.Text = "100";
            textBox3.Text = "100";
            comboBox1.Text = "";
            textBox4.Text = "100";
        }

        private void radioButton3_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            comboBox1.Text = "";
            textBox4.Text = "100";
        }

        private void radioButton5_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "100";
            comboBox1.Text = "";
        }

        private void radioButton4_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "100";
        }

        private void projBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (curPolyhedron!=null)
                Draw();
        }

        private void rotateOX_Click(object sender, EventArgs e)
        {
            rotateOY.Checked = rotateOZ.Checked = rotateOwn.Checked = false;
        }

        private void rotateOY_Click(object sender, EventArgs e)
        {
            rotateOX.Checked = rotateOZ.Checked = rotateOwn.Checked = false;
        }

        private void rotateOZ_Click(object sender, EventArgs e)
        {
            rotateOY.Checked = rotateOX.Checked = rotateOwn.Checked = false;
        }

        private void rotateBtn_Click(object sender, EventArgs e)
        {
            if (rotateOX.Checked)
                Affine.rotateCenter(curPolyhedron, (float)rotateAngle.Value, 0, 0);
            else if (rotateOY.Checked)
                Affine.rotateCenter(curPolyhedron, 0, (float)rotateAngle.Value, 0);
            else if (rotateOZ.Checked)
                Affine.rotateCenter(curPolyhedron, 0, 0, (float)rotateAngle.Value);
            else if (rotateOwn.Checked)
                Affine.rotateAboutLine(curPolyhedron, (float)rotateAngle.Value, new Edge(float.Parse(rX1.Text), float.Parse(rY1.Text), float.Parse(rZ1.Text),
                    float.Parse(rX2.Text), float.Parse(rY2.Text), float.Parse(rZ2.Text)));
            Draw();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void rotateOwn_Click(object sender, EventArgs e)
        {
            rotateOY.Checked = rotateOZ.Checked = rotateOX.Checked = false;
        }

        // Методы для работы с OBJ файлами
        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "obj";
            openFileDialog.Filter = "OBJ files|*.obj|All files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fName = openFileDialog.FileName;
                if (File.Exists(fName))  // Теперь File будет распознан
                {
                    curPolyhedron = ObjFileHandler.LoadFromObj(fName);
                    if (curPolyhedron != null)
                    {
                        Draw();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка загрузки файла OBJ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "obj";
            saveFileDialog.Filter = "OBJ files|*.obj|All files|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fName = saveFileDialog.FileName;
                if (ObjFileHandler.SaveToObj(curPolyhedron, fName))
                {
                    MessageBox.Show("Файл успешно сохранен", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ошибка сохранения файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Методы для фигуры вращения
        private void addPointButton_Click(object sender, EventArgs e)
        {
            if (float.TryParse(textBoxRotateX.Text, out float x) &&
                float.TryParse(textBoxRotateY.Text, out float y) &&
                float.TryParse(textBoxRotateZ.Text, out float z))
            {
                pointsRotate.Add(new Point3D(x, y, z));
                DrawCurve();
            }
            else
            {
                MessageBox.Show("Введите корректные числовые значения координат", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DrawCurve()
        {
            graphics.Clear(Color.White);
            int startX = pictureBox1.Width / 2;
            int startY = pictureBox1.Height / 2;

            if (pointsRotate.Count > 1)
            {
                for (int i = 1; i < pointsRotate.Count; i++)
                {
                    graphics.DrawLine(new Pen(Color.Black),
                        startX + pointsRotate[i - 1].ConvertToPoint().X,
                        startY + pointsRotate[i - 1].ConvertToPoint().Y,
                        startX + pointsRotate[i].ConvertToPoint().X,
                        startY + pointsRotate[i].ConvertToPoint().Y);
                }
            }
            pictureBox1.Invalidate();
        }

        private void drawFigureRotationButton_Click(object sender, EventArgs e)
        {
            if (pointsRotate.Count < 2)
            {
                MessageBox.Show("Добавьте хотя бы 2 точки для образующей", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (int.TryParse(textBoxPartitions.Text, out int count) && count > 0)
            {
                string axis = comboBoxAxis.Text;
                char axisF;
                if (axis == "Ось Oz")
                    axisF = 'z';
                else if (axis == "Ось Oy")
                    axisF = 'y';
                else
                    axisF = 'x';

                curPolyhedron = RotateFigure.createPolyhedronForRotateFigure(pointsRotate, count, axisF);
                Draw();
            }
            else
            {
                MessageBox.Show("Введите корректное количество разбиений", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Метод для построения графика функции
        private void DrawGraphic_Click(object sender, EventArgs e)
        {
            if (!float.TryParse(textBoxX0.Text, out float X0) ||
                !float.TryParse(textBoxX1.Text, out float X1) ||
                !float.TryParse(textBoxY0.Text, out float Y0) ||
                !float.TryParse(textBoxY1.Text, out float Y1) ||
                !int.TryParse(textBoxSplits.Text, out int cnt) || cnt <= 0)
            {
                MessageBox.Show("Введите корректные значения диапазонов и разбиений", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Выбор функции
            Func<float, float, float> f;
            switch (comboBoxFunctions.SelectedIndex)
            {
                case 0:
                    f = (x, y) => (float)(Math.Cos(x * x + y * y) / (x * x + y * y + 1));
                    break;
                case 1:
                    f = (x, y) => (float)(Math.Sin(x + y));
                    break;
                case 2:
                    f = (x, y) => (float)(1 / (1 + x * x) + 1 / (1 + y * y));
                    break;
                case 3:
                    f = (x, y) => (float)(Math.Sin(x * x + y * y));
                    break;
                case 4:
                    f = (x, y) => (float)(Math.Sqrt(50 - x * x - y * y));
                    break;
                default:
                    f = (x, y) => 0;
                    break;
            }

            Graphic(X0, X1, Y0, Y1, cnt, f);
        }

        private void Graphic(float X0, float X1, float Y0, float Y1, int countSplit, Func<float, float, float> f)
        {
            float dx = (X1 - X0) / countSplit;
            float dy = (Y1 - Y0) / countSplit;
            float currentX, currentY = Y0;

            List<Point3D> points = new List<Point3D>();

            // Добавляем точки
            for (int i = 0; i <= countSplit; ++i)
            {
                currentX = X0;
                for (int j = 0; j <= countSplit; ++j)
                {
                    points.Add(new Point3D(currentX, currentY, f(currentX, currentY)));
                    currentX += dx;
                }
                currentY += dy;
            }

            Polyhedron polyhedron = new Polyhedron(points);
            int N = countSplit + 1;

            // Добавляем ребра и грани
            for (int i = 0; i < N; ++i)
            {
                for (int j = 0; j < N; ++j)
                {
                    if (j != N - 1)
                        polyhedron.AddEdge(i * N + j, i * N + j + 1);
                    if (i != N - 1)
                        polyhedron.AddEdge(i * N + j, (i + 1) * N + j);
                    if (j != N - 1 && i != N - 1)
                    {
                        polyhedron.AddFace(new List<int> { i * N + j, i * N + j + 1, (i + 1) * N + j, (i + 1) * N + (j + 1) });
                    }
                }
            }

            Affine.scaleCenter(polyhedron, 40);
            Affine.rotateCenter(polyhedron, 60, 0, 0);

            curPolyhedron = polyhedron;
            pen.Width = 1;
            Draw();
        }

        // Очистка точек для фигуры вращения
        private void clearPointsButton_Click(object sender, EventArgs e)
        {
            pointsRotate.Clear();
            graphics.Clear(Color.White);
            pictureBox1.Invalidate();
        }



    }
}
