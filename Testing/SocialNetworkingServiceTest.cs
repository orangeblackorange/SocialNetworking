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
            string consoleInput = "Alice -> I love the weather today";

            var service = new SocialNetworkingService();
            var post = service.Process(consoleInput);

            Assert.AreEqual("Alice", post.UserName);
            Assert.AreEqual("I love the weather today", post.Message);
        }

        [Test]
        public void AddTwoPostsTest()
        {
            string consoleInput1 = "Alice -> I love the weather today";
            string consoleInput2 = "Charlie -> I'm in New York today! Anyone wants to have a coffee?";

            var service = new SocialNetworkingService();
            var post1 = service.Process(consoleInput1);
            var post2 = service.Process(consoleInput2);

            Assert.AreEqual("Alice", post1.UserName);
            Assert.AreEqual("I love the weather today", post1.Message);

            Assert.AreEqual("Charlie", post2.UserName);
            Assert.AreEqual("I'm in New York today! Anyone wants to have a coffee?", post2.Message);
        }
    }
}

//capture input
//Process input
//    Posting: Add to the list(post{ whom, message, time})
//	  reading: fetch posts from list by whom
//    following: for this username add a following. Extend object (post{whom, message, time, following})
//	  wall: fetch posts from list by whom and then "following" list
