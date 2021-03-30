using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Capstone.Models;
using Capstone.DAL;

namespace Capstone.Tests
{
    //May need test initalization here.
    [TestClass]
    public class CampgroundSqlDAOTests
    {
        private string connectionString = @"Server=.\\SQLExpress;Database=npcampground;Trusted_Connection=True;";
        [TestMethod]
        public void getAllCampgroundsTest()
        {
            CampgroundSqlDAO campgroundSqlDAO = new CampgroundSqlDAO(connectionString);
            IList<Campground> campgrounds = campgroundSqlDAO.GetCampgroundsByPark(0);
            Assert.IsTrue(campgrounds.Count > 0);
        }
    }
}
