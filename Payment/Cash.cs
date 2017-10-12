using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    class Cash : Payment
    {
        IKEAMyntAtare2000 coinMachine;

        public Cash(float price)
        : base(price)
        {
            coinMachine = new IKEAMyntAtare2000();
        }

        public override void Pay()
        {
            coinMachine.starta();
            coinMachine.betala((int)Math.Round(Price * 100));
            coinMachine.stoppa();
        }
    }
}
