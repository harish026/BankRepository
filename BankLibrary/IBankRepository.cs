using System;
using System.Collections.Generic;
using BankLibrary.Models;

namespace BankLibrary{

    public interface IBankRepository{
        void NewAccount(HarishSbaccount acc); //done
        HarishSbaccount GetAccountDetails(int accno);  //done
        List<HarishSbaccount> GetAllAccounts(); 
        void DepositAmount(int accno, decimal amt); //done
        void WithdrawAmount(int accno, decimal amt); //done
        List<HarishSbtransaction> GetTransactions(int accno);
    }
}