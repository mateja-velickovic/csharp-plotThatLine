using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace matvelickov_stats
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            List<string> xData = ReadCSV("date");
            List<string> yData = ReadCSV("close");

            var xValues = xData.Select(date => DateTime.ParseExact(date, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)).ToArray();
            var yValues = yData.Select(value => double.Parse({value}, CultureInfo.InvariantCulture)).ToArray();


            // Autoriser le format de la date sur l'axe X
            graph.Plot.XAxis.DateTimeFormat(true);

            graph.Plot.YLabel("Prix du BTC (fermeture)");
            graph.Plot.XLabel("Date");
            graph.Plot.Title("Bitcoin");

            graph.Plot.AddScatter(xValues.Select(x => x.ToOADate()).ToArray(), yValues);

            graph.Refresh();


        }

        static List<string> ReadCSV(string columnName)
        {
            string filePath = "BTC-DAILY.csv";
            List<string> values = new List<string>();

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.Read();
                csv.ReadHeader();
                var headers = csv.HeaderRecord;

                int columnIndex = Array.IndexOf(headers, columnName);
                if (columnIndex == -1)
                {
                    throw new ArgumentException($"Column '{columnName}' not found in the CSV file.");
                }

                while (csv.Read())
                {
                    var value = csv.GetField(columnIndex);
                    values.Add(value);
                }
            }

            return values;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
        }


        private void btn1_Click(object sender, EventArgs e)
        {

        }

        private void graph_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
