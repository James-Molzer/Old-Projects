using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    public class CampgroundSqlDAO : ICampgroundDAO
    {
        private string connectionString;

        public CampgroundSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public IList<Campground> GetCampgroundsByPark(int parkID)
        {
            IList<Campground> campgrounds = new List<Campground>();
            try
            {
                // Open connection 
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand();

                    //Creating SqlCommand Object
                    string sqlStatement = "SELECT * FROM campground WHERE park_id=@parkID";
                    sqlCommand.Parameters.AddWithValue("@parkID", parkID);
                    sqlCommand.CommandText = sqlStatement;
                    sqlCommand.Connection = connection;

                    //Start Reader
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        Campground campground = new Campground();
                        campground.Id = Convert.ToInt32(reader["campground_id"]);
                        campground.ParkId = Convert.ToInt32(reader["park_id"]);
                        campground.Name = Convert.ToString(reader["name"]);
                        campground.OpenFromMonth = Convert.ToInt32(reader["open_from_mm"]);
                        campground.OpenToMonth = Convert.ToInt32(reader["open_to_mm"]);
                        campground.DailyFee = Convert.ToDecimal(reader["daily_fee"]);
                        campgrounds.Add(campground);
                    }
                    return campgrounds;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading in campgrounds by park ID");
                Console.WriteLine(e.Message);
                return campgrounds;
            }
        }


        
    }
}
