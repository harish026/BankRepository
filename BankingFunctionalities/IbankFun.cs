using System;
using BankLibrary.Models;
namespace BankingFunctionalities{
    interface IbankFun{
        void transferAmount(int acc1,int acc2,int amt);
        void LoanEligibility(int accno,int amt);
    }
}