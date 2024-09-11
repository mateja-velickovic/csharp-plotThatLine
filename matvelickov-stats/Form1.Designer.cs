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
            btn1 = new Button();
            graph = new ScottPlot.FormsPlot();
            dateTimePicker1 = new DateTimePicker();
            SuspendLayout();
            // 
            // btn1
            // 
            btn1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn1.Location = new Point(713, 511);
            btn1.Name = "btn1";
            btn1.Size = new Size(75, 23);
            btn1.TabIndex = 0;
            btn1.Text = "button1";
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += btn1_Click;
            // 
            // graph
            // 
            graph.Location = new Point(14, 52);
            graph.Margin = new Padding(4, 3, 4, 3);
            graph.Name = "graph";
            graph.Size = new Size(774, 439);
            graph.TabIndex = 1;
            graph.Load += graph_Load;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(567, 27);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 546);
            Controls.Add(dateTimePicker1);
            Controls.Add(graph);
            Controls.Add(btn1);
            Name = "Form1";
            Text = "P_FUN | Plot That Line";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btn1;
        private ScottPlot.FormsPlot graph;
        private DateTimePicker dateTimePicker1;
    }
}
