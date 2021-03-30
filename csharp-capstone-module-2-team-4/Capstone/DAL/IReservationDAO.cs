using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.DAL
{
    public interface IReservationDAO
    {
        IList<Reservation> GetReservations30Days(int park_id);
        decimal GetTotalCost(DateTime from, DateTime to, int campId);
        bool MakeReservation(int siteID, string name, DateTime fromDate, DateTime toDate);
    }
}
