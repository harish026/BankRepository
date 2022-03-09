using System;
using System.Collections;
using System.Collections.Generic;
using BankLibrary.Models;
using System.IO;

namespace BankLibrary{

    public class BankRepository : IBankRepository
    {
        DatabaseTrainingContext db=new DatabaseTrainingContext();
        //FileStream fs=new FileStream("AccountDetails.txt",FileMode.Append,FileAccess.Write);
        //StreamWriter sw=new StreamWriter(fs);
        //List<SBAccount> sbas=new List<SBAccount>();
        //List<SBTransaction> sbts=new List<SBTransaction>();
        public void NewAccount(HarishSbaccount acc)
        {
            
            System.Console.WriteLine("enter the AccountNumber : ");
            int accno=Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("enter the name of the customer :");
            string cname=Console.ReadLine();
            System.Console.WriteLine("enter your address :");
            string cadd=Console.ReadLine();
            System.Console.WriteLine("enter the current balance :");
            int bal=Convert.ToInt32(Console.ReadLine());
            acc.AccountNumber=accno;
            acc.CustomerName=cname;
            acc.CustomerAddress=cadd;
            acc.CurrentBalance=bal;
            //sbas.Add(acc);
            db.HarishSbaccounts.Add(acc);
            db.SaveChanges();
            

            System.Console.WriteLine("account created successfully");
        }
        // public class AccountNotFoundException:ApplicationException{
        //     public AccountNotFoundException(string message):base(message){

        //     }
        // }
        // public class negativeAmountException:ApplicationException{
        //     public negativeAmountException(string message):base(message){

        //     }
        // }
        public HarishSbaccount GetAccountDetails(int accno)
        {
            int q=0;
            HarishSbaccount sb=new HarishSbaccount();
            foreach(HarishSbaccount s in db.HarishSbaccounts){
                if(s.AccountNumber==accno){
                    System.Console.WriteLine("account details fetched sussessfully :)");
                    q=1;
                    sb=s;
                    break;
                }
            }
            if(q==1){
                return sb;
            }
            else{
                throw new AccountNotFound("accountNumber not found");
            }
        }
        public void DepositAmount(int accno, decimal amt)
        {
            Random rnd=new Random();
            HarishSbtransaction sbt1=new HarishSbtransaction();
            int ind=0;
            foreach(HarishSbaccount s in db.HarishSbaccounts){
                if(s.AccountNumber==accno){
                    
                    if(amt>=0 && amt<=10000){
                        ind=1;
                    s.CurrentBalance+=Convert.ToInt32(amt);
                    System.Console.WriteLine("amount of {0} deposited successfully!!",amt);
                    System.Console.WriteLine("current balance in your account with account number {0} is : {1}",s.AccountNumber,s.CurrentBalance);
                    
                    }
                    else if(amt<0){
                        throw new negativeAmountException("cannot enter negative amount");
                        
                    }
                    else{
                        ind=2;
                        System.Console.WriteLine("cannot deposit amount more than 10000");
                        return;
                    }
                    break;
                }
               // ind++;
            }
            if(ind==1){
                sbt1.AccountNumber=accno;
                sbt1.TId=rnd.Next();
                sbt1.TDate=DateTime.Today;
                sbt1.Amount=Convert.ToInt32(amt);
                sbt1.TType="deposit";
                //sbts.Add(sbt1);
                db.HarishSbtransactions.Add(sbt1);
                db.SaveChanges();
                System.Console.WriteLine("transaction details added successfully");
            }
            else{
                throw new AccountNotFound("accout not found");
            }
            
        }
        public class withdrawlimitException:ApplicationException{
            public withdrawlimitException(string message):base(message){

            }
        }
        public class insufficientbalanceException:ApplicationException{
            public insufficientbalanceException(string message):base(message){

            }
        }
        public void WithdrawAmount(int accno, decimal amt)
        {
            Random rnd=new Random();
            //SBTransaction sbt1=new SBTransaction();
            HarishSbtransaction sbt1=new HarishSbtransaction();
            int ind=0;
            foreach(HarishSbaccount s in db.HarishSbaccounts){
                if(s.AccountNumber==accno){
                    ind=1;
                    if(s.CurrentBalance>amt && amt<=10000 && amt>0){
                        s.CurrentBalance-=Convert.ToInt32(amt);
                        System.Console.WriteLine("ammount of {0} has been debited from your account successfully",amt);
                        System.Console.WriteLine("current balance in your account with account number {0} is : {1}",s.AccountNumber,s.CurrentBalance);
                       
                    }
                    else if(amt>10000){
                        throw new withdrawlimitException("Withdraw limt exceeded");
                    }
                    else if(amt>s.CurrentBalance){
                        throw new insufficientbalanceException("insufficient funds to perform withdrawl");
                    }
                    else if(amt<0){
                        throw new negativeAmountException("sorry! negative values are not allowed");
                    }
                    break;
                }
                //ind++;
            }
            if(ind==1){
                sbt1.AccountNumber=accno;
                sbt1.TId=rnd.Next();
                sbt1.TDate=DateTime.Today;
                sbt1.Amount=Convert.ToInt32(amt);
                sbt1.TType="withdrawl";
                db.HarishSbtransactions.Add(sbt1);
                db.SaveChanges();
            }
            else{
                throw new AccountNotFound("Account not found");
            }
            
        }

        public List<HarishSbaccount> GetAllAccounts()
        {
            List<HarishSbaccount> sbas=new List<HarishSbaccount>();
            foreach(HarishSbaccount s in db.HarishSbaccounts){
                sbas.Add(s);
            }
            System.Console.WriteLine("all accounts fetched sussessfully");
            
            return sbas;
        }

        public List<HarishSbtransaction> GetTransactions(int accno)
        {
            List<HarishSbtransaction> trlist=new List<HarishSbtransaction>();
            foreach(HarishSbtransaction st in db.HarishSbtransactions){
                if(st.AccountNumber==accno){
                    trlist.Add(st);
                }
            }
            System.Console.WriteLine("recorded all transactions of account number {0}",accno);
            return trlist;
        }
        
    }
}