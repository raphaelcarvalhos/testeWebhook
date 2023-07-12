using System.Text.Json;

namespace WebHookReceiver.Client
{
    public interface IMessageBusClient
    {
        void SendMessage(JsonElement jsonData);
    }
}