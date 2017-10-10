using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    public class Trajectory {

        public String Destination { get; set; }
        public String Origin { get; set; }
        public int trajectoryValue { get; set; }
    }
    public class TicketClass {
        
        public bool firstClass { get; set; }
    }
    public class TicketDate {
        private DateTime date { get; set; }
        public String dateToString()
        {
            return date.ToString();
        }
    }
    public  class TicketType
    {
        public bool isSingle { get; set; }
        public bool isReturn { get; set; }
        public bool isDayCard { get; set; }
        public bool isBikeCard { get; set; }
    }
    public class TicketDiscount
    {
        public int discount { get; set; }
    }





    public class Ticket
    {
        public Trajectory trajectory;
        public TicketClass ticketClass;
        public TicketDate ticketDate;
        public TicketType ticketType;
        public TicketDiscount ticketDiscount;

        public Ticket()
        {
            trajectory = new Trajectory();
            ticketClass = new TicketClass();
            ticketDate = new TicketDate();
            ticketType = new TicketType();
            ticketDiscount = new TicketDiscount();
        }
    }
}
