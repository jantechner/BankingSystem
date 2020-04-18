using System.Collections.Generic;

namespace Models
{
    public class InterBankPaymentManager
    {
        public List<Transfer> QueuedTransfers { get; }
    }
}