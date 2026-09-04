using System.Net.Http.Json;
using Utilities.Models;

namespace Utilities.Clients;

public class IdentityClient : IIdentityClient
{
    private readonly HttpClient httpClient;


    public IdentityClient(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }


    public async Task<UserDto?> GetUser(Guid id)
    {
        var response = await httpClient.GetAsync(
            $"/api/users/{id}"
        );


        if (!response.IsSuccessStatusCode)
        {
            return null;
        }


        return await response.Content
            .ReadFromJsonAsync<UserDto>();
    }
}