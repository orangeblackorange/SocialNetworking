﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SocialNetworkingLibrary;

namespace Testing
{
    [TestFixture]
    class CommandPostingTest
    {
        [Test]
        public void CommandPostingAddPostTest()
        {
            var resultPosts = new List<Post>();
            string consoleInput = "Alice -> I love the weather today";

            var command = new CommandPosting(resultPosts);
            command.Process(consoleInput);

            Assert.AreEqual(1, resultPosts.Count);
            Assert.AreEqual("Alice", resultPosts[0].UserName);
            Assert.AreEqual("I love the weather today", resultPosts[0].Message);
            //Assert.AreEqual("(5 seconds ago)", resultPosts[0].When);
        }

        [Test]
        public void CommandPostingAddTwoPostsTest()
        {
            var resultPosts = new List<Post>();
            string consoleInput1 = "Alice -> I love the weather today";
            string consoleInput2 = "Charlie -> I'm in New York today! Anyone wants to have a coffee?";

            var service = new SocialNetworkingService(resultPosts, new MockConsoleWriter());
            service.Process(consoleInput1);
            service.Process(consoleInput2);

            Assert.AreEqual(2, resultPosts.Count);
            Assert.AreEqual("Alice", resultPosts[0].UserName);
            Assert.AreEqual("I love the weather today", resultPosts[0].Message);

            Assert.AreEqual("Charlie", resultPosts[1].UserName);
            Assert.AreEqual("I'm in New York today! Anyone wants to have a coffee?", resultPosts[1].Message);
        }
    }
}