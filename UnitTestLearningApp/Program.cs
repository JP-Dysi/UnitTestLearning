using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestLearningApp
{
	class Program
	{

		public static void Main(string[] args)
		{
			SimpleSecurityService secService = new SimpleSecurityService();
			Bank secureBank = new Bank(secService);

			BankAccount goodAccount = new BankAccount("John Peters", 100);
			BankAccount badAccount = new BankAccount("Shmohn Shmeters", 9999999);

			secService.RegisterAccount(goodAccount);

			secureBank.CreditAccount(goodAccount, 100);
			secureBank.CreditAccount(badAccount, 100);
		}
	}
}
