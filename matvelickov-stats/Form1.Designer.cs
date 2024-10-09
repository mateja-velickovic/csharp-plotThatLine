namespace matvelickov_stats
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btn1 = new Button();
            button1 = new Button();
            listBox1 = new ListBox();
            dateTimePicker1 = new DateTimePicker();
            graph = new ScottPlot.FormsPlot();
            listBox2 = new ListBox();
            button2 = new Button();
            dateTimePicker2 = new DateTimePicker();
            button3 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btn1
            // 
            btn1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btn1.BackColor = Color.Green;
            btn1.FlatStyle = FlatStyle.Popup;
            btn1.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            btn1.ForeColor = SystemColors.Control;
            btn1.Location = new Point(38, 282);
            btn1.MaximumSize = new Size(141, 28);
            btn1.MinimumSize = new Size(141, 28);
            btn1.Name = "btn1";
            btn1.Size = new Size(141, 28);
            btn1.TabIndex = 0;
            btn1.Text = "AJOUTER";
            btn1.UseVisualStyleBackColor = false;
            btn1.Click += btn1_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.BackColor = Color.Firebrick;
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Location = new Point(38, 520);
            button1.Margin = new Padding(0);
            button1.MaximumSize = new Size(288, 28);
            button1.MinimumSize = new Size(288, 28);
            button1.Name = "button1";
            button1.Size = new Size(288, 28);
            button1.TabIndex = 3;
            button1.Text = "NETTOYER LE GRAPHIQUE";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // listBox1
            // 
            listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBox1.BorderStyle = BorderStyle.FixedSingle;
            listBox1.Font = new Font("Bahnschrift", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 14;
            listBox1.Location = new Point(38, 12);
            listBox1.MaximumSize = new Size(141, 268);
            listBox1.MinimumSize = new Size(141, 268);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(141, 268);
            listBox1.TabIndex = 4;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            dateTimePicker1.Location = new Point(750, 496);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 5;
            dateTimePicker1.Value = new DateTime(2024, 1, 1, 0, 0, 0, 0);
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // graph
            // 
            graph.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            graph.AutoSize = true;
            graph.BackColor = SystemColors.Control;
            graph.ForeColor = Color.White;
            graph.Location = new Point(186, 12);
            graph.Margin = new Padding(4, 3, 4, 3);
            graph.Name = "graph";
            graph.Size = new Size(787, 437);
            graph.TabIndex = 7;
            graph.Load += graph_Load_1;
            // 
            // listBox2
            // 
            listBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Items.AddRange(new object[] { "Liste des courbes affichées..." });
            listBox2.Location = new Point(990, 12);
            listBox2.MaximumSize = new Size(167, 274);
            listBox2.MinimumSize = new Size(167, 274);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(167, 274);
            listBox2.TabIndex = 8;
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            button2.BackColor = Color.DarkOrange;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            button2.ForeColor = SystemColors.Control;
            button2.Location = new Point(990, 287);
            button2.MaximumSize = new Size(167, 28);
            button2.MinimumSize = new Size(167, 28);
            button2.Name = "button2";
            button2.Size = new Size(167, 28);
            button2.TabIndex = 9;
            button2.Text = "RETIRER";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            dateTimePicker2.Location = new Point(957, 496);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(200, 23);
            dateTimePicker2.TabIndex = 10;
            dateTimePicker2.Value = new DateTime(2024, 12, 31, 0, 0, 0, 0);
            dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button3.BackColor = Color.Green;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            button3.ForeColor = SystemColors.Control;
            button3.Location = new Point(990, 525);
            button3.Name = "button3";
            button3.Size = new Size(167, 23);
            button3.TabIndex = 11;
            button3.Text = "APPLIQUER";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Snow;
            label1.Location = new Point(948, 468);
            label1.Name = "label1";
            label1.Size = new Size(209, 25);
            label1.TabIndex = 12;
            label1.Text = "Sélectionnez la période";
            label1.Click += label1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(19, 21, 25);
            ClientSize = new Size(1190, 572);
            Controls.Add(btn1);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(dateTimePicker2);
            Controls.Add(button2);
            Controls.Add(listBox2);
            Controls.Add(graph);
            Controls.Add(dateTimePicker1);
            Controls.Add(listBox1);
            Controls.Add(button1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1192, 611);
            Name = "Form1";
            Text = "Plot That Line";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn1;
        private Button button1;
        private ListBox listBox1;
        private DateTimePicker dateTimePicker1;
        private ScottPlot.FormsPlot graph;
        private ListBox listBox2;
        private Button button2;
        private DateTimePicker dateTimePicker2;
        private Button button3;
        private Label label1;
    }
}
