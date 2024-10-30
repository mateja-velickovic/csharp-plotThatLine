using Microsoft.VisualStudio.TestTools.UnitTesting;
using matvelickov_stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;

namespace matvelickov_stats.Tests
{
    [TestClass()]
    public class Form1Tests
    {

        [TestMethod()]
        public void DisplayDataTest()
        {
            // arrange 
            string a = "Albert Einstein";

            // act
            string result = a.ToUpper();

            // assert
            var expected = "ALBERT EINSTEIN";

            Assert.AreEqual(expected, result);
        }

    }



}