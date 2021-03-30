using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Campground
    {
        /// <summary>
        /// Campground ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Park ID for campground
        /// </summary>
        public int ParkId { get; set; }

        /// <summary>
        /// Campground name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The first month the campground is open for that year
        /// </summary>
        public int OpenFromMonth { get; set; }

        /// <summary>
        /// The last month the campground is open for that year
        /// </summary>
        public int OpenToMonth { get; set; }

        /// <summary>
        /// Cost of campground per day
        /// </summary>
        public decimal DailyFee { get; set; }

    }
}
