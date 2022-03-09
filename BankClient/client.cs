using System;
using System.Collections;
using  System.Collections.Generic;
using BankLibrary;
using BankingFunctionalities;
using BankLibrary.Models;
using System.IO;

namespace BankClient{

    class client{
        public static void Main(){
            FileStream fs=new FileStream("AccountDetails.txt",FileMode.Append,FileAccess.Write);
            StreamWriter sw=new StreamWriter(fs);
            System.Console.WriteLine("*****welcome!!*****");
            int k=0;
            int ch;
            BankRepository br=new BankRepository();
            bankFun bf=new bankFun();
            int temp=0;
            while(temp==0){
                System.Console.WriteLine("1 . admin");
                System.Console.WriteLine("2 .client");
                System.Console.WriteLine("3 . Exit");
                System.Console.WriteLine("enter your choice :");
                int ch1=Convert.ToInt32(Console.ReadLine());
                k=0;

            while(k==0){
                if(ch1==1){
                    System.Console.WriteLine("1. fetch Account details");
                    System.Console.WriteLine("2 .GetAccount Details");
                    System.Console.WriteLine("3 .get Teansactions");
                    System.Console.WriteLine("4 .Exit");
                    System.Console.WriteLine();
                    System.Console.WriteLine("Enter your choice ");
                    ch=Convert.ToInt32(Console.ReadLine());
                    switch(ch){
                        case 1: {
                            System.Console.WriteLine("entr the account number :");
                            int accno=Convert.ToInt32(Console.ReadLine());
                            try{
                            //SBAccount s1=new SBAccount();
                                HarishSbaccount s1=new HarishSbaccount();
                                s1=br.GetAccountDetails(accno);
                                System.Console.WriteLine("account number :"+s1.AccountNumber);
                                System.Console.WriteLine("account holder's name :"+s1.CustomerName);
                                System.Console.WriteLine("Current Balance :"+s1.CurrentBalance);
                            }
                            catch(Exception e){
                                System.Console.WriteLine(e.Message);
                            }
                            break;
                        }
                        case 2 :{
                            List<HarishSbaccount> sblist=br.GetAllAccounts();
                            int len=sblist.Count;
                            System.Console.WriteLine("total number of accounts are:"+len);
                            int ct=1;
                            foreach(HarishSbaccount s in sblist){
                                System.Console.WriteLine("Customer {0}",ct);
                                System.Console.WriteLine("Account Number :"+s.AccountNumber);
                                System.Console.WriteLine("Customer Name :"+s.CustomerName);
                                System.Console.WriteLine("Customer Address :"+s.CustomerAddress);
                                System.Console.WriteLine("Current Balance of the Customer : "+s.CurrentBalance);
                                ct++;
                            }
                            break;
                        }
                        case 3 :{
                            System.Console.WriteLine("enter the account number :");
                            int acc=Convert.ToInt32(Console.ReadLine());
                            List<HarishSbtransaction> tlist=br.GetTransactions(acc);
                            System.Console.WriteLine("no of transactions of account number {0} are {1}",acc,tlist.Count);
                            int te=1;
                            foreach(HarishSbtransaction t in tlist){
                                System.Console.WriteLine("transaction :{0}",te);
                                System.Console.WriteLine("account number of which transactions to be fetched :"+t.AccountNumber);
                                System.Console.WriteLine("transaction id :"+t.TId);
                                System.Console.WriteLine("type :"+t.TType);
                                System.Console.WriteLine("date of the transaction :"+t.TDate);
                                System.Console.WriteLine("amount :"+t.Amount);
                                te++;
                            }
                            break;
                        }
                        case 4: {
                            k=1;
                            break;
                        }
                    }


                }
                else if(ch1==2){
                
                System.Console.WriteLine("1. create new account");
                System.Console.WriteLine("2. fetch Account details");
                System.Console.WriteLine("3. Deposit Amount");
                System.Console.WriteLine("4. withdrawl amount");
                System.Console.WriteLine("5 .get Teansactions");
                System.Console.WriteLine("6 .transfer amount");
                System.Console.WriteLine("7 .Loan Eligibility");
                System.Console.WriteLine("8 .Exit");
                System.Console.WriteLine();
                System.Console.WriteLine("enter your choice");
                ch=Convert.ToInt32(Console.ReadLine());
                switch(ch){
                    case 1: {
                        //SBAccount sb=new SBAccount();
                        HarishSbaccount sb=new HarishSbaccount();
                        br.NewAccount(sb);
                        sw.WriteLine("AccountNumber :"+sb.AccountNumber+"   CustomerName :"+sb.CustomerName+"  CustomerAddress : "+sb.CustomerAddress+"  currentBalance :"+sb.CurrentBalance);
                        sw.Flush();
                        fs.Close();
                        break;
                    }
                    case 2 : {
                        System.Console.WriteLine("entr the account number :");
                        int accno=Convert.ToInt32(Console.ReadLine());
                        try{
                            //SBAccount s1=new SBAccount();
                            HarishSbaccount s1=new HarishSbaccount();
                            s1=br.GetAccountDetails(accno);
                            System.Console.WriteLine("account number :"+s1.AccountNumber);
                            System.Console.WriteLine("account holder's name :"+s1.CustomerName);
                            System.Console.WriteLine("current account balance :"+s1.CurrentBalance);

                        }
                        catch(Exception e){
                            System.Console.WriteLine(e.Message);
                        }
                        
                        break;
                    }
                    case 3 : {
                        System.Console.WriteLine("Enter the account number :");
                        int acc1=Convert.ToInt32(Console.ReadLine());
                        System.Console.WriteLine("Enter the amount to be deposited :");
                        decimal deposit=Convert.ToInt32(Console.ReadLine());
                        try{
                            br.DepositAmount(acc1,deposit);
                        }
                        catch(Exception e){
                            System.Console.WriteLine(e.Message);
                        }

                        break;
                    }
                    case 4 : {
                        try{
                            System.Console.WriteLine("Enter the account number :");
                            int acc2=Convert.ToInt32(Console.ReadLine());
                            System.Console.WriteLine("enter the withdrawl amount :");
                            decimal withdrawl=Convert.ToInt32(Console.ReadLine());
                            br.WithdrawAmount(acc2,withdrawl);
                        }
                        catch(Exception e){
                            System.Console.WriteLine(e.Message);

                        }

                        break;
                    }
                    case 5:{
                        System.Console.WriteLine("enter the account number :");
                        int acc=Convert.ToInt32(Console.ReadLine());
                        List<HarishSbtransaction> tlist=br.GetTransactions(acc);
                        System.Console.WriteLine("no of transactions of account number {0} are {1}",acc,tlist.Count);
                        int te=1;
                        foreach(HarishSbtransaction t in tlist){
                            System.Console.WriteLine("transaction :{0}",te);
                            System.Console.WriteLine("account number of which transactions to be fetched :"+t.AccountNumber);
                            System.Console.WriteLine("transaction id :"+t.TId);
                            System.Console.WriteLine("type :"+t.TType);
                            System.Console.WriteLine("date of the transaction :"+t.TDate);
                            System.Console.WriteLine("amount :"+t.Amount);
                            te++;
                        }
                        break;
                    }
                    case 6 :{
                        System.Console.WriteLine("enter the sender accountNumber :");
                        int acc1=Convert.ToInt32(Console.ReadLine());
                        System.Console.WriteLine("enter the recipient AccountNumber :");
                        int acc2=Convert.ToInt32(Console.ReadLine());
                        System.Console.WriteLine("enter the amount to be transferred :");
                        int amt=Convert.ToInt32(Console.ReadLine());
                        try{
                            bf.transferAmount(acc1,acc2,amt);    
                        }
                        catch(Exception e){
                            System.Console.WriteLine(e.Message);
                        }
                        

                        break;
                    }
                    case 7:{
                        System.Console.WriteLine("enter the account number :");
                        int acc=Convert.ToInt32(Console.ReadLine());
                        System.Console.WriteLine("enter the loan amount :");
                        int amt=Convert.ToInt32(Console.ReadLine());
                        try{
                            bf.LoanEligibility(acc,amt);
                        }
                        catch(Exception e){
                            System.Console.WriteLine(e.Message);
                        }
                        break;
                    }

                    case 8 : {
                        k=1;
                       // return;

                        break;
                    }

                }
                }
                else if(ch1==3){
                    System.Console.WriteLine("Thank you :)");
                    return;
                }
            }
            }
            //System.Console.WriteLine("hey");
            
        }
    }
}