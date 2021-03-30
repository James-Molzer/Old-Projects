using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Park
    {
        /// <summary>
        /// ID of park
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name of park
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Location of park
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// Park date of establishment
        /// </summary>
        public DateTime DateEstablished { get; set; }
        /// <summary>
        /// Park area
        /// </summary>
        public int Area { get; set; }
        /// <summary>
        /// Number of visitors
        /// </summary>
        public int Visitors { get; set; }
        /// <summary>
        /// Description of park
        /// </summary>
        public string Description { get; set; }
    }
}
