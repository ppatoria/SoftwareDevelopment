using System;

namespace MSPress.CSharpCoreRef.Bank
{
    /// <summary>
    /// Manages withdrawal policy, providing automatic
    /// loans in case of overdraft.
    /// </summary>
    public class OverdraftProtection
    {
        public OverdraftProtection(decimal initialLoan)
        {
            _availableLoan = initialLoan;
            _currentLoan = 0;
        }

        public decimal AvailableLoan
        {
            set { _availableLoan = value; }
            get { return _availableLoan; }
        }
        public decimal CurrentLoan
        {
            set { _currentLoan = value; }
            get { return _currentLoan; }
        }

        /// <summary>
        /// Method used with instances of WithdrawalPolicyDelegate
        /// to manage debits to an account. Overdrafts are covered
        /// up to a fixed amount specified at construction.
        /// </summary>
        /// <param name="debit">Attempted debit.</param>
        /// <returns>True if successful, false if overdraft
        /// loan amount exceeded.</returns>
        public bool HandleDebit(decimal debit)
        {
            if(debit > 0)
            {
                if(debit <= _availableLoan)
                {
                    _availableLoan -= debit;
                    _currentLoan += debit;
                }
                else
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Loan available for use in case of overdraft
        /// </summary>
        protected decimal _availableLoan;
        /// <summary>
        /// Current overdraft loan amount
        /// </summary>
        protected decimal _currentLoan;
    }
}
