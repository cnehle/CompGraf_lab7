namespace CompGraphicsLab06
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.projBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rotateOX = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.rotateOY = new System.Windows.Forms.RadioButton();
            this.rotateOZ = new System.Windows.Forms.RadioButton();
            this.rotateAngle = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.rotateBtn = new System.Windows.Forms.Button();
            this.rZ1 = new System.Windows.Forms.TextBox();
            this.rY1 = new System.Windows.Forms.TextBox();
            this.rX1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.rZ2 = new System.Windows.Forms.TextBox();
            this.rY2 = new System.Windows.Forms.TextBox();
            this.rX2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.rotateOwn = new System.Windows.Forms.RadioButton();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotateAngle)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(182, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(795, 765);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 11);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 37);
            this.button1.TabIndex = 1;
            this.button1.Text = "Куб (гексаэдр)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 53);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(157, 32);
            this.button2.TabIndex = 2;
            this.button2.Text = "Тетраэдр";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(10, 179);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(156, 32);
            this.button3.TabIndex = 3;
            this.button3.Text = "Очистить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(10, 91);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(156, 32);
            this.button4.TabIndex = 4;
            this.button4.Text = "Октаэдр";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(22, 290);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(74, 290);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(129, 290);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Z";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 309);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(47, 20);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "0";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(59, 309);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(47, 20);
            this.textBox2.TabIndex = 10;
            this.textBox2.Text = "0";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(110, 309);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(47, 20);
            this.textBox3.TabIndex = 11;
            this.textBox3.Text = "0";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(10, 460);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(154, 41);
            this.button5.TabIndex = 12;
            this.button5.Text = "Применить преобразования";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton1.Location = new System.Drawing.Point(10, 219);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(142, 21);
            this.radioButton1.TabIndex = 13;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Смещение по оси";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioButton1_MouseClick);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton2.Location = new System.Drawing.Point(10, 244);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(123, 21);
            this.radioButton2.TabIndex = 14;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Масштаб (в %)";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioButton2_MouseClick);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton3.Location = new System.Drawing.Point(10, 268);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(164, 21);
            this.radioButton3.TabIndex = 15;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Поворот (в градусах)";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioButton3_MouseClick);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton4.Location = new System.Drawing.Point(9, 332);
            this.radioButton4.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(101, 21);
            this.radioButton4.TabIndex = 16;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Отражение";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioButton4_MouseClick);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Плоскость Oxy",
            "Плоскость Oxz",
            "Плоскость Oyz"});
            this.comboBox1.Location = new System.Drawing.Point(9, 357);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(147, 21);
            this.comboBox1.TabIndex = 17;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton5.Location = new System.Drawing.Point(9, 382);
            this.radioButton5.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(149, 21);
            this.radioButton5.TabIndex = 18;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Масштабирование";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioButton5_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 404);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Относительно центра (в %)";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(9, 420);
            this.textBox4.Margin = new System.Windows.Forms.Padding(2);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(47, 20);
            this.textBox4.TabIndex = 20;
            this.textBox4.Text = "100";
            // 
            // projBox
            // 
            this.projBox.FormattingEnabled = true;
            this.projBox.Items.AddRange(new object[] {
            "Перспективная",
            "Изометрическая"});
            this.projBox.Location = new System.Drawing.Point(10, 523);
            this.projBox.Name = "projBox";
            this.projBox.Size = new System.Drawing.Size(154, 21);
            this.projBox.TabIndex = 21;
            this.projBox.SelectedIndexChanged += new System.EventHandler(this.projBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 507);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Проекция";
            // 
            // rotateOX
            // 
            this.rotateOX.AutoSize = true;
            this.rotateOX.Location = new System.Drawing.Point(13, 570);
            this.rotateOX.Name = "rotateOX";
            this.rotateOX.Size = new System.Drawing.Size(40, 17);
            this.rotateOX.TabIndex = 23;
            this.rotateOX.TabStop = true;
            this.rotateOX.Text = "OX";
            this.rotateOX.UseVisualStyleBackColor = true;
            this.rotateOX.Click += new System.EventHandler(this.rotateOX_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 551);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Вращение вокруг прямой";
            // 
            // rotateOY
            // 
            this.rotateOY.AutoSize = true;
            this.rotateOY.Location = new System.Drawing.Point(12, 593);
            this.rotateOY.Name = "rotateOY";
            this.rotateOY.Size = new System.Drawing.Size(40, 17);
            this.rotateOY.TabIndex = 25;
            this.rotateOY.TabStop = true;
            this.rotateOY.Text = "OY";
            this.rotateOY.UseVisualStyleBackColor = true;
            this.rotateOY.Click += new System.EventHandler(this.rotateOY_Click);
            // 
            // rotateOZ
            // 
            this.rotateOZ.AutoSize = true;
            this.rotateOZ.Location = new System.Drawing.Point(13, 616);
            this.rotateOZ.Name = "rotateOZ";
            this.rotateOZ.Size = new System.Drawing.Size(40, 17);
            this.rotateOZ.TabIndex = 26;
            this.rotateOZ.TabStop = true;
            this.rotateOZ.Text = "OZ";
            this.rotateOZ.UseVisualStyleBackColor = true;
            this.rotateOZ.Click += new System.EventHandler(this.rotateOZ_Click);
            // 
            // rotateAngle
            // 
            this.rotateAngle.Location = new System.Drawing.Point(72, 593);
            this.rotateAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.rotateAngle.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.rotateAngle.Name = "rotateAngle";
            this.rotateAngle.Size = new System.Drawing.Size(92, 20);
            this.rotateAngle.TabIndex = 28;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(72, 574);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Угол (deg)";
            // 
            // rotateBtn
            // 
            this.rotateBtn.Location = new System.Drawing.Point(6, 752);
            this.rotateBtn.Name = "rotateBtn";
            this.rotateBtn.Size = new System.Drawing.Size(154, 23);
            this.rotateBtn.TabIndex = 30;
            this.rotateBtn.Text = "Вращать";
            this.rotateBtn.UseVisualStyleBackColor = true;
            this.rotateBtn.Click += new System.EventHandler(this.rotateBtn_Click);
            // 
            // rZ1
            // 
            this.rZ1.Location = new System.Drawing.Point(113, 680);
            this.rZ1.Margin = new System.Windows.Forms.Padding(2);
            this.rZ1.Name = "rZ1";
            this.rZ1.Size = new System.Drawing.Size(47, 20);
            this.rZ1.TabIndex = 36;
            this.rZ1.Text = "0";
            // 
            // rY1
            // 
            this.rY1.Location = new System.Drawing.Point(62, 680);
            this.rY1.Margin = new System.Windows.Forms.Padding(2);
            this.rY1.Name = "rY1";
            this.rY1.Size = new System.Drawing.Size(47, 20);
            this.rY1.TabIndex = 35;
            this.rY1.Text = "0";
            // 
            // rX1
            // 
            this.rX1.Location = new System.Drawing.Point(12, 680);
            this.rX1.Margin = new System.Windows.Forms.Padding(2);
            this.rX1.Name = "rX1";
            this.rX1.Size = new System.Drawing.Size(47, 20);
            this.rX1.TabIndex = 34;
            this.rX1.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(132, 661);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 17);
            this.label8.TabIndex = 33;
            this.label8.Text = "Z1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(77, 661);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 17);
            this.label9.TabIndex = 32;
            this.label9.Text = "Y1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(25, 661);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 17);
            this.label10.TabIndex = 31;
            this.label10.Text = "X1";
            // 
            // rZ2
            // 
            this.rZ2.Location = new System.Drawing.Point(113, 727);
            this.rZ2.Margin = new System.Windows.Forms.Padding(2);
            this.rZ2.Name = "rZ2";
            this.rZ2.Size = new System.Drawing.Size(47, 20);
            this.rZ2.TabIndex = 42;
            this.rZ2.Text = "0";
            // 
            // rY2
            // 
            this.rY2.Location = new System.Drawing.Point(62, 727);
            this.rY2.Margin = new System.Windows.Forms.Padding(2);
            this.rY2.Name = "rY2";
            this.rY2.Size = new System.Drawing.Size(47, 20);
            this.rY2.TabIndex = 41;
            this.rY2.Text = "0";
            // 
            // rX2
            // 
            this.rX2.Location = new System.Drawing.Point(12, 727);
            this.rX2.Margin = new System.Windows.Forms.Padding(2);
            this.rX2.Name = "rX2";
            this.rX2.Size = new System.Drawing.Size(47, 20);
            this.rX2.TabIndex = 40;
            this.rX2.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(132, 708);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 17);
            this.label11.TabIndex = 39;
            this.label11.Text = "Z2";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(77, 708);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(25, 17);
            this.label12.TabIndex = 38;
            this.label12.Text = "Y2";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(25, 708);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(25, 17);
            this.label13.TabIndex = 37;
            this.label13.Text = "X2";
            // 
            // rotateOwn
            // 
            this.rotateOwn.AutoSize = true;
            this.rotateOwn.Location = new System.Drawing.Point(13, 639);
            this.rotateOwn.Name = "rotateOwn";
            this.rotateOwn.Size = new System.Drawing.Size(50, 17);
            this.rotateOwn.TabIndex = 43;
            this.rotateOwn.TabStop = true;
            this.rotateOwn.Text = "Своя";
            this.rotateOwn.UseVisualStyleBackColor = true;
            this.rotateOwn.Click += new System.EventHandler(this.rotateOwn_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(10, 127);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(156, 20);
            this.button6.TabIndex = 44;
            this.button6.Text = "Икосаэдр";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.createIcosahedron_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(10, 151);
            this.button7.Margin = new System.Windows.Forms.Padding(2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(156, 20);
            this.button7.TabIndex = 45;
            this.button7.Text = "Додекаэдр";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.createDodecahedron_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 788);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.rotateOwn);
            this.Controls.Add(this.rZ2);
            this.Controls.Add(this.rY2);
            this.Controls.Add(this.rX2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.rZ1);
            this.Controls.Add(this.rY1);
            this.Controls.Add(this.rX1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.rotateBtn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.rotateAngle);
            this.Controls.Add(this.rotateOZ);
            this.Controls.Add(this.rotateOY);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rotateOX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.projBox);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButton5);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Лабораторная работа №6. Аффинные преобразования в пространстве. Проецирование";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotateAngle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.ComboBox projBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rotateOX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rotateOY;
        private System.Windows.Forms.RadioButton rotateOZ;
        private System.Windows.Forms.NumericUpDown rotateAngle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button rotateBtn;
        private System.Windows.Forms.TextBox rZ1;
        private System.Windows.Forms.TextBox rY1;
        private System.Windows.Forms.TextBox rX1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox rZ2;
        private System.Windows.Forms.TextBox rY2;
        private System.Windows.Forms.TextBox rX2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RadioButton rotateOwn;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
    }
}

