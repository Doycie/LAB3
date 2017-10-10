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
        protected bool Success;

        public Payment(float price)
        {
            Price = price;
            Success = false;
        }

        public abstract void Pay();


        public bool isSuccessfull()
        {
            return Success;
        }
    }
}

