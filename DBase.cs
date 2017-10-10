using System;

namespace Lab3
{
    static class DBase
    {
        //This method is not needed because of the way the example is setup
        public static float GetDiscount()
        {
            return 0;
        }

        //This method takes a ticket and calculates the price based on its properties
        public static float getPrice(Ticket ticket, int disc)
        {
            int tariefeenheden = Tariefeenheden.getTariefeenheden(ticket.trajectory.Origin, ticket.trajectory.Destination);

            // Compute the column in the table based on choices
            int tableColumn;
            // First based on class
            if (ticket.ticketClass.firstClass)
            {
                tableColumn = 3;
            }
            else
            {
                tableColumn = 0;
            }
            // Then, on the discount
            switch (disc)
            {
                case 1:
                    tableColumn += 1;
                    break;

                case 2:
                    tableColumn += 2;
                    break;
            }

            return PricingTable.getPrice(tariefeenheden, tableColumn);
        }

        //This method is not needed because of the way the example is setup
        public static Trajectory getTrajectory(String[] stations)
        {
            Trajectory t = new Trajectory();
            return null;
        }

        //This method is not needed because of the way the example is setup
        public static String[] getStations()
        {
            return null;
        }

        //This method is not needed because of the way the example is setup
        public static String verifiedMachine()
        {
            return null;
        }
    }
}