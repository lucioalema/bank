using System;
using Bank.Loans.Domain.Loans;
using Xunit;
using Moq;

namespace Bank.Loans.Domain.Test.Loans
{
    public class LoanTest
    {
        [Theory]
        [InlineData(500000, 120, Status.Draft)]
        public void Create_ReturnsLoan(decimal amount, int duration, Status status)
        {
            //Arrange
            var rate = new Rates.Rate(5);
            var fee = new Fees.Fee("1% or 10000 kr", 1m, 10000m);
            //Act
            var loan = Loan.Create(amount, duration, status, rate, fee);
            //Assert
            Assert.NotEqual(Guid.Empty, loan.Id);
        }
    }
}
