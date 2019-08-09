using System;

namespace UnitTestLearningApp
{

	public class BankAccount
	{
		private readonly string m_customerName;
		private double m_balance;

		public const string AmountGreaterThanBalanceErrorMessage = "Error: amount cannot be greater than balance.";
		public const string AmountLessThanZeroErrorMessage = "Error: amount cannot be less than 0.";

		private BankAccount() { }

		public BankAccount(string name, double balance)
		{
			m_customerName = name;
			m_balance = balance;
		}

		public string CustomerName { get { return m_customerName; } }
		public double Balance { get { return m_balance; } }


		public void Debit(double amount)
		{
			if (amount > m_balance)
			{
				throw new ArgumentOutOfRangeException("amount", amount, AmountGreaterThanBalanceErrorMessage);
			}
			if (amount < 0)
			{
				throw new ArgumentOutOfRangeException("amount", amount, AmountLessThanZeroErrorMessage);
			}
			m_balance -= amount;
		}

		public void Credit(double amount)
		{
			if (amount < 0)
			{
				throw new ArgumentOutOfRangeException("amount", amount, AmountLessThanZeroErrorMessage);
			}
			m_balance += amount;
		}
	}
}
