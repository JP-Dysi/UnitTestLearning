using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestLearningApp
{
	public class Bank
	{
		public ISecurityService security;

		public const string UnregisteredAccountErrorMessage = "Account must be registered with the security service.";
		
		public Bank(ISecurityService sec)
		{
			security = sec;
		}

		public void DebitAccount(BankAccount account, double amount)
		{
			if(security.VerifyAccount(account))
			{
				account.Debit(amount);
			}
			else{
				throw new ArgumentException(UnregisteredAccountErrorMessage, "account");
			}
		}

		public void CreditAccount(BankAccount account, double amount)
		{
			if(security.VerifyAccount(account))
			{
				account.Credit(amount);
			}
			else
			{
				throw new ArgumentException(UnregisteredAccountErrorMessage, "account");
			}
		}
		
	}
}
