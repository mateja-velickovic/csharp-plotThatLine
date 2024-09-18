////////////////////////////////////////////////////////////
///                                                      ///
///     ETML, Vennes                                     ///
///     Author : Velickovic Mateja (matvelickov)         ///
///     Project : P_FUN Plot That Line                   ///
///     Date : 04.09.2024                                ///
///                                                      ///
////////////////////////////////////////////////////////////

using System.Globalization;
using ScottPlot;

namespace matvelickov_stats
{

    public partial class Form1 : Form
    {
        string filePath = " ";
        string files = " ";
        List<string> selectedFiles = new List<string>();

        public Form1()
        {
            InitializeComponent();

            this.Load += new EventHandler(listBox1_Load);

            graph.Plot.XAxis.DateTimeFormat(true);

            var main_color = System.Drawing.Color.FromArgb(0x151922);

            graph.Plot.Style(Style.Gray2);

            graph.Plot.YAxis.TickLabelFormat(a => $"${a}");

            graph.Plot.YAxis.Label(label: "Prix", color: Color.White);
            graph.Plot.XAxis.Label(label: "Date", color: Color.White);
            graph.Plot.XAxis.TickLabelStyle(color: Color.White);
            graph.Plot.YAxis.TickLabelStyle(color: Color.White);

        }


        /// <summary>
        /// Insert columns 0 and 4 of the CSV file into the data variable
        /// </summary>
        /// <returns>Liste dynamique des données CSV</returns>
        public dynamic ReadCSV()
        {
            try
            {
                var data = File.ReadAllLines($"./CSV/{filePath}.csv")
                               .Skip(1)
                               .Select(line => line.Split(','))
                               .Select(columns => new
                               {
                                   Date = columns[0],
                                   Close = columns[4]
                               })
                               .ToList();

                return data;
            }
            catch (Exception ex)
            {
                return MessageBox.Show($"Error: {ex}");
            }
        }

        /// <summary>
        /// Displays data graphically.
        /// </summary>
        public void DisplayData()
        {
            var values = ReadCSV();
            if (values == null)
            {
                MessageBox.Show("No data to display.");
                return;
            }

            List<string> xData = new List<string>();
            List<string> yData = new List<string>();

            foreach (var entry in values)
            {
                xData.Add(entry.Date);
                yData.Add(entry.Close);
            }

            try
            {
                var xValues = xData.Select(date => DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture)).ToArray();
                var yValues = yData.Select(value => double.Parse(value, CultureInfo.InvariantCulture)).ToArray();
                var dateOADates = xValues.Select(x => x.ToOADate()).ToArray();

                var plot = graph.Plot.AddScatter(xValues.Select(x => x.ToOADate()).ToArray(), yValues, label: $"{filePath}");

                plot.MarkerSize = 0;
            }
            catch (FormatException fe)
            {
                Console.WriteLine($"Error parsing data : {fe.Message}");
            }
        }

        /// <summary>
        /// User cleaning the graph
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            graph.Plot.Clear();
            files = "";
            graph.Plot.Title(files, color: Color.White);
            graph.Refresh();
        }

        /// <summary>
        /// Adding new data to the graph
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn1_Click(object sender, EventArgs e)
        {
            filePath = listBox1.SelectedItem.ToString();

            if (!selectedFiles.Contains(filePath))
            {
                selectedFiles.Add(filePath);
                files += $"{filePath}, ";

                graph.Plot.Title(files, color: Color.White);
                DisplayData();
                graph.Refresh();

                graph.Plot.Legend(enable: true);

                graph.Plot.AxisAuto();
                graph.Refresh();
            }
        }

        /// <summary>
        /// List of all files in CSV folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_Load(object sender, EventArgs e)
        {
            string directoryPath = "./CSV/";

            try
            {
                string[] files = Directory.GetFiles(directoryPath);

                foreach (string file in files)
                {
                    if (Path.GetExtension(file) == ".csv")
                    {
                        listBox1.Items.Add(Path.GetFileNameWithoutExtension(file));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error : {ex.Message}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {}
        private void graph_Load(object sender, EventArgs e)
        {
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void button1_Load(object sender, EventArgs e)
        {
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }

    }
}
