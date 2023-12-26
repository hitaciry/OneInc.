using Microsoft.AspNetCore.SignalR;
using OneInc.Server.Services;

namespace OneInc.Server.Hubs
{
    public class StringConverterHub: Hub
    {
        private readonly IDelayService delayService;
        private readonly IStringConvertService<string> stringConvertService;

        public StringConverterHub(IDelayService delayService, IStringConvertService<string> stringConvertService)
        {
            this.delayService = delayService;
            this.stringConvertService = stringConvertService;
        }
        public async Task ConvertToBase64(string input)
        {
            var token = Context.ConnectionAborted;
            var base64String = stringConvertService.Convert(input);
            foreach (var charecter in base64String)
            {
                await delayService.Delay(token);
                await Clients.Caller.SendAsync("ReceiveCharacter", charecter.ToString(), token);
            }
            await Clients.Caller.SendAsync("EncodingComplite", token);
        }
    }
}
