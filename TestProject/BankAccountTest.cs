using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestLearningApp;

namespace TestProject
{
	[TestClass]
	public class BankAccountTest
	{
		[TestMethod]
		public void Debit_WithValidAmount_UpdatesBalance()
		{
			// Arrange
			double beginningBalance = 11.99;
			double debitAmount = 4.55;
			double expected = 7.44;
			BankAccount account = new BankAccount("Testman", beginningBalance);

			// Act
			account.Debit(debitAmount);

			// Assert
			double actual = account.Balance;
			Assert.AreEqual(expected, actual, .001, "Account debited wrong");

		}

		[TestMethod]
		public void Debit_WithAmountLessThanZero_ThrowsArgumentOutOfRangeException()
		{
			// Arrange
			double beginningBalance = 10;
			double debitAmount = -4;
			BankAccount account = new BankAccount("Testwoman", beginningBalance);

			// Act & Assert
			try
			{
				account.Debit(debitAmount);
			}
			catch(System.Exception e)
			{
				StringAssert.Contains(e.Message, BankAccount.AmountLessThanZeroErrorMessage);
				return;
			}
			Assert.Fail("Expected exception not thrown.");
		}

		[TestMethod]
		public void Debit_WithAmountGreaterThanBalance_ThrowsArgumentOutOfRangeException()
		{
			// Arrange
			double beginningBalance = 10;
			double debitAmount = 40;
			BankAccount account = new BankAccount("Testboy", beginningBalance);

			// Act & Assert
			try
			{
				account.Debit(debitAmount);
			}
			catch (System.Exception e)
			{
				StringAssert.Contains(e.Message, BankAccount.AmountGreaterThanBalanceErrorMessage);
				return;
			}
			Assert.Fail("Expected exception not thrown.");
		}

		[TestMethod]
		public void Credit_WithAmountLessThanZero_ThrowsArgumentOutOfRangeException()
		{
			// Arrange
			double beginningBalance = 10;
			double debitAmount = -4;
			BankAccount account = new BankAccount("Tester", beginningBalance);

			// Act & Assert
			try
			{
				account.Debit(debitAmount);
			}
			catch (System.Exception e)
			{
				StringAssert.Contains(e.Message, BankAccount.AmountLessThanZeroErrorMessage);
				return;
			}
			Assert.Fail("Expected exception not thrown.");
		}
	}
}
