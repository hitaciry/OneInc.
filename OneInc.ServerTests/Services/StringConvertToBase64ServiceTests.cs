using Microsoft.VisualStudio.TestTools.UnitTesting;
using OneInc.Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneInc.Server.Services.Tests
{
    [TestClass()]
    public class StringConvertToBase64ServiceTests
    {
        [TestMethod()]
        [DataRow("Hello, World!", "SGVsbG8sIFdvcmxkIQ==")]
        [DataRow("", "")]
        public void ConvertTest_(string input, string expectedResult)
        {
            //arrange
            var service = new StringConvertToBase64Service();

            //act
            var result = service.Convert(input);

            //assert
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod()]
        [DataRow(null)]
        public void ConvertTest_NullInput_ArgumentNullException(string input)
        {
            //arrange
            var service = new StringConvertToBase64Service();

            //assert
            Assert.ThrowsException<ArgumentNullException>(
                //act
                () => service.Convert(input));
        }
    }
}