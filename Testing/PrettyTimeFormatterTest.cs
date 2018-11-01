using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SocialNetworkingLibrary;

namespace Testing
{
    [TestFixture]
    class PrettyTimeFormatterTest
    {
        [Test]
        public void FormatForSecondsTest()
        {
            var timeNow = new DateTime(1998, 04, 30, 0, 0, 5);
            var timeInput = new DateTime(1998, 04, 30, 0, 0, 0);
            var context = new PrettyTimeFormatter(timeNow);
            var result = context.Format(timeInput);
            
            Assert.AreEqual("(5 seconds ago)", result);
        }

        [Test]
        public void FormatForMinutesTest()
        {
            var timeNow = new DateTime(1998, 04, 30, 0, 3, 0);
            var timeInput = new DateTime(1998, 04, 30, 0, 0, 0);
            var context = new PrettyTimeFormatter(timeNow);
            var result = context.Format(timeInput);

            Assert.AreEqual("(3 minutes ago)", result);
        }
    }
}
