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
    }
}

//capture input
//Process input
//    Posting: Add to the list(post{ whom, message, time})
//	  reading: fetch posts from list by whom
//    following: for this username add a following. Extend object (post{whom, message, time, following})
//	  wall: fetch posts from list by whom and then "following" list
