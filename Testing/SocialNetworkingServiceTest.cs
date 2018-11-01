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

            var service = new SocialNetworkingService(resultPosts);
            service.Process(consoleInput);

            Assert.AreEqual(1, resultPosts.Count);
            Assert.AreEqual("Alice", resultPosts[0].UserName);
            Assert.AreEqual("I love the weather today", resultPosts[0].Message);
        }

        [Test]
        public void AddTwoPostsTest()
        {
            var resultPosts = new List<Post>();
            string consoleInput1 = "Alice -> I love the weather today";
            string consoleInput2 = "Charlie -> I'm in New York today! Anyone wants to have a coffee?";

            var service = new SocialNetworkingService(resultPosts);
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

//capture input
//Process input
//    Posting: Add to the list(post{ whom, message, time})
//	  reading: fetch posts from list by whom
//    following: for this username add a following. Extend object (post{whom, message, time, following})
//	  wall: fetch posts from list by whom and then "following" list
