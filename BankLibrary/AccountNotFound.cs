using System;
namespace BankLibrary{

    public class AccountNotFound:ApplicationException{

        public AccountNotFound(string message):base(message){
            
        }
    }
}