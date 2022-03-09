using System;
namespace BankLibrary{

    public class SBTransaction{
        public int t_id{get;set;}
        public DateTime t_date;
        public int AccountNumber{get;set;}
        public int amount{get;set;}
        public string t_type{get;set;}

    }
}