using Capstone.DAL;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class CapstoneCLI
    {
        const string comm_GetAllAvailableParks = "1";
        const string comm_SelectPark = "2";
        const string comm_SelectCampground = "3";
        const string comm_ViewReservations = "4";
        const string comm_Quit = "Q";

        private ICampgroundDAO campgroundDAO;
        private ISiteDAO siteDAO;
        private IReservationDAO reservationDAO;
        private IParkDAO parkDAO;

        public CapstoneCLI(ISiteDAO siteDAO, IParkDAO parkDAO, IReservationDAO reservationDAO, ICampgroundDAO campgroundDAO)
        {
            this.campgroundDAO = campgroundDAO;
            this.siteDAO = siteDAO;
            this.reservationDAO = reservationDAO;
            this.parkDAO = parkDAO;
        }

        public void runCLI()
        {
            printHeader();
            printMenu();

            while(true)
            {
                string comm = Console.ReadLine();
                Console.Clear();
                switch(comm.ToUpper())
                {
                    case comm_GetAllAvailableParks:
                        getAllAvailableParks();
                        break;

                    case comm_SelectPark:
                        selectPark();
                        break;

                    case comm_SelectCampground:
                        selectCampground();
                        break;

                    case comm_ViewReservations:
                        viewReservations();
                        break;

                    case comm_Quit:
                        Console.WriteLine("Thank you for camping with us!");
                        return;

                    default:
                        Console.WriteLine("Invalid selection, please try again");
                        break;
                }
                printMenu();
            }
        }

        private void printHeader()
        {
            Console.WriteLine(@" _   _   ___  _______  _  _____   ___   _        ___     ___   ____   _   _  _____");
            Console.WriteLine(@"| \ | | / _ \|__   __|| ||  _  | / _ \ | |      |  _ \  / _ \ | ___ \| | / // ____|");
            Console.WriteLine(@"|  \| |/ /_\ \  | |   | || | | |/ /_\ \| |      | |_| |/ /_\ \| |_| /| |/ / \ '--.");
            Console.WriteLine(@"|     || ___ |  | |   | || | | || ___ || |      | ___/ | ___ ||    / |   /   '--. \");
            Console.WriteLine(@"| |\  || | | |  | |   | || |_| || | | || |___   | |    | | | || |\ \ | |\ \ /\__/ /");
            Console.WriteLine(@"|_| \_|\_| |_/  |_|   |_||_____|\_| |_/|_____|  |_|    \_| |_/\_| \_|\_| \_\\____/");
            Console.WriteLine();
            Console.WriteLine(@"A Great Day For The Great Outdoors!");
        }

        private void printMenu()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Main Menu: Please select from the following options:");
            Console.WriteLine("1 - List All Available Parks");
            Console.WriteLine("2 - Select Campgrounds by Park");
            Console.WriteLine("3 - Select Reservation by Campground");
            Console.WriteLine("4 - List Upcoming Reservations");
            Console.WriteLine("Q - Quit");
        }

        private void getAllAvailableParks()
        {
            IList<Park> parks = parkDAO.GetAllAvailableParks();
            Console.WriteLine();
            Console.WriteLine("Printing all available parks");
            if (parks.Count > 0)
            {
                foreach (Park park in parks)
                {
                    Console.WriteLine($"\nPark ID: {park.Id} \nName: {park.Name.PadRight(5)}, {park.Location.PadRight(5)} Established: {park.DateEstablished} \nArea: {park.Area} \nVisitors: {park.Visitors} \nDescription: \n{park.Description}\n");
                }
            }
            else
            {
                Console.WriteLine("**** NO RESULTS ****");
            }
        }

        private void selectPark()
        {
            getAllAvailableParks();
            bool noAdvance = false;
            do
            {
                Console.WriteLine("Which Park's Campgrounds would you like to view? (numeric value))");
                string userResponse = Console.ReadLine();
                Console.Clear();

                try
                {
                    int value = Int32.Parse(userResponse);
                    IList <Campground> campgrounds = campgroundDAO.GetCampgroundsByPark(value);

                    if (campgrounds.Count > 0)
                    {
                        foreach (Campground campground in campgrounds)
                        {
                            Console.WriteLine($"\n\n{campground.Id}  {campground.Name} \nOpen From {campground.OpenFromMonth} to {campground.OpenToMonth} \nDaily Fee: {campground.DailyFee}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("**** NO RESULTS ****");
                    }
                    noAdvance = false;
                }
                catch(Exception e)
                {
                    Console.WriteLine("Error... value entered is invalid \nPlease Try Again...");
                    noAdvance = true;
                }
            }
            while (noAdvance);
        }

        private void selectCampground()
        {
            bool noAdvance = true;
            int campID;
            DateTime startDate;
            DateTime endDate;

            selectPark();

            do
            {
                Console.WriteLine("Which campground would you like to make a reservation for (by numeric ID)?");
                string userCampID = Console.ReadLine();

                Console.WriteLine("Please enter the first date of your stay(YYYY-MM-DD): ");
                string userStartDate = Console.ReadLine();

                Console.WriteLine("Please enter the last date of your stay(YYYY-MM-DD): ");
                string userLastDate = Console.ReadLine();

                try
                {
                    campID = int.Parse(userCampID);
                    startDate = DateTime.Parse(userStartDate);
                    endDate = DateTime.Parse(userLastDate);
                    noAdvance = false;

                    IList<Site> sites = siteDAO.GetAvailableSites(campID, startDate, endDate);

                    foreach(Site site in sites)
                    {
                        Console.WriteLine($"\nCampsite ID: {site.SiteNumber} \nAccessible: {site.Accessible} |  Utilities: {site.Utilities} \nMax Occupancy: {site.MaxOccupancy} \nMax RV Length: {site.MaxRVLength}");
                        Console.WriteLine($"Total Price: {reservationDAO.GetTotalCost(startDate, endDate, site.CampgroundId):C2}");
                    }

                    noAdvance = true;
                    int siteID = 0;

                    do
                    {
                        Console.Write("\nPlease select the site (by ID) you would like to stay at: ");
                        string userSiteID = Console.ReadLine();
                        try
                        {
                            siteID = int.Parse(userSiteID);
                            foreach(Site site in sites)
                            {
                                if(siteID == site.Id)
                                {
                                    noAdvance = false;
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("The site ID you selected is invalid (Enter the numeric ID of the campsite)");
                        }
                    }
                    while (noAdvance);

                    Console.Write("Please enter a name for the reservation: ");
                    string reservationName = Console.ReadLine();

                    bool wasSuccessful = reservationDAO.MakeReservation(siteID, reservationName, startDate, endDate);
                    if(wasSuccessful)
                    {
                        Console.WriteLine("Reservation Created Successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Reservation was not successful! A value you entered was likely invalid.\nYou may need to restart... sorry!");
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine("The values you entered were invalid... \n*Select the campground by ID, Dates are in the format YYYY-MM-DD");
                    Console.WriteLine(e.Message);
                }                
            }
            while(noAdvance);
        }

        private void viewReservations()
        {
            bool noAdvance = false;
            do
            {
                Console.Clear();
                getAllAvailableParks();

                Console.WriteLine("Which Park's Reservations would you like to view? (numeric value))");
                string userResponse = Console.ReadLine();

                try
                {
                    int value = Int32.Parse(userResponse);
                    IList<Reservation> reservations = reservationDAO.GetReservations30Days(value);
                    if (reservations.Count > 0)
                    {
                        Console.WriteLine("ID   SiteID  Name                    Start Date                 End Date               Created");
                        foreach (Reservation reservation in reservations)
                        {
                            Console.WriteLine($"{reservation.Id}  |  {reservation.SiteId} | {reservation.ReservationName} | {reservation.StartDate}  |   {reservation.EndDate}  | {reservation.EndDate}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("**** NO RESULTS ****");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error... value entered for the park's ID is invalid. Please Try Again...\n\n*Press any key to continue");
                    Console.ReadLine();
                    noAdvance = true;
                }
            }
            while (noAdvance);
        }
    }
}
