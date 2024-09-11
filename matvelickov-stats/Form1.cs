using CsvHelper;
using CsvHelper.Configuration;
using ScottPlot.Renderable;
using System.Globalization;
using System.Drawing;
using ScottPlot;

namespace matvelickov_stats
{

    public partial class Form1 : Form
    {
        string filePath = " ";
        string files = " ";

        public Form1()
        {
            InitializeComponent();

            this.Load += new EventHandler(listBox1_Load);

            // Autoriser le format de la date sur l'axe X
            graph.Plot.XAxis.DateTimeFormat(true);

            // Mise en forme du graphique
            var main_color = System.Drawing.Color.FromArgb(0x151922);

            graph.Plot.Style(Style.Gray2);

            graph.Plot.YAxis.Label(label: "Prix", color: Color.White);
            graph.Plot.XAxis.Label(label: "Date", color: Color.White);

            graph.Plot.XAxis.TickLabelStyle(color: Color.White);
            graph.Plot.YAxis.TickLabelStyle(color: Color.White);
        }

        /// <summary>
        /// Lecture de fichier CSV
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public List<string> ReadCSV(string columnName)
        {
            List<string> values = new List<string>();

            if (filePath.Length > 3)
            {
                using (var reader = new StreamReader($"./CSV/{filePath}.csv"))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csv.Read();
                    csv.ReadHeader();
                    var headers = csv.HeaderRecord;

                    int columnIndex = Array.IndexOf(headers, columnName);
                    if (columnIndex == -1)
                    {
                        throw new ArgumentException($"La colonne {columnName} n'existe pas.");
                    }

                    while (csv.Read())
                    {
                        var value = csv.GetField(columnIndex);
                        values.Add(value);
                    }
                }
            }

            return values;
        }

        /// <summary>
        /// Affichage des données sur le graphique
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="firstCol"></param>
        /// <param name="secondCol"></param>
        private void DisplayData(string firstCol, string secondCol)
        {
            List<string> xData = ReadCSV(firstCol);
            List<string> yData = ReadCSV(secondCol);

            var xValues = xData.Select(date => DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture)).ToArray();
            var yValues = yData.Select(value => double.Parse(value, CultureInfo.InvariantCulture)).ToArray();

            var a = graph.Plot.AddScatter(xValues.Select(x => x.ToOADate()).ToArray(), yValues);
            a.MarkerSize = 0;
        }

        /// <summary>
        /// Nettoyage du graphique par l'utilisateur
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
        /// Ajout d'une nouvelle donnée sur le graphique
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn1_Click(object sender, EventArgs e)
        {
            filePath = listBox1.SelectedItem.ToString();
            files += $" {listBox1.SelectedItem.ToString()} |";

            if (filePath.Length > 2)
            {
                graph.Plot.Title(files, color: Color.White);
                DisplayData(filePath, "close", "date");
                graph.Refresh();
            }
            graph.Refresh();
        }

        /// <summary>
        /// Liste des tous les fichiers dans le dossier CSV
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
                    listBox1.Items.Add(Path.GetFileNameWithoutExtension(file));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
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

    }
}
