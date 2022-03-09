using System;
namespace BankLibrary{

    public class negativeAmountException:ApplicationException{

        public negativeAmountException(string message):base(message){
            
        }
    }
}