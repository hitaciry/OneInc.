﻿
using Microsoft.Extensions.Options;
using OneInc.Server.Model;

namespace OneInc.Server.Services
{
    public class DelayService : IDelayService
    {
        private readonly DelayRange delayRange;
        private readonly Random rnd;

        public DelayService(IOptions<DelayRange> options)
        {
            this.delayRange = options.Value;
            rnd = new();
        }

        /// <summary>
        /// Delay Task for a random amount of seconds within a range specified in constructor.
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task Delay(CancellationToken token)
        {
            await Delay(delayRange.Min, delayRange.Max, token);
        }

        /// <summary>
        /// Delay Task for a random amount of seconds within a specified range.
        /// </summary>
        /// <param name="minimum">Lowest value in seconds, inluded to the range</param>
        /// <param name="maximum">Highest value in seconds, excluded from the range. The actual result may exceed the maximum value due to additional calculations.</param>
        /// <returns></returns>
        public async Task Delay(int minimum, int maximum, CancellationToken token)
        {            
            int timeToWait = rnd.Next(minimum * 1000, maximum * 1000);
            await Task.Delay(timeToWait, token);
        }
    }
}
