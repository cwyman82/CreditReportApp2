using Xunit;
using CreditReportApp2.Data;
using System.Collections.Generic;

public class CreditReportTests
{
    [Fact]
    public void Test_CreditReport_Creation()
    {
        // Arrange
        var report = new CreditReport
        {
            CustomerID = "1",
            FirstName = "Homer",
            LastName = "Simpson",
            ReportName = "Expirian",
            CreditScore = 700
        };

        // Act
        var expectedName = "Homer";

        // Assert
        Assert.Equal(expectedName, report.FirstName);
    }
}
