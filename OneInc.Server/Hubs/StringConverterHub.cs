using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OneInc.Server.Services;
using System.Threading;

namespace OneInc.Server.Hubs
{
    public class StringConverterHub: Hub
    {
        private readonly IDelayService delayService;

        public StringConverterHub(IDelayService delayService)
        {
            this.delayService = delayService;
        }
        public async Task ConvertToBase64(string input, CancellationToken token, [FromServices] IStringConvertService<string> stringConvertService)
        {
            var base64String = stringConvertService.Convert(input);
            foreach (var charecter in base64String)
            {
                token.ThrowIfCancellationRequested();
                await delayService.Delay(token);
                await Clients.Caller.SendCoreAsync("Response", new object[] { charecter }, token);
            }
        }
    }
}
