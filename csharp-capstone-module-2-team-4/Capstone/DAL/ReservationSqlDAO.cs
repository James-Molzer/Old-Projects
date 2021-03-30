using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Capstone.DAL
{
    public class ReservationSqlDAO : IReservationDAO
    {
        private string connectionString;

        public ReservationSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public IList<Reservation> GetReservations30Days(int parkId)
        {
            DateTime startDate = DateTime.Now;
            DateTime resSearch = startDate.AddDays(30);
            IList<Reservation> reservations = new List<Reservation>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand();

                    string sqlStatement = "Select reservation.*, campground.park_id from reservation join campground on campground.campground_id = campground_id where to_date < @resSearch and from_date >= @startDate and park_id = @parkId";
                    sqlCommand.Parameters.AddWithValue("@resSearch", resSearch);
                    sqlCommand.Parameters.AddWithValue("@startDate", startDate);
                    sqlCommand.Parameters.AddWithValue("@parkId", parkId);
                    sqlCommand.CommandText = sqlStatement;
                    sqlCommand.Connection = connection;

                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        Reservation reservation = new Reservation();
                        reservation.Id = Convert.ToInt32(reader["reservation_id"]);
                        reservation.SiteId = Convert.ToInt32(reader["site_id"]);
                        reservation.ReservationName = Convert.ToString(reader["name"]);
                        reservation.StartDate = Convert.ToDateTime(reader["from_date"]);
                        reservation.EndDate = Convert.ToDateTime(reader["to_date"]);
                        reservation.DateCreated = Convert.ToDateTime(reader["create_date"]);
                        reservations.Add(reservation);
                    }
                    return reservations;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error getting current reservations");
                Console.WriteLine(e.Message);
                return reservations;
            }
        } 

        public bool MakeReservation(int siteID, string name, DateTime fromDate, DateTime toDate)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand();

                    string sqlStatement = "INSERT INTO reservation VALUES (@siteID, @name, @fromDate, @toDate, @createDate)";
                    sqlCommand.Parameters.AddWithValue("@siteID", siteID);
                    sqlCommand.Parameters.AddWithValue("@name", name);
                    sqlCommand.Parameters.AddWithValue("@fromDate", fromDate);
                    sqlCommand.Parameters.AddWithValue("@toDate", toDate);
                    sqlCommand.Parameters.AddWithValue("createDate", DateTime.Now);
                    sqlCommand.CommandText = sqlStatement;
                    sqlCommand.Connection = connection;

                    sqlCommand.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error creating reservation... Please Try Again");
                Console.WriteLine("\n" + e.Message);
                return false;
            }
        }


        public decimal GetTotalCost(DateTime from , DateTime to, int campId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand sqlCommand = new SqlCommand();
                    string sqlStatement = "SELECT DATEDIFF(DAY, @from, @to) * daily_fee as total_cost FROM campground WHERE campground_id= @campId";
                    sqlCommand.Parameters.AddWithValue("@from", from);
                    sqlCommand.Parameters.AddWithValue("@to", to);
                    sqlCommand.Parameters.AddWithValue("@campId", campId);
                    sqlCommand.CommandText = sqlStatement;
                    sqlCommand.Connection = conn;

                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if(reader.Read())
                    {
                        decimal totalCost = Convert.ToDecimal(reader["total_cost"]);
                        return totalCost;
                    }
                    else
                    {
                        Console.WriteLine("No records returned");
                    }
                    return -1;
                }
            } 
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
                
            }
        }
    }
}

