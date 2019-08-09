using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestLearningApp
{
	public interface ISecurityService
	{
		void RegisterAccount(BankAccount account);
		bool VerifyAccount(BankAccount account);
	}

	public class SimpleSecurityService : ISecurityService
	{
		private List<BankAccount> registeredAccounts;
		
		public void RegisterAccount(BankAccount account)
		{
			if(!registeredAccounts.Contains(account))
			{
				registeredAccounts.Add(account);
			}
		}

		public bool VerifyAccount(BankAccount account)
		{
			return (registeredAccounts.Contains(account));
		}
	}
}
