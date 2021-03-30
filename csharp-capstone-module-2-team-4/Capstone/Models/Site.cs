using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Site
    {

        /// <summary>
        /// ID of the site
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// ID of related campground 
        /// </summary>
        public int CampgroundId { get; set; }
        /// <summary>
        /// Individual camping sites in each overall campground site
        /// </summary>
        public int SiteNumber { get; set; }
        /// <summary>
        /// Max occupancy for each camp site
        /// </summary>
        public int MaxOccupancy { get; set; }
        /// <summary>
        /// Is the site Accessible
        /// </summary>
        public bool Accessible { get; set; }
        /// <summary>
        /// Camp site Max RV length
        /// </summary>
        public int MaxRVLength {get; set;}
        /// <summary>
        /// Does the site have additional Utilities
        /// </summary>
        public bool Utilities { get; set; }
    }
}
