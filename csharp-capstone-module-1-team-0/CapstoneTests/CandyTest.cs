using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
   public class CandyTest
    {

        [TestMethod]

        public void Candy_ConstructorTest()
        {
            //Arrange

            string itemName = "Wonka Bar";
            decimal itemPrice = 1.50M;
            int itemsRemaining = 5;

            //Act
            Candy candy = new Candy(itemName, itemPrice, itemsRemaining);

            //Assert
            Assert.AreEqual(itemName, candy.ItemName);
            Assert.AreEqual(itemPrice, candy.ItemPrice);
            Assert.AreEqual(itemsRemaining, candy.ItemsRemaining);

        }

        [TestMethod]

        public void Candy_ConsumptionSound()
        {
            
            Candy candy = new Candy("Wonka Bar", 1.50M, 5);

            Assert.AreEqual("Munch, Munch, Yum!", candy.VendingMessage);

    }
}
}
