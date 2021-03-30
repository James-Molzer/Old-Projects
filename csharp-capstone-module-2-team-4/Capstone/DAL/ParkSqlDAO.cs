using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    public class ParkSqlDAO : IParkDAO
    {
        private string connectionString;

        public ParkSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public IList<Park> GetAllAvailableParks()
        {
            IList<Park> parks = new List<Park>();
            try
            {
                // Open connection 
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand();

                    //Creating SqlCommand Object
                    string sqlStatement = "SELECT * FROM park ORDER BY name";
                    sqlCommand.CommandText = sqlStatement;
                    sqlCommand.Connection = connection;

                    //Start Reader
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while(reader.Read())
                    {
                        //Settings park object values 
                        Park park = new Park();
                        park.Id = Convert.ToInt32(reader["park_id"]);
                        park.Name = Convert.ToString(reader["name"]);
                        park.Location = Convert.ToString(reader["location"]);
                        park.DateEstablished = Convert.ToDateTime(reader["establish_date"]);
                        park.Area = Convert.ToInt32(reader["area"]);
                        park.Visitors = Convert.ToInt32(reader["visitors"]);
                        park.Description = Convert.ToString(reader["description"]);
                        parks.Add(park);
                    }
                    return parks;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error reading in parks from database");
                Console.WriteLine(e.Message);
                return parks;
            }
        }
    }

}
