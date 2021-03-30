using Capstone.DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel;
using System.IO;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the connection string from the appsettings.json file
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            string connectionString = configuration.GetConnectionString("Project");

            ISiteDAO siteDAO = new SiteSqlDAO(connectionString);
            IParkDAO parkDAO = new ParkSqlDAO(connectionString);
            IReservationDAO reservationDAO = new ReservationSqlDAO(connectionString);
            ICampgroundDAO campgroundDAO = new CampgroundSqlDAO(connectionString);

            CapstoneCLI CLI = new CapstoneCLI(siteDAO, parkDAO, reservationDAO, campgroundDAO);
            CLI.runCLI();
        }
    }
}
