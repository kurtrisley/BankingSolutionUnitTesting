using System;
using System.Collections.Generic;
using System.Text;

namespace BankingDomain
{
    class SystemTime : ISystemTime
    {
        public DateTime GetCurrent()
        {
            return DateTime.Now;
        }
    }
}
