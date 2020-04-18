using System;

namespace Models
{
    public class Transfer
    {
        public String From { get; }
        
        public String To { get; }

        public Enum Status { get; }

        public float Amount { get; }

    }
}