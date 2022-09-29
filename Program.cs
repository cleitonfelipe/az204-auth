using System.Threading.Tasks;
using Microsoft.Identity.Client;
// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
namespace az204_auth
{
    public static class Program
    {
        private const string _clientId = "cffcbee9-7b9e-41d2-95f7-1a3d38b12aef";
        private const string _tenantId = "020fe8ea-a365-4d05-a118-38b8998b9245";
        public static async Task Main(string[] args)
        {
            string[] scopes = { "user.read" };
            var app = PublicClientApplicationBuilder
            .Create(_clientId)
            .WithAuthority(AzureCloudInstance.AzurePublic, _tenantId)
            .WithRedirectUri("http://localhost")
            .Build();

            AuthenticationResult result = await app.AcquireTokenInteractive(scopes).ExecuteAsync();

            Console.WriteLine($"Token:\t{result.AccessToken}");
        }
    }
}