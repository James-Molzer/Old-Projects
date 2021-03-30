using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class GumTests
    {
        [TestMethod]

        public void GumTest_ConstructorTest()
        {
            //Arrange

            string itemName = "U-Chews";
            decimal itemPrice = 0.85M;
            int itemsRemaining = 5;

            //Act
            Gum gum = new Gum(itemName, itemPrice, itemsRemaining);

            //Assert
            Assert.AreEqual(itemName, gum.ItemName);
            Assert.AreEqual(itemPrice, gum.ItemPrice);
            Assert.AreEqual(itemsRemaining, gum.ItemsRemaining);

        }

        [TestMethod]

        public void GumTest_ConsumptionSound()
        {
            Gum gum = new Gum("Cola", 1.25M, 3);

            Assert.AreEqual("Chew, Chew, Yum!", gum.VendingMessage);
        }

    }
}
