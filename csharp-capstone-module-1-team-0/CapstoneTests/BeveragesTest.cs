using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class BeveragesTests
    {
        [TestMethod]
        public void BeverageTests_ConstructorTest()
        {
            //Arrange

            string itemName = "Cola";
            decimal itemPrice = 1.25M;
            int itemsRemaining = 5;

            //Act
            Beverages beverages = new Beverages(itemName, itemPrice, itemsRemaining);

            //Assert
            Assert.AreEqual(itemName, beverages.ItemName);
            Assert.AreEqual(itemPrice, beverages.ItemPrice);
            Assert.AreEqual(itemsRemaining, beverages.ItemsRemaining);

        }

        [TestMethod]

        public void BeveragesTest_ConsumptionSound()
        {

            Beverages beverages = new Beverages("Cola", 1.25M, 3);

            Assert.AreEqual("Glug, Glug, Yum!", beverages.VendingMessage);
        }
    }
}
