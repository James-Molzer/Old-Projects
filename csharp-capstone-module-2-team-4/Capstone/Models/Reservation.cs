using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Reservation
    {
        /// <summary>
        /// Reservation ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// ID of site for given reservation
        /// </summary>
        public int SiteId { get; set; }
        /// <summary>
        /// Name of reserving family/party
        /// </summary>
        public string ReservationName { get; set; }
        /// <summary>
        /// Start date of reservation
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// End date of reservation
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// The date the reservation was booked
        /// </summary>
        public DateTime DateCreated { get; set; }
    }
}
