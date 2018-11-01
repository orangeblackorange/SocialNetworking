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
    class CommandWallTest
    {
        [Test]
        public void CommandWallNoFollowersTest()
        {
            var resultPosts = new List<Post>();
            resultPosts.Add(new Post { UserName = "Bob", Message = "Good game though." });
            resultPosts.Add(new Post { UserName = "Charlie", Message = "I'm in New York today! Anyone wants to have a coffee?" });
            resultPosts.Add(new Post { UserName = "Bob", Message = "Damn!We lost!" });

            var following = new Dictionary<string, List<string>>();

            string consoleInput = "Bob wall";

            var writerMock = new Mock<IConsoleWriter>();

            var command = new CommandWall(resultPosts, following, writerMock.Object);
            command.Process(consoleInput);

            writerMock.Verify(m => m.WriteLine(resultPosts[0]));
            writerMock.Verify(m => m.WriteLine(resultPosts[2]));
        }

        [Test]
        public void CommandWallWithFollowerTest()
        {
            var resultPosts = new List<Post>();
            resultPosts.Add(new Post { UserName = "Bob", Message = "Good game though." });
            resultPosts.Add(new Post { UserName = "Charlie", Message = "I'm in New York today! Anyone wants to have a coffee?" });
            resultPosts.Add(new Post { UserName = "Bob", Message = "Damn!We lost!" });

            var following = new Dictionary<string, List<string>>();
            var list = new List<string>();
            list.Add("Charlie");

            following.Add("Bob", list);

            string consoleInput = "Bob wall";

            var writerMock = new Mock<IConsoleWriter>();

            var command = new CommandWall(resultPosts, following, writerMock.Object);
            command.Process(consoleInput);

            writerMock.Verify(m => m.WriteLine(resultPosts[0]));
            writerMock.Verify(m => m.WriteLine(resultPosts[2]));
            writerMock.Verify(m => m.WriteLine(resultPosts[1]));
        }
    }
}
