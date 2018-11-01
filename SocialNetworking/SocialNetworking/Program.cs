using SocialNetworkingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworking
{
    class Program
    {
        static void Main(string[] args)
        {
            var posts = new List<Post>();
            var followers = new Dictionary<string, List<string>>();

            var writer = new ConsoleWriter(new TextWriterWrapper(Console.Out), new PrettyTimeFormatter(DateTime.Now) );

            var commands = new List<ICommand>
            {
                new CommandPosting(posts),
                new CommandReading(posts, writer),
                new CommandFollowing(followers),
                new CommandWall(posts, followers, writer)
            };

            var service = new SocialNetworkingService(commands);
            while (true)
            {
                var line = Console.ReadLine();
                service.Process(line);
            }

        }
    }
}
