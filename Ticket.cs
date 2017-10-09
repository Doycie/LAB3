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
        
        bool firstClass { get; set; }
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
        bool isSingle { get; set; }
        bool isReturn { get; set; }
        bool isDayCard { get; set; }
        bool isBikeCard { get; set; }
    }





    class Ticket
    {
        public Trajectory trajectory;
        public TicketClass ticketClass;
        public TicketDate ticketDate;
        public TicketType ticketType;

    }
}
