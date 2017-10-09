using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    abstract class Payment
    {
        protected int Price;
        protected bool Success;

        public Payment(float price)
        {
            Price = (int)Math.Round(price * 100);
            Success = false;
        }

        protected abstract void Pay(int price);


        public bool isSuccessfull()
        {
            return Success;
        }
    }

    class Cash : Payment
    {
        IKEAMyntAtare2000 coinMachine;

        public Cash(int price)
        : base(price)
        {
            coinMachine = new IKEAMyntAtare2000();
        }

        protected override void Pay(int price)
        {
            coinMachine.starta();
            coinMachine.betala(Price);
            coinMachine.stoppa();
            Success = true;
        }
    }

    abstract class Card : Payment, ICard
    {
        string cardtype;

        public Card(int price)
        : base(price)
        {

        }

        public void Connect()
        {
            MessageBox.Show("Connecting to " + cardtype + " reader");
        }

        public void Disconnect()
        {
            MessageBox.Show("Disconnecting from " + cardtype + " reader");
        }

        public int BeginTransaction(float amount)
        {
            MessageBox.Show("Begin transaction 1 of " + amount + " EUR");
            return 1;
        }

        public bool EndTransaction(int id)
        {
            if (id != 1)
                return false;

            MessageBox.Show("End transaction 1");
            return true;
        }

        public void CancelTransaction(int id)
        {
            if (id != 1)
                throw new Exception("Incorrect transaction id");

            MessageBox.Show("Cancel transaction 1");
        }
    }
}

