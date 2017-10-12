using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    abstract class Payment
    {
        protected float Price;

        public Payment(float price)
        {
            Price = price;
        }

        public abstract void Pay();

    }
}

