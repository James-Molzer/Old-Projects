using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class ChipsTest
    {

        [TestMethod]

        public void Chips_ConstructorTest()
        {
            //Arrange

            string itemName = "Potato Crisps";
            decimal itemPrice = 3.05M;
            int itemsRemaining = 5;

            //Act
            Chips chips = new Chips(itemName, itemPrice, itemsRemaining);

            //Assert
            Assert.AreEqual("Potato Crisps", chips.ItemName);
            Assert.AreEqual(3.05M, chips.ItemPrice);
            Assert.AreEqual(5, chips.ItemsRemaining);

        }

        [TestMethod]

        public void Chips_ConsumptionSound()
        {

            Chips chips = new Chips("Potato Crisps", 1.50M, 5);

            Assert.AreEqual("Crunch, Crunch, Yum!", chips.VendingMessage);

        }
    }
}
