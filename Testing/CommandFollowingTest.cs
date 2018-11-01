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
    class CommandFollowingTest
    {
        [Test]
        public void CommandFollowingTestAddPostTest()
        {
            var resultPosts = new List<Post>();
            string consoleInput = "Charlie follows Alice";

            var followers = new Dictionary<string, List<string>>();
            var command = new CommandFollowing(followers);
            command.Process(consoleInput);

            Assert.AreEqual(1, followers.Count);
            Assert.AreEqual(1, followers["Charlie"].Count);
            Assert.AreEqual("Alice", followers["Charlie"][0]);
        }
    }
}
