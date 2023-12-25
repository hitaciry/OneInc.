
namespace OneInc.Server.Services
{
    public class DelayService : IDelayService
    {
        /// <summary>
        /// Delay Task for a random amount of seconds within a specified range 
        /// </summary>
        /// <param name="minimum">lowest value, inluded to the range</param>
        /// <param name="maximum">highest value, excluded from the range</param>
        /// <returns></returns>
        public async Task Delay(int minimum, int maximum)
        {
            Random rnd = new Random();
            int timeToWait = rnd.Next(minimum * 1000, maximum * 1000); 
            await Task.Delay(timeToWait); 
        }
    }
}
