using System;

namespace MSPress.CSharpCoreRef.Bank
{
    public class OverdraftEventArgs: EventArgs
    {
        public OverdraftEventArgs(decimal balance, decimal withdrawal)
        {
            _balance = balance;
            _withdrawal = withdrawal;
        }

        public decimal Balance
        {
            get { return _balance; }
        }

        public decimal Withdrawal
        {
            get { return _withdrawal; }
        }

        protected decimal _balance;
        protected decimal _withdrawal;
    }
}
