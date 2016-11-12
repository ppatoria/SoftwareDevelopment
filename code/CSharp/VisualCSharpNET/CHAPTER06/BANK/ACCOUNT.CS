using System;

namespace MSPress.CSharpCoreRef.Bank
{
    public class Account
    {
        public delegate bool DebitPolicy(decimal aWithdrawal);
        public Account(decimal anInitialBalance,
                       DebitPolicy aDebitPolicy)
        {
            _balance = anInitialBalance;
            _debitPolicy = aDebitPolicy;
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

        public bool Withdrawal(decimal aWithdrawal)
        {
            if(aWithdrawal < 0)
                throw new ArgumentOutOfRangeException();
            if(aWithdrawal < _balance)
            {
                _balance -= aWithdrawal;
                return true;
            }
            else
            {
                // If no debit policy, no overdrafts are permitted.
                if(_debitPolicy == null)
                    return false;

                aWithdrawal -= _balance;
                if(_debitPolicy(aWithdrawal))
                {
                    _balance = 0;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        protected DebitPolicy _debitPolicy;
        protected decimal _balance;
    }
}
