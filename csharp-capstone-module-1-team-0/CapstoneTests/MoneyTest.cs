using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class MoneyTest
    {


        [TestMethod]
        public void AddMoney_Test()
        {
            //Act

            Money addMoney = new Money();

            //Method is Balance += amountInserted.

            //Assert
            Assert.AreEqual(10, addMoney.AddMoney(10));
            Assert.AreEqual(15, addMoney.AddMoney(5));
            Assert.AreEqual(16, addMoney.AddMoney(1));
            Assert.AreEqual(18, addMoney.AddMoney(2));

        }


        [TestMethod]
        public void BalanceTooLow_Test()
        {
            //Method is deduct amount taken by machine from balanace if balance is > $0.00
            // Has to be run separately since this is method is static.
            //Balance starting at $0.

            Assert.AreEqual(0, Money.MachineTookMoney(5));
            Assert.AreEqual(0, Money.MachineTookMoney(10));

        }

        [TestMethod]


        public void MoneyTaken_Test()
        {
            //Method is deduct amount taken by machine from balanace if balance is > $0.00
            // Has to be run separately since this is method is static.
            //Since balance starts at $0 using negative amount taken out.

            Assert.AreEqual(5, Money.MachineTookMoney(-5));
            Assert.AreEqual(15, Money.MachineTookMoney(-10));

        }


        }
    }






