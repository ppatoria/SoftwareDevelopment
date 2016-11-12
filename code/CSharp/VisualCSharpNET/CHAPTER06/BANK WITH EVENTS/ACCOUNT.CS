using System;

namespace MSPress.CSharpCoreRef.Bank
{
	/// <summary>
	/// Summary description for account.
	/// </summary>
    public class Account
    {
        public delegate void OverdraftEventHandler(object sender, 
                                                  OverdraftEventArgs e);
        
        public event OverdraftEventHandler OnOverdraftHandler;

        public Account(decimal anInitialBalance)
        {
            _balance = anInitialBalance;
        }

        public decimal Balance
        {
            get
            {
                return _balance;
            }
        }

        public void Deposit(decimal aDeposit)
        {
            if(aDeposit < 0)
                throw new ArgumentOutOfRangeException();
            _balance += aDeposit;
        }

        public bool Withdrawal(decimal aDebit)
        {
            if(aDebit < 0)
                throw new ArgumentOutOfRangeException();
            if(aDebit < _balance)
            {
                _balance -= aDebit;
                return true;
            }
            OverdraftEventArgs args = new OverdraftEventArgs(_balance,
                                                             aDebit);
            OnOverdraft(args);
            return false;
        }

        public void AddOnOverdraft(OverdraftEventHandler handler)
        {
            OnOverdraftHandler += handler;
        }

        public void RemoveOnOverdraft(OverdraftEventHandler handler)
        {
            OnOverdraftHandler -= handler;
        }

        protected void OnOverdraft(OverdraftEventArgs e)
        {
            if(OnOverdraftHandler != null)
                OnOverdraftHandler(this, e);
        }

        protected decimal _balance;
    }
}
