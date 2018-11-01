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
    class ConsoleWritterTest
    {
        [Test]
        public void ConsoleWritterForPostTest()
        {

            var post = new Post { UserName = "Alice", Message = "I love the weather today", When = DateTime.Now };

            var consoleWriter = new ConsoleWriter(new MockTextWriter(), new MockTimeFormatter());
            var result = consoleWriter.WriteLine(post);

            Assert.AreEqual("Alice -> I love the weather today", result);
        }

    }

    class MockTextWriter : ITextWriter
    {
        public string WriteLine(string line)
        {
            Assert.AreEqual("it gets here", "it gets here");
            return "";
        }
    }

    class MockTimeFormatter : ITimeFormatter
    {
        public string Format(DateTime timeInput)
        {
            Assert.AreEqual("it gets here", "it gets here");
            return "";
        }

    }

}
