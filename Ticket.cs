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

    public class Ticket
    {
        public Trajectory trajectory;
        public enum TicketClass { First, Second };
        public TicketClass ticketClass;
        public bool isReturn;
        public enum Discount { Zero, Twenty, Forty };
        public Discount discount;

        public Ticket()
        {
            trajectory = new Trajectory();
        }
    }
}
