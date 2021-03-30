using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    public class SiteSqlDAO : ISiteDAO
    {
        private string connectionString;

        public SiteSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public IList<Site> GetAvailableSites(int campgroundID, DateTime startDate, DateTime endDate)
        {
            IList<Site> sites = new List<Site>();

            if((endDate - startDate).TotalDays < 0)
            {
                throw new System.ArgumentException("\n***Dates out of range. The total days cannot be negative.");
            }
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand();

                    //string sqlStatement = "SELECT * FROM reservation RIGHT JOIN site on site.site_id = reservation.site_id WHERE campground_id=@campgroundID";
                    string sqlStatement = "SELECT * FROM site LEFT JOIN reservation on site.site_id = reservation.site_id WHERE campground_id=@campgroundID";
                    sqlCommand.Parameters.AddWithValue("@campgroundID", campgroundID);
                    sqlCommand.CommandText = sqlStatement;
                    sqlCommand.Connection = connection;

                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while(reader.Read())
                    {
                        Site site = new Site();
                        site.Id = Convert.ToInt32(reader["site_id"]);
                        site.CampgroundId = Convert.ToInt32(reader["campground_id"]);
                        site.SiteNumber = Convert.ToInt32(reader["site_number"]);
                        site.MaxOccupancy = Convert.ToInt32(reader["max_occupancy"]);
                        site.Accessible = Convert.ToBoolean(reader["accessible"]);
                        site.MaxRVLength = Convert.ToInt32(reader["max_rv_length"]);
                        site.Utilities = Convert.ToBoolean(reader["utilities"]);
                        
                        if(reader["from_date"] == DBNull.Value || reader["to_date"] == DBNull.Value)
                        {
                            sites.Add(site);
                        }
                        else
                        {
                            DateTime beginDate = Convert.ToDateTime(reader["from_date"]);
                            DateTime endingDate = Convert.ToDateTime(reader["to_date"]);

                            if(!((startDate >= beginDate && startDate <= endingDate) || (endDate >= beginDate && endDate <= endingDate)))
                            {
                                sites.Add(site);
                            }
                        }
                    }
                }
                return sites;
            }
            catch(Exception e)
            {
                Console.WriteLine("Error reading in availible sites...");
                Console.WriteLine(e.Message);
                return sites;
            }
        }
    }
}
