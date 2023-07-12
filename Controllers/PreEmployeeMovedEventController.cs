using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using WebHookReceiver.Client;

namespace WebHookReceiver.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class preEmployeeMovedEventController : ControllerBase
    {
        private readonly IMessageBusClient _messageBus;

        public preEmployeeMovedEventController(IMessageBusClient messageBus)
        {
            _messageBus = messageBus;
        }
        [HttpPost]
        public ActionResult preEmployeeMovedEventReceive([FromBody] JsonElement jsonData){
            // _messageBus.SendMessage(jsonData);
            Console.WriteLine(jsonData);
            System.Diagnostics.Trace.WriteLine(jsonData);
            return Ok("Recebido.");
        }
    }
}