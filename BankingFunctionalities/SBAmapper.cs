using System;
using System.Collections.Generic;
using BankLibrary;

#nullable disable

namespace BankingFunctionalities
{
    public partial class SBAmapper //:SBAccount
    {
        public int AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public int CurrentBalance { get; set; }
    }
}
