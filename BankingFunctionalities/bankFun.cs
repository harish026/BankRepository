using System;
using BankLibrary;
using BankLibrary.Models;
using AutoMapper;

using System.Collections.Generic;
namespace BankingFunctionalities{
    public class bankFun : IbankFun
    {
        BankRepository br=new BankRepository();
    
        public void LoanEligibility(int acc,int amt)
        {
            SBAmapper sba=new SBAmapper();
            int k=0;
            var sb=br.GetAllAccounts();
            
            foreach(var s in sb){
                if(s.AccountNumber==acc){
                    k=1;
                    //sba=s;
                    var sbt=br.GetTransactions(acc);
                    // int dep=0;
                    // int withdraw=0;string d="deposit",w="withdrawl";
                    // foreach(var st in sbt){
                    //     System.Console.WriteLine(st.TType);
                    //     if(st.TType==d){
                    //         dep++;
                            
                    //     }
                    //     else if(st.TType==w){
                    //         withdraw++;
                            
                    //     }
                    // }
                    // System.Console.WriteLine(dep);
                    // System.Console.WriteLine(withdraw);
                    if(s.CurrentBalance<10000){
                        System.Console.WriteLine("sorry ! you are not eligible for loan");
                    }
                    else if(3*s.CurrentBalance<amt){
                        System.Console.WriteLine("your eligible loan amount is {0}:",3*s.CurrentBalance);
                    }
                    else{
                        System.Console.WriteLine("hurray !!!! loan amount of {0} is sanctioned.",amt);
                    }
                    
                    break;
                }
            }
            if(k==0){
                throw new AccountNotFound("Account not found");
            }
            
        }

        public void transferAmount(int acc1, int acc2, int amt)
        {
            int a1=0;
            int a2=0;
            // var config = new MapperConfiguration(cfg => {
            // cfg.CreateMap<HarishSbaccount, SBAmapper>();
            // IMapper mapper = config.CreateMapper();
            List<HarishSbaccount> sb=br.GetAllAccounts();
           // List<SBAmapper> sbamp=new List<SBAmapper>();

 
            foreach(var s in sb){
                // SBAmapper sb=mapper.Map<HarishSbaccount, SBAmapper>(s);
                // sbamp.Add(sb);

                
                //var dest = mapper.Map<HarishSbaccount, SBAmapper>(source);
                if(s.AccountNumber==acc1){
                    //System.Console.WriteLine(s.AccountNumber);
                    a1=1;
                }
                if(s.AccountNumber==acc2){
                   // System.Console.WriteLine(s.AccountNumber);
                    a2=1;
                }
            }
            // foreach(SBAmapper s in sbamp){
            //     System.Console.WriteLine(s.AccountNumber);
            // }
            //br.ch
            if(a1==1 && a2==1){
                br.WithdrawAmount(acc1,amt);
                br.DepositAmount(acc2,amt);
                System.Console.WriteLine("transaction completed successfully");
            }
            else{
                throw new AccountNotFound("account not found");
                //System.Console.WriteLine("account Not Found");
                
            }
            
        }
    }
}