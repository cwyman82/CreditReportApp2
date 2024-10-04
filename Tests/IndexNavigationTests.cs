using Bunit;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using CreditReportApp2.Pages; // Assuming Index.razor is in this namespace
using Microsoft.AspNetCore.Components;
using Bunit.TestDoubles;

public class IndexNavigationTests : TestContext
{
    [Fact]
    public void Test_NavigateToCreditReports_OnButtonClick()
    {
        // Arrange: Render the Index component
        var component = RenderComponent<CreditReportApp2.Pages.Index>();

        // Get the mock navigation manager
        var mockNavigationManager = Services.GetRequiredService<FakeNavigationManager>();

        // Act: Find the MudButton and simulate a click
        component.Find("button").Click(); // Clicking the button

        // Assert: Check if the navigation to "/credit-reports" happened
        Assert.Equal("http://localhost/credit-reports", mockNavigationManager.Uri);
    }
}
