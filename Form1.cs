using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompGraphicsLab06
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private Pen pen;
        private Projection projection;

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

            // Объявляем centerX и centerY один раз в начале метода
            var centerX = pictureBox1.Width / 2;
            var centerY = pictureBox1.Height / 2;

            // Если многогранник не задан, просто рисуем оси и выходим
            if (curPolyhedron == null)
            {
                DrawAxes(centerX, centerY); // Используем объявленные выше переменные
                pictureBox1.Invalidate();
                return;
            }

            // 1. Проецируем фигуру
            pen = new Pen(Color.Black, 2);
            List<Edge> edges = projection.Project(curPolyhedron, projBox.SelectedIndex);

            // 2. Расчет смещения для центрирования
            // УДАЛЕНЫ ПОВТОРНЫЕ ОБЪЯВЛЕНИЯ var centerX = ... и var centerY = ...

            // Расчет центра фигуры (для смещения)
            var figureLeftX = edges.Min(e => Math.Min(e.From.X, e.To.X));
            var figureLeftY = edges.Min(e => Math.Min(e.From.Y, e.To.Y));
            var figureRightX = edges.Max(e => Math.Max(e.From.X, e.To.X));
            var figureRightY = edges.Max(e => Math.Max(e.From.Y, e.To.Y));

            // Если фигура невидима (например, все точки схлопнулись), используем 0
            float figureCenterX = (figureRightX - figureLeftX) / 2;
            float figureCenterY = (figureRightY - figureLeftY) / 2;

            // Общее смещение, которое применяем и к фигуре, и к осям
            float offsetX = centerX - figureCenterX;
            float offsetY = centerY - figureCenterY;


            // 3. Рисуем Оси
            DrawAxes(offsetX, offsetY);


            // 4. Рисуем фигуру
            foreach (Edge line in edges)
            {
                var p1 = (line.From).ConvertToPoint();
                var p2 = (line.To).ConvertToPoint();

                // Применяем рассчитанное смещение
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
                //"Время пострелять..."(с)
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
    }
}
