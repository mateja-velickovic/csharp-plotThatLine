////////////////////////////////////////////////////////////
///                                                      ///
///     ETML, Vennes                                     ///
///     Auteur : Velickovic Mateja (matvelickov)         ///
///     Projet : P_FUN Plot That Line                    ///
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

        public Form1()
        {
            InitializeComponent();

            this.Load += new EventHandler(listBox1_Load);

            // Autoriser le format de la date sur l'axe X
            graph.Plot.XAxis.DateTimeFormat(true);

            // Mise en forme du graphique
            var main_color = System.Drawing.Color.FromArgb(0x151922);

            graph.Plot.Style(Style.Gray2);

            graph.Plot.YAxis.TickLabelFormat(a => $"${a}");

            graph.Plot.YAxis.Label(label: "Prix", color: Color.White);
            graph.Plot.XAxis.Label(label: "Date", color: Color.White);

            graph.Plot.XAxis.TickLabelStyle(color: Color.White);
            graph.Plot.YAxis.TickLabelStyle(color: Color.White);

        }


        /// <summary>
        /// Lit les données CSV et les retourne sous forme de collection d'objets avec Date et Close.
        /// </summary>
        /// <returns>Liste dynamique des données CSV</returns>
        public dynamic ReadCSV()
        {
            try
            {
                var data = File.ReadAllLines($"./CSV/{filePath}.csv")
                               .Skip(1)
                               .Select(line => line.Split(',')) 
                               .Where(columns => columns.Length > 5 && 
                                                 !string.IsNullOrWhiteSpace(columns[0]) && 
                                                 !string.IsNullOrWhiteSpace(columns[5])) 
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
                return ex;
            }
        }

        /// <summary>
        /// Affiche les données sous forme de graphique.
        /// </summary>
        /// <param name="firstCol">Nom de la première colonne (Date)</param>
        /// <param name="secondCol">Nom de la deuxième colonne (Close)</param>
        public void DisplayData()
        {
            var values = ReadCSV();
            if (values == null)
            {
                Console.WriteLine("Aucune donnée à afficher.");
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
                Console.WriteLine($"Erreur lors du parsing des données : {fe.Message}");
            }
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
            files += $" {listBox1.SelectedItem} |";

            graph.Plot.Title(files, color: Color.White);
            DisplayData();
            graph.Refresh();

            graph.Plot.Legend(enable: true);

            graph.Plot.AxisAuto();
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
                    if(Path.GetExtension(file) == ".csv")
                    {
                        listBox1.Items.Add(Path.GetFileNameWithoutExtension(file));
                    }
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
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

    }
}
