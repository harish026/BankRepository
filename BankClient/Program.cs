// using System;
// using System.Collections.Generic;
// using BankLibrary;

// namespace BankClient
// {
//     class Program
//     {
//         static void main(string[] args)
//         {

//             //SBAccount sba=new SBAccount(123456789,"harish","warangal",1500);
//             //SBAccount sba2=new SBAccount(1234567,"hari","hyderabad",2000);
//             BankRepository br=new BankRepository();
//             //br.NewAccount(sba);
//             //br.NewAccount(sba2);
//             System.Console.WriteLine("Enter the account number :");
//             int acc=Convert.ToInt32(Console.ReadLine());
//             try{
//                 br.GetAccountDetails(acc);
//             }
//             catch(Exception e){
//                 System.Console.WriteLine(e.Message);
//             }
//             List<SBAccount> sblist=br.GetAllAccounts();
//             int len=sblist.Count;
//             System.Console.WriteLine(len);

//             System.Console.WriteLine("Enter the account number :");
//             int acc1=Convert.ToInt32(Console.ReadLine());
//             System.Console.WriteLine("Enter the amount to be deposited :");
//             decimal deposit=Convert.ToInt32(Console.ReadLine());
//             br.DepositAmount(acc1,deposit);
//             try{
//                 System.Console.WriteLine("Enter the account number :");
//                 int acc2=Convert.ToInt32(Console.ReadLine());
//                 System.Console.WriteLine("enter the amount to be withdrawl :");
//                 decimal withdrawl=Convert.ToInt32(Console.ReadLine());
//                 br.WithdrawAmount(acc2,withdrawl);
//             }
//             catch(Exception e){
//                 System.Console.WriteLine(e.Message);

//             }
//             List<SBTransaction> tlist=br.GetTransactions(acc);
//             System.Console.WriteLine("no of transactions of account number {0} are {1}",acc,tlist.Count);

//         }
//     }
// }
