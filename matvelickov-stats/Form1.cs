////////////////////////////////////////////////////////////
///                                                      ///
///     ETML, Vennes                                     ///
///     Author : Velickovic Mateja (matvelickov)         ///
///     Project : P_FUN Plot That Line                   ///
///     Date : 04.09.2024                                ///
///                                                      ///
////////////////////////////////////////////////////////////

using System;
using System.Drawing.Design;
using System.Globalization;
using ScottPlot;
using ScottPlot.Plottable;

namespace matvelickov_stats
{

    public partial class Form1 : Form
    {
        string filePath = " ";
        List<string> selectedFiles = new List<string>();

        public Form1()
        {
            // Initialisation
            InitializeComponent();
            this.Load += new EventHandler(listBox1_Load);

            // Mise en forme du graphique
            graph.Plot.XAxis.DateTimeFormat(true);

            graph.Plot.Style(Style.Gray2);

            graph.Plot.YAxis.TickLabelFormat(a => $"${a}");

            graph.Plot.YAxis.Label(label: "Prix", color: Color.GhostWhite);
            graph.Plot.XAxis.Label(label: "Date", color: Color.GhostWhite);
            graph.Plot.XAxis.TickLabelStyle(color: Color.GhostWhite);
            graph.Plot.YAxis.TickLabelStyle(color: Color.GhostWhite);

            // Activation of legends
            graph.Plot.Legend(enable: true);

            graph.Plot.YAxis.SetBoundary(-.1);

            graph.Refresh();
        }

        /// <summary>
        /// Insert columns 0 and 4 of the CSV file into the data variable
        /// </summary>
        /// <returns></returns>
        public List<Data> ReadCSV()
        {
            try
            {
                // Lecture du fichier CSV
                var data = File.ReadAllLines($"../../../..//CSV/{filePath}.csv")
                               .Skip(1)
                               .Select(line => line.Split(','))
                               .Select(columns => new Data
                               {
                                   Date = columns[0],
                                   Close = columns[4]
                               })
                               .ToList();

                return data;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
                return null;
            }
        }

        /// <summary>
        /// Displays data graphically.
        /// </summary>
        public void DisplayData()
        {
            List<Data> values = ReadCSV();
            if (values == null)
            {
                MessageBox.Show("Pas de données à afficher.");
                return;
            }
            List<string> xData = values.Select(entry => entry.Date).ToList();
            List<string> yData = values.Select(entry => entry.Close).ToList();

            try
            {
                var xValues = xData.Select(date => DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture)).ToArray();
                var yValues = yData.Select(value => double.Parse(value, CultureInfo.InvariantCulture)).ToArray();
                var dateOADates = xValues.Select(x => x.ToOADate()).ToArray();

                var plot = graph.Plot.AddScatter(xValues.Select(x => x.ToOADate()).ToArray(), yValues, label: $"{filePath}");
                plot.MarkerSize = 0; ;

            }
            catch (FormatException fe)
            {
                Console.WriteLine($"Erreur lors de l'affichage des données : {fe.Message}");
            }
        }

        /// <summary>
        /// User cleaning the graph
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            // Nettoyage du graphique
            graph.Plot.Clear();

            // Nettoyage de la liste de string
            selectedFiles.Clear();

            // Rafraîchissement du graphique
            graph.Refresh();

            RefreshListBox();
        }

        /// <summary>
        /// Adding new data to the graph
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                filePath = listBox1.SelectedItem.ToString();

                if (!selectedFiles.Contains(filePath))
                {
                    // Adding the value to the selectedFiles list
                    selectedFiles.Add(filePath);

                    DisplayData();

                    // Recentering the chart
                    graph.Plot.AxisAuto();

                    graph.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une courbe à ajouter.");
            }

            RefreshListBox();
        }

        /// <summary>
        /// Retirer une courbe sur le graphique
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click_1(object sender, EventArgs e)
        {

            if (listBox2.SelectedItem != null)
            {
                // Suppression de la courbe séléctionnée
                var plotToRemove = listBox2.SelectedItem;

                graph.Plot.Remove((ScottPlot.Plottable.IPlottable)plotToRemove);
                graph.Refresh();
                selectedFiles.Remove(listBox2.SelectedItem.ToString());
                RefreshListBox();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une courbe à supprimer.");
            }
        }

        /// <summary>
        /// List of all files in CSV folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_Load(object sender, EventArgs e)
        {
            // Path of the CSV directory
            string directoryPath = "../../../../CSV/";

            try
            {
                string[] files = Directory.GetFiles(directoryPath);

                listBox1.Items.AddRange(
                files.Where(file => Path.GetExtension(file) == ".csv")
                     .Select(file => Path.GetFileNameWithoutExtension(file))
                     .ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error : {ex.Message}");
            }
        }

        /// <summary>
        /// Refreshing data from listbox2 (current curves)
        /// </summary>
        private void RefreshListBox()
        {
            listBox2.Items.Clear();
            /*
            var getLabelName = graph.Plot.GetPlottables()
                .SelectMany(plottable => plottable.GetLegendItems()) 
                .Select(legendItem => legendItem.label);      */      

            listBox2.Items.AddRange(graph.Plot.GetPlottables().ToArray());
        }

        /// <summary>
        /// Button that change the period
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            ChangePeriod();
        }

        /// <summary>
        /// Change the period on click on the button
        /// </summary>
        void ChangePeriod()
        {
            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;

            if (startDate < endDate)
            {
                graph.Plot.SetAxisLimitsX(startDate.ToOADate(), endDate.ToOADate());
                graph.Refresh();
            }

        }



















        private void listBox2_Load(object sender, EventArgs e)
        {
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void graph_Load_1(object sender, EventArgs e)
        {
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void button1_Load(object sender, EventArgs e)
        {
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
