using System;
using System.Collections.Generic;

#nullable disable

namespace BankingFunctionalities
{
    public partial class SBTmapper
    {
        public int TId { get; set; }
        public DateTime TDate { get; set; }
        public int AccountNumber { get; set; }
        public int Amount { get; set; }
        public string TType { get; set; }
    }
}
