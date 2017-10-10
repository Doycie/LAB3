using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    public class IKEAMyntAtare2000
    {
        public void starta()
        {
            MessageBox.Show("Välkommen till IKEA Mynt Ätare 2000");
        }

        public void stoppa()
        {
            MessageBox.Show("Hejdå!");
        }

        public void betala(int pris)
        {
            MessageBox.Show(pris + " cent");
        }
    }

    class Cash : Payment
    {
        IKEAMyntAtare2000 coinMachine;

        public Cash(float price)
        : base(price)
        {
            coinMachine = new IKEAMyntAtare2000();
        }

        protected override void Pay()
        {
            coinMachine.starta();
            coinMachine.betala((int)Math.Round(Price * 100));
            coinMachine.stoppa();
            Success = true;
        }
    }
}
