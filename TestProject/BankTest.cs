using AutoFixture;


using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestLearningApp;
using Moq;


namespace TestProject
{
	[TestClass]
	public class BankTest
	{

		IFixture fixture;

		Mock<ISecurityService> securityServiceMock;
		Bank bankUnderTest;


		[TestInitialize]
		public void Setup()
		{
			fixture = new Fixture();
			securityServiceMock = new Mock<ISecurityService>();
			bankUnderTest = new Bank(securityServiceMock.Object);
		}

		[TestMethod]
		public void DebitAccount_WithRegisteredAccount_Succeeds()
		{
			// Arrange
			securityServiceMock.Setup(x => x.VerifyAccount(It.IsAny<BankAccount>())).Returns(true);

			double beginningAmount = 200;
			double debitAmount = 99;
			double expected = 101;
			
			// note - I want to create this using autofixture or moq but can't find a good way to do
			// that with readonly properties (balance)
			var account = new BankAccount(fixture.Create<string>(), beginningAmount);

			// Act
			bankUnderTest.DebitAccount(account, debitAmount);

			// Assert
			double actual = account.Balance;
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void DebitAccount_WithUnregisteredAccount_Fails()
		{
			// Arrange
			securityServiceMock.Setup(x => x.VerifyAccount(It.IsAny<BankAccount>())).Returns(false);

			var account = fixture.Create<BankAccount>();

			// Act
			try
			{
				bankUnderTest.DebitAccount(account, fixture.Create<double>());
			}
			catch (System.Exception e)
			{
				// Assert
				Assert.IsInstanceOfType(e, typeof(System.ArgumentException));
				StringAssert.Contains(e.Message, Bank.UnregisteredAccountErrorMessage);
				return;
			}
			Assert.Fail("Expected exception not thrown.");
		}

		[TestMethod]
		public void CreditAccount_WithRegisteredAccount_Succeeds()
		{
			// Arrange
			securityServiceMock.Setup(x => x.VerifyAccount(It.IsAny<BankAccount>())).Returns(true);

			double beginningAmount = 200;
			double creditAmount = 11;
			double expected = 211;
			var account = new BankAccount(fixture.Create<string>(), beginningAmount);


			// Act
			bankUnderTest.CreditAccount(account, creditAmount);

			// Assert
			double actual = account.Balance;
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void CreditAccount_WithUnregisteredAccount_Fails()
		{
			// Arrange
			securityServiceMock.Setup(x => x.VerifyAccount(It.IsAny<BankAccount>())).Returns(false);

			var account = fixture.Create<BankAccount>();

			// Act
			try
			{
				bankUnderTest.CreditAccount(account, fixture.Create<double>());
			}
			catch (System.Exception e)
			{
				// Assert
				Assert.IsInstanceOfType(e, typeof(System.ArgumentException));
				StringAssert.Contains(e.Message, Bank.UnregisteredAccountErrorMessage);
				return;
			}
			Assert.Fail("Expected exception not thrown.");

		}
	}
}
