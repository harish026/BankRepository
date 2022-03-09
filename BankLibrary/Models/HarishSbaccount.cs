using System;
using System.Collections.Generic;

#nullable disable

namespace BankLibrary.Models
{
    public partial class HarishSbaccount
    {
        public int AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public int CurrentBalance { get; set; }
    }
}
