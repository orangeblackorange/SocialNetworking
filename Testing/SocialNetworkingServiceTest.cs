using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SocialNetworkingLibrary;

namespace Testing
{

    [TestFixture]
    public class SocialNetworkingServiceTest
    {
        // posting 
        [Test]
        public void AddPostTest()
        {
            var posts = new List<Post>();
            string consoleInput = "Alice -> I love the weather today";

            var mockConsoleWriter = new Mock<IConsoleWriter>();

            var commands = new List<ICommand>
            {
                new CommandPosting(posts),
                new CommandReading(posts, mockConsoleWriter.Object),
                new CommandFollowing(null),
                new CommandWall(posts, null, mockConsoleWriter.Object)
            };

            var service = new SocialNetworkingService(commands);
            service.Process(consoleInput);

            Assert.AreEqual(1, posts.Count);
            Assert.AreEqual("Alice", posts[0].UserName);
            Assert.AreEqual("I love the weather today", posts[0].Message);
        }

        [Test]
        public void AddTwoPostsTest()
        {
            var posts = new List<Post>();
            string consoleInput1 = "Alice -> I love the weather today";
            string consoleInput2 = "Charlie -> I'm in New York today! Anyone wants to have a coffee?";

            var mockConsoleWriter = new Mock<IConsoleWriter>();

            var commands = new List<ICommand>
            {
                new CommandPosting(posts),
            };


            Dictionary<string, List<string>> followers = null;
            var service = new SocialNetworkingService(commands);
            service.Process(consoleInput1);
            service.Process(consoleInput2);

            Assert.AreEqual(2, posts.Count);
            Assert.AreEqual("Alice", posts[0].UserName);
            Assert.AreEqual("I love the weather today", posts[0].Message);

            Assert.AreEqual("Charlie", posts[1].UserName);
            Assert.AreEqual("I'm in New York today! Anyone wants to have a coffee?", posts[1].Message);
        }

        //Reading
        [Test]
        public void ReadingTest()
        {
            var posts = new List<Post>();
            string consoleInput1 = "Alice -> I love the weather today";
            string consoleInput2 = "Charlie -> I'm in New York today! Anyone wants to have a coffee?";

            var mockConsoleWriter = new Mock<IConsoleWriter>();

            var commands = new List<ICommand>
            {
                new CommandPosting(posts),
                new CommandReading(posts, mockConsoleWriter.Object),
            };


            var service = new SocialNetworkingService(commands);
            service.Process(consoleInput1);
            service.Process(consoleInput2);

            Assert.AreEqual(2, posts.Count);
            Assert.AreEqual("Alice", posts[0].UserName);
            Assert.AreEqual("I love the weather today", posts[0].Message);

            Assert.AreEqual("Charlie", posts[1].UserName);
            Assert.AreEqual("I'm in New York today! Anyone wants to have a coffee?", posts[1].Message);
        }

    }
}

