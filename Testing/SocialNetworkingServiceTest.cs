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
    public class SocialNetworkingServiceTest
    {
        [Test]
        public void AddPostTest()
        {
            var resultPosts = new List<Post>();
            string consoleInput = "Alice -> I love the weather today";

            var service = new SocialNetworkingService(resultPosts, new MockConsoleWriter());
            service.Process(consoleInput);

            Assert.AreEqual(1, resultPosts.Count);
            Assert.AreEqual("Alice", resultPosts[0].UserName);
            Assert.AreEqual("I love the weather today", resultPosts[0].Message);
            //Assert.AreEqual("(5 seconds ago)", resultPosts[0].When);
        }

        [Test]
        public void AddTwoPostsTest()
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


        //[Test]
        //public void ReadingTimelineOnePostTest()
        //{
        //    var resultPosts = new List<Post>();
        //    string consoleInput = "Alice -> I love the weather today";

        //    var timeNow = new DateTime(1998, 04, 30, 0, 3, 0);
        //    var formatter = new PrettyTimeFormatter(timeNow);
        //    var writter = new ConsoleWriter(new MockConsoleWriter(), formatter);


        //    var service = new SocialNetworkingService(resultPosts, writter);
        //    service.Process(consoleInput);
        //    service.Process("Alice");

        //    Assert.AreEqual("I love the weather today (5 minutes ago)", resultPosts.Message);
        //}
    }


    public class MockConsoleWriter : IConsoleWriter
    {
        public string WriteLine(string line)
        {
            return null;
        }

        public string WriteLine(Post post)
        {
            return null;
        }
    }
}

//capture input
//Process input
//    Posting: Add to the list(post{ whom, message, time})
//	  reading: fetch posts from list by whom
//    following: for this username add a following. Extend object (post{whom, message, time, following})
//	  wall: fetch posts from list by whom and then "following" list
