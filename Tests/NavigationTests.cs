//using Bunit;
//using Microsoft.Extensions.DependencyInjection;
//using Xunit;
//using CreditReportApp2.Pages;
//using Microsoft.AspNetCore.Components;
//using CreditReportApp2.Components;
//using MudBlazor;
//using Moq;
//using CreditReportApp2.Data;
//using Bunit.TestDoubles; // You can use Moq to create a mock of the CreditReportService if needed

//public class NavigationTests : TestContext
//{
//    [Fact]
//    public void Test_NavigationToDetailView_AndBack()
//    {
//        // Arrange: Mock the CreditReportService and set up the required data
//        var mockCreditReportService = new Mock<CreditReportService>(/* Mock constructor parameters if needed */);
//        mockCreditReportService.Setup(s => s.GetCreditReportsAsync())
//            .ReturnsAsync(new List<CreditReport>
//            {
//                new CreditReport { CustomerID = "1", FirstName = "Homer", LastName = "Simpson", ReportName = "Expirian", CreditScore = 700 }
//            });


//        // Register the mock service in the test DI container
//        Services.AddSingleton(mockCreditReportService.Object);
//        //var mockNavigationManager = Services.GetRequiredService<FakeNavigationManager>(); // Use bunit's FakeNavigationManager
//        // Render the component
//        var component = RenderComponent<CreditReportTable>();

//        // Act: Simulate clicking the 'View Details' button by ID
//        component.Find("#viewDetails").Click(); // Find the button using the ID "viewDetails"

//        // Assert: Verify that the user navigated to the detailed view
//        // var mockNavigationManager = Services.GetRequiredService<TestNavigationManager>();
//        var mockNavigationManager = Services.GetRequiredService<FakeNavigationManager>();
//        //var expectedDetailUrl = "http://localhost:5134/credit-report-details/1"; // Adjust according to how your app builds the URL
//        var expectedDetailUrl = "http://localhost/credit-report-details/1"; // Adjust according to how your app builds the URL
//        //var expectedDetailUrl = "/credit-report-details/1"; // Adjust according to how your app builds the URL
//        Assert.Equal(expectedDetailUrl, mockNavigationManager.Uri);

//        // Optionally, you can simulate the back button navigation as well.
//        // mockNavigationManager.NavigateTo("/credit-reports");
//        // Assert.Equal("http://localhost/credit-reports", mockNavigationManager.Uri);
//    }
//}

//using Bunit;
//using Microsoft.Extensions.DependencyInjection;
//using Xunit;
//using CreditReportApp2.Components;
//using CreditReportApp2.Data;
//using Microsoft.AspNetCore.Components;
//using MudBlazor;
//using Moq;
//using System.Collections.Generic;
//using Bunit.TestDoubles;

//public class NavigationTests : TestContext
//{
//    [Fact]
//    public void Test_NavigateToCreditReportDetails_OnButtonClick()
//    {
//        // Arrange: Mock the ICreditReportService
//        var mockCreditReportService = new Mock<ICreditReportService>();
//        mockCreditReportService.Setup(s => s.GetCreditReportsAsync())
//            .ReturnsAsync(new List<CreditReport>
//            {
//                new CreditReport { CustomerID = "1", FirstName = "Homer", LastName = "Simpson", ReportName = "Experian", CreditScore = 700 }
//            });

//        // Register the mock service in the test DI container
//        Services.AddSingleton(mockCreditReportService.Object);

//        // Register FakeNavigationManager to simulate navigation
//        var mockNavigationManager = Services.GetRequiredService<FakeNavigationManager>();

//        // Render the CreditReportRow component with the generic type argument
//        var report = new CreditReport
//        {
//            CustomerID = "1",
//            FirstName = "Homer",
//            LastName = "Simpson",
//            ReportName = "Experian",
//            CreditScore = 700
//        };

//        var component = RenderComponent<CreditReportRow<CreditReport>>(parameters => parameters
//            .Add(p => p.Report, report)
//            .Add(p => p.OnDetailsClicked, EventCallback.Factory.Create<CreditReport>(this, r => mockNavigationManager.NavigateTo($"/credit-report-details/{r.CustomerID}")))
//        );

//        // Act: Simulate clicking the 'View Details' button
//        component.Find("#viewDetails").Click(); // Find the button using the ID "viewDetails"

//        // Assert: Verify that the user navigated to the correct detailed view
//        var expectedDetailUrl = "http://localhost/credit-report-details/1"; // Adjust according to how your app builds the URL
//        Assert.Equal(expectedDetailUrl, mockNavigationManager.Uri);
//    }
//}

using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using CreditReportApp2.Components;
using CreditReportApp2.Data;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Moq;
using System.Collections.Generic;
using Bunit.TestDoubles;
using Microsoft.JSInterop;


public class NavigationTests : TestContext
{
    [Fact]
    public void Test_NavigateToCreditReportDetails_OnButtonClick()
    {
        // Arrange: Mock the ICreditReportService
        var mockCreditReportService = new Mock<ICreditReportService>();
        mockCreditReportService.Setup(s => s.GetCreditReportsAsync())
            .ReturnsAsync(new List<CreditReport>
            {
                new CreditReport { CustomerID = "1", FirstName = "Homer", LastName = "Simpson", ReportName = "Experian", CreditScore = 700 }
            });

        // Register the mock service in the test DI container
        Services.AddSingleton(mockCreditReportService.Object);

        // Set up JSInterop to handle localStorage calls
        JSInterop.Setup<string>("localStorage.getItem", "creditReport_1").Equals("{\"CustomerID\":\"1\",\"FirstName\":\"Homer\",\"LastName\":\"Simpson\",\"ReportName\":\"Experian\",\"CreditScore\":700}");

        // Register FakeNavigationManager to simulate navigation
        var mockNavigationManager = Services.GetRequiredService<FakeNavigationManager>();

        // Create a mock report
        var report = new CreditReport
        {
            CustomerID = "1",
            FirstName = "Homer",
            LastName = "Simpson",
            ReportName = "Experian",
            CreditScore = 700
        };

        // Render the CreditReportRow component
        var component = RenderComponent<CreditReportRow<CreditReport>>(parameters => parameters
            .Add(p => p.Report, report)
            .Add(p => p.OnDetailsClicked, EventCallback.Factory.Create<CreditReport>(this, r => mockNavigationManager.NavigateTo($"/credit-report-details/{r.CustomerID}")))
        );

        // Act: Simulate clicking the 'View Details' button
        component.Find("#viewDetails .mud-button").Click(); // Find the button using the ID "viewDetails"

        // Assert: Verify that the user navigated to the correct detailed view
        var expectedDetailUrl = "http://localhost/credit-report-details/1"; // Adjust according to how your app builds the URL
        Assert.Equal(expectedDetailUrl, mockNavigationManager.Uri);
    }
}





