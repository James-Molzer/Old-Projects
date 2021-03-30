using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;
using Capstone;

namespace CapstoneTests
{
    [TestClass]
    public class ImportingCSV_Test
    {
        [TestMethod]

        public void ImportDoesContain_Test()
        {
            // Arrange
            ImportingCSV importingCSV = new ImportingCSV();

            //Act
            Dictionary<string, VendingItem> result = importingCSV.ImportingVendingItems();

            //Assert
            Assert.AreEqual(16, result.Count);
            Assert.AreEqual(true, result.ContainsKey("D3"));
            Assert.AreEqual("Triplemint", result["D4"].ItemName);
            Assert.AreEqual(3.05M, result["A1"].ItemPrice);
            Assert.AreEqual(5, result["B3"].ItemsRemaining);


        }
        [TestMethod]

        public void ImportDoesNotContain_Test()
        {
            // Arrange
            ImportingCSV importingCSV = new ImportingCSV();

            //Act
            Dictionary<string, VendingItem> result = importingCSV.ImportingVendingItems();

            //Assert
            Assert.AreEqual(false, result.ContainsKey("D5"));
            Assert.AreEqual(false, result.ContainsKey("F1"));

        }
    }
}
