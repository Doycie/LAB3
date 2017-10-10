using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    public interface ICard
    {
        void Connect();
        void Disconnect();
        int BeginTransaction(float amount);
        bool EndTransaction(int id);
        void CancelTransaction(int id);
    }
}
