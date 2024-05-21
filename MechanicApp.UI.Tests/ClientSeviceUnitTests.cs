using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MechanicApp.Shared;
using Moq;
using Xunit;
using MechanicApp.UI.Services; // Replace with the actual namespace where ClientService is defined

namespace MechanicApp.UI.Tests // Replace with your test project's namespace
{
    public class ClientServiceTests
    {
        [Fact]
        public async Task AddClientAsync_ShouldSendHttpPost()
        {
            // Arrange
            var httpClientMock = new Mock<HttpClient>();
            var clientService = new ClientService(httpClientMock.Object); // Inject the mock HttpClient

            var clientToAdd = new Client { ClientId = new Guid(), Name = "ExampleName", Address = "26 Street Debrecen", Email = "example@example.com" };

            // Act
            await clientService.AddClientAsync(clientToAdd);
            
            var response = await clientService.GetClientAsync(clientToAdd.ClientId);
            Assert.Equal(clientToAdd, response);
        }
    }
}