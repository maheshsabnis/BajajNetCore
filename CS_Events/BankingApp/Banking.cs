using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Events.BankingApp
{
    //1. DEclare Delegate. If the delegate is used for event declarations
    // then the return type MUST be void

    public delegate void TransactionHandler(double amt);


    public class Banking
    {
        // 2. define event using the delegate
        public event TransactionHandler OverBalance;
        public event TransactionHandler UnderBalance;

        double _NetBalance;
        public Banking(double netBalance)
        {
            _NetBalance = netBalance;
        }

        public void Deposit(double amount)
        {
            _NetBalance += amount;
            // 3. Raise event COnditionally
            if(_NetBalance > 100000)
            {
                OverBalance(_NetBalance);
            }
        }
        public void Withdawal(double amount)
        { 
            _NetBalance -= amount;
            // 3. Raise event
            if (_NetBalance < 5000)
            {
                UnderBalance(_NetBalance);
            }
        }
        public double GetBalance() 
        {
            return _NetBalance;
        }
    }

    /// <summary>
    /// THis class will be responsible
    /// to listen the transaction and accordingly 
    /// Notiy to the Client
    /// </summary>
    public class EventNotification
    {
        Banking bank;
        /// <summary>
        /// The Linking between the Banking class and EventNotification class
        /// so that all transactions will be listened by this class
        /// </summary>
        /// <param name="bank"></param>
        public EventNotification(Banking bank)
        {
            this.bank = bank;
            // Listen to the evet raised by the bank object
            // and execute a method as a repose to it
            // LInk a method to event using the delegate (older C# 1.x Syntax) 
            bank.OverBalance += new TransactionHandler(Bank_OverBalance);
            // Link a methdo to event using delege implicitly
            // C# 2.0+ SYntax
            bank.UnderBalance += new TransactionHandler(Bank_UnderBalance);
        }

        private void Bank_UnderBalance(double amt)
        {
            Console.WriteLine("Sir, pleas check your balance");
        }

        protected void Bank_OverBalance(double amt) 
        {
            double taxableAmount = amt - 100000;
            double payableTAx = taxableAmount * 0.15;
            Console.WriteLine($"Dear Sir, you NEt Balance is Rs {amt}/- which is Rs.{taxableAmount}/- more than Rs. 100000, s please pay Tax of Rs.{payableTAx}/- else Mr. Modi will catch you.");


        }
        
    }
}
