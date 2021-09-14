using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UtilHelper.FileHandler;

namespace UtilHelper.UnitTests.FileHandlerTests
{
    [TestFixture]
    public class TestCsvHelpers
    {
        CsvHelpers CsvHelpersInstance = new CsvHelpers();
        [Test]
        public void GetAutomobileFromCsv()
        {
            IEnumerable<Automobile> AutomobileList = new List<Automobile>()
            {

            };

            Assert.AreEqual(AutomobileList,CsvHelpersInstance.GetAutomobileFromCsv("sample.csv"));
        }
    }
}
