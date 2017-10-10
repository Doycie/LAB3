using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    class Trajectory {

        public String Destination { get; set; }
        public String Origin { get; set; }
        public int trajectoryValue { get; set; }
    }
    class TicketClass {
        
        public bool firstClass { get; set; }
    }
    class TicketDate {
        private DateTime date { get; set; }
        public String dateToString()
        {
            return date.ToString();
        }
    }
    class TicketType
    {
        public bool isSingle { get; set; }
        public bool isReturn { get; set; }
        public bool isDayCard { get; set; }
        public bool isBikeCard { get; set; }
    }





    class Ticket
    {
        public Trajectory trajectory;
        public TicketClass ticketClass;
        public TicketDate ticketDate;
        public TicketType ticketType;

    }
}
