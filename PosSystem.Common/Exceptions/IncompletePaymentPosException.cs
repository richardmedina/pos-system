using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosSystem.Common.Exceptions
{
    public class IncompletePaymentPosException : Exception
    {
        public double ToPayAmount { get; init; }
        public double PaidAmount { get; init; }

        public IncompletePaymentPosException(double toPay, double paid)
        {
            ToPayAmount = toPay;
            PaidAmount = paid;
        }
    }
}
