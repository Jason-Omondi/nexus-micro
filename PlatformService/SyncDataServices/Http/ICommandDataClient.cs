namespace PlatformService.DTOs
{
    public interface ICommandDataClient 
    {
        Task SendPlatformToCommand(PlatformReadDto plat);
    }
}