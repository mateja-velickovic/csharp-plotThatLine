using Microsoft.VisualStudio.TestTools.UnitTesting;
using matvelickov_stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace matvelickov_stats.Tests
{
    [TestClass]
    public class Form1Tests
    {
        [TestMethod()]
        public void ReadCSV_ValidFile()
        {
            // Arrange
            var form = new Form1();
            form.filePath = "bitcoin";  // Utiliser un fichier CSV de test

            // Act
            List<Data> result = form.ReadCSV();

            // Assert
            Assert.IsNotNull(result, "Le résultat ne doit pas être nul.");
            Assert.IsTrue(result.Count > 0, "Le fichier CSV doit contenir des lignes de données.");
            Assert.IsNotNull(result[0].Date, "La date de la première ligne ne doit pas être nulle.");
            Assert.IsNotNull(result[0].Close, "La valeur Close de la première ligne ne doit pas être nulle.");
        }

        [TestMethod()]
        public void ReadCSV_EmptyFile()
        {
            // Arrange
            var form = new Form1();
            form.filePath = "fichier_inexistant";  // Fichier qui n'existe pas

            // Act
            List<Data> result = form.ReadCSV();

            // Assert
            Assert.IsNull(result, "Le résultat doit être nul si le fichier CSV n'existe pas.");
        }

    }

}