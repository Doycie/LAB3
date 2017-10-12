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
        public static float getPrice(Ticket ticket)
        {
            int tariefeenheden = Tariefeenheden.getTariefeenheden(ticket.trajectory.Origin, ticket.trajectory.Destination);

            // Compute the column in the table based on choices
            int tableColumn;
            // First based on class
            if (ticket.ticketClass == Ticket.TicketClass.First)
            {
                tableColumn = 3;
            }
            else
            {
                tableColumn = 0;
            }
            // Then, on the discount
            if(ticket.discount == Ticket.Discount.Twenty)
                    tableColumn += 1;
            else if(ticket.discount == Ticket.Discount.Forty)
                    tableColumn += 2;
                    
            

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