using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OneInc.Server.Model;
using OneInc.Server.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneInc.Server.Services.Tests
{
    [TestClass()]
    public class DelayServiceTests
    {

        [TestMethod()]
        [DataRow(1, 5)]
        [DataRow(1, 3)]
        public async Task DelayTest_DelayIsWithBorder_WithinRange(int min, int max)
        {
            //arrange
            var options = Options.Create(new DelayRange (min, max));
            var servive = new DelayService(options);
            var token = new CancellationToken();
            Stopwatch stopwatch = Stopwatch.StartNew();

            //act
            await servive.Delay(token);
            stopwatch.Stop();
            //assert
            Assert.IsTrue(stopwatch.Elapsed.Seconds < max);
            Assert.IsTrue(stopwatch.Elapsed.Seconds >= min);
        }

        [TestMethod()]
        [DataRow(0, 0)]
        [DataRow(1, 1)]
        [DataRow(2, 2)]
        [DataRow(3, 3)]
        [DataRow(4, 4)]
        public async Task DelayTest_DelayForEqualBorders_EqualToBorder(int min, int max)
        {
            //arrange
            var options = Options.Create(new DelayRange(min, max));
            var servive = new DelayService(options);
            var token = new CancellationToken();
            Stopwatch stopwatch = Stopwatch.StartNew();

            //act
            await servive.Delay(token);
            stopwatch.Stop();
            //assert
            Assert.IsTrue(stopwatch.Elapsed.Seconds == max);
            Assert.IsTrue(stopwatch.Elapsed.Seconds == min);
        }
        
        [TestMethod()]
        [DataRow(5, 1)]
        [DataRow(-1, 1)]
        public void DelayTest_InvalidInput(int min, int max)
        {
            //arrange
            var options = Options.Create(new DelayRange(min, max));
            var servive = new DelayService(options);
            var token = new CancellationToken();

            //assert
            Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(
                //act
                async () => await servive.Delay(token));

        }
    }
}