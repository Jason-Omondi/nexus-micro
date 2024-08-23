using PlatformService.DTOs;

namespace PlatformService.SyncDataServices.Http
{
    public class HttpCommandDataClient : ICommandDataClient 
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public HttpCommandDataClient(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task SendPlatformToCommand(PlatformReadDto plat)
        {
            var httpContent = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(plat),
                System.Text.Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync($"{_config["CommandsService"]}/api/c/platforms", httpContent);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Sync Post to Command Service was Ok!");
            } else 
            {
                Console.WriteLine("--> Sync Post to Command Service was NOT Ok!");
            }
        }
    }
}