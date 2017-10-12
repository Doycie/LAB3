using System;

namespace Lab3
{
    static class DBase
    {
        //This method takes a ticket and calculates the price based on its properties
        public static float getPrice(Ticket ticket)
        {
            int tariefeenheden = Tariefeenheden.getTariefeenheden(ticket.trajectory.Origin, ticket.trajectory.Destination);

            // Compute the column in the table based on choices
            int tableColumn;
            // First based on class
            if (ticket.ticketClass == TicketClass.First)
            {
                tableColumn = 3;
            }
            else
            {
                tableColumn = 0;
            }
            // Then, on the discount
            if(ticket.discount == Discount.Twenty)
                    tableColumn += 1;
            else if(ticket.discount == Discount.Forty)
                    tableColumn += 2;
                    
            return PricingTable.getPrice(tariefeenheden, tableColumn);
        }
    }
}