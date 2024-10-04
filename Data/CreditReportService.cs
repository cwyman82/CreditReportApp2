using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CreditReportApp2.Data;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

public interface ICreditReportService
{
    Task<List<CreditReport>> GetCreditReportsAsync();
}
public class CreditReportService : ICreditReportService
{
    private readonly HttpClient _httpClient;

    public CreditReportService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<CreditReport>> GetCreditReportsAsync()
    {
        // Fetch the data from the JSON file in wwwroot/data
        return await _httpClient.GetFromJsonAsync<List<CreditReport>>("data/creditReports.json");
    }
}


