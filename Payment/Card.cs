using System;
using System.Windows.Forms;

namespace Lab3
{
    abstract class Card : Payment, ICard
    {
        protected string cardtype;

        public Card(float price)
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

        public override void Pay()
        {
            Connect();
            int dcid = BeginTransaction(Price);
            EndTransaction(dcid);
        }
    }

    class CreditCard : Card
    {
        public CreditCard(float price)
          : base(price)
        {
            Price += 0.50f;
            cardtype = "credit card";
        }
    }

    class DebitCard : Card
    {
        public DebitCard(float price)
            : base(price)
        {
            cardtype = "debit card";
        }
    }
}

