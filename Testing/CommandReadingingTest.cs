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
    class CommandReadingTest
    {
        [Test]
        public void CommandReadingAddPostTest()
        {
            var resultPosts = new List<Post>();
            resultPosts.Add(new Post { UserName = "Alice", Message = "I love the weather today" });
            string consoleInput = "Alice";

            var writerMock = new Mock<IConsoleWriter>();

            var command = new CommandReading(resultPosts, writerMock.Object);
            command.Process(consoleInput);
            writerMock.Verify(t => t.WriteLine(It.Is<Post>(p => p.UserName == "Alice" && p.Message == "I love the weather today")));
        }

        [Test]
        public void CommandPostingAddTwoPostsTest()
        {
            var resultPosts = new List<Post>();
            resultPosts.Add(new Post { UserName = "Alice", Message = "I love the weather today" });
            resultPosts.Add(new Post { UserName = "Bob", Message = "Damn! We lost!" });
            resultPosts.Add(new Post { UserName = "Alice", Message = "two" });

            string consoleInput = "Alice";

            var s = new MockSequence();
            var writerMock = new Mock<IConsoleWriter>();
            writerMock.InSequence(s).Setup(m => m.WriteLine(resultPosts[0]));
            writerMock.InSequence(s).Setup(m => m.WriteLine(resultPosts[2]));

            var command = new CommandReading(resultPosts, writerMock.Object);
            command.Process(consoleInput);

            writerMock.Verify(m => m.WriteLine(resultPosts[0]));
            writerMock.Verify(m => m.WriteLine(resultPosts[2]));
        }
    }
}
