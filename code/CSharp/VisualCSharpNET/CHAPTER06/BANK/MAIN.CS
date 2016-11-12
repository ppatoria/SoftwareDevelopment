using System;

namespace MSPress.CSharpCoreRef.Bank
{
    class BankApp
	{
		static void Main(string[] args)
		{
            OverdraftProtection op = new OverdraftProtection(500);
            Account.DebitPolicy policy;
            policy = new Account.DebitPolicy(op.HandleDebit);
            Account myAccount = new Account(100, policy);

            bool done = false;
            do
            {
                DisplayMenu();
                string choice = Console.ReadLine();
                switch(choice.ToLower())
                {
                    case "w":
                        HandleWithdrawal(myAccount);
                        break;

                    case "d":
                        HandleDeposit(myAccount);
                        break;

                    case "q":
                        done = true;
                        break;

                    default:
                        InvalidChoice(choice);
                        break;
                }
                CurrentBalance(myAccount, op);
            }while(!done);
		}

        static void DisplayMenu()
        {
            Console.WriteLine("\n\nW) Withdraw");
            Console.WriteLine("D) Deposit");
            Console.WriteLine("Q) Quit");
            Console.Write("->");
        }

        static void InvalidChoice(string choice)
        {
            Console.WriteLine("{0} is not a valid choice.", choice);
        }

        static void HandleWithdrawal(Account anAccount)
        {
            Console.Write("Withdrawal amount: ");
            string request = Console.ReadLine();
            decimal withdrawal = Convert.ToDecimal(request);
            bool result = anAccount.Withdrawal(withdrawal);
            if(result == true)
                Console.WriteLine("Withdrawal of {0} was successful.", withdrawal);
            else
                Console.WriteLine("Withdrawal of {0} was not successful.", withdrawal);
        }

        static void HandleDeposit(Account anAccount)
        {
            Console.Write("Deposit amount: ");
            string request = Console.ReadLine();
            decimal deposit = Convert.ToDecimal(request);
            anAccount.Deposit(deposit);
        }

        static void CurrentBalance(Account anAccount, OverdraftProtection op)
        {
            Console.WriteLine("Balance is {0}", anAccount.Balance);
            Console.WriteLine("Available overdraft is {0}", op.AvailableLoan);
            Console.WriteLine("Current overdraft loan is {0}", op.CurrentLoan);
        }
	}
}
