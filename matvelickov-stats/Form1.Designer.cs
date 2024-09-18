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
            graph = new ScottPlot.FormsPlot();
            button1 = new Button();
            listBox1 = new ListBox();
            dateTimePicker1 = new DateTimePicker();
            SuspendLayout();
            // 
            // btn1
            // 
            btn1.Anchor = AnchorStyles.Bottom;
            btn1.BackColor = Color.Green;
            btn1.FlatStyle = FlatStyle.Popup;
            btn1.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            btn1.ForeColor = SystemColors.Control;
            btn1.Location = new Point(352, 532);
            btn1.Name = "btn1";
            btn1.Size = new Size(100, 28);
            btn1.TabIndex = 0;
            btn1.Text = "ADD";
            btn1.UseVisualStyleBackColor = false;
            btn1.Click += btn1_Click;
            // 
            // graph
            // 
            graph.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            graph.AutoSize = true;
            graph.BackColor = Color.FromArgb(21, 25, 34);
            graph.ForeColor = Color.White;
            graph.Location = new Point(175, 12);
            graph.Margin = new Padding(4, 3, 4, 3);
            graph.Name = "graph";
            graph.Size = new Size(776, 502);
            graph.TabIndex = 1;
            graph.Load += graph_Load;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom;
            button1.BackColor = Color.Firebrick;
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Location = new Point(704, 535);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(102, 28);
            button1.TabIndex = 3;
            button1.Text = "CLEAN";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // listBox1
            // 
            listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBox1.BorderStyle = BorderStyle.FixedSingle;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(37, 33);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(141, 437);
            listBox1.TabIndex = 4;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Anchor = AnchorStyles.Bottom;
            dateTimePicker1.Location = new Point(479, 536);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 5;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(21, 25, 34);
            ClientSize = new Size(964, 572);
            Controls.Add(dateTimePicker1);
            Controls.Add(listBox1);
            Controls.Add(button1);
            Controls.Add(graph);
            Controls.Add(btn1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Plot That Line";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn1;
        private ScottPlot.FormsPlot graph;
        private Button button1;
        private ListBox listBox1;
        private DateTimePicker dateTimePicker1;
    }
}
