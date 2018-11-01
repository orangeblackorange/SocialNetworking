using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SocialNetworkingLibrary
{
    public class SocialNetworkingService
    {

        private List<ICommand> commands;

        public SocialNetworkingService(List<ICommand> commands)
        {
            this.commands = commands;
        }

        public void Process(string input)
        {
            foreach (var command in commands)
            {
                command.Process(input);
            }
        }

    }

    public interface ICommand
    {
        void Process(string input);
    }



    public class CommandPosting : ICommand
    {
        List<Post> posts = null;
        public CommandPosting(List<Post> posts)
        {
            this.posts = posts;
        }

        public void Process(string input)
        {
            var matchResult = Regex.Match(input, @"(?<username>\w+) -> (?<message>([\w\s\p{P}]*))");
            if (matchResult.Success)
            {
                var username = matchResult.Groups["username"].Value;
                var message = matchResult.Groups["message"].Value;
                posts.Add(new Post { UserName = username, Message = message, When = DateTime.Now });
            }
        }
    }


    public class CommandReading : ICommand
    {
        List<Post> posts = null;
        IConsoleWriter writer = null;
        public CommandReading (List<Post> posts, IConsoleWriter writer)
        {
            this.posts = posts;
            this.writer = writer;
        }

        public void Process(string input)
        {
            var matchReadingResult = Regex.Match(input, @"^(?<username>\w+)$");
            if (matchReadingResult.Success)
            {
                var username = matchReadingResult.Groups["username"].Value;
                var found = this.posts.FindAll(p => p.UserName.Equals(username));

                foreach (var post in found)
                {
                    writer.WriteLine(post);
                }
            }
        }
    }

    public class CommandFollowing : ICommand
    {
        private Dictionary<string, List<string>> followers = null;
        public CommandFollowing(Dictionary<string, List<string>> followers )
        {
            this.followers = followers;
        }

        public void Process(string input)
        {
            var matchFollowingResult = Regex.Match(input, @"(?<firstusername>\w+) follows (?<secondusername>\w+)");
            if (matchFollowingResult.Success)
            {
                var username1 = matchFollowingResult.Groups["firstusername"].Value;
                var username2 = matchFollowingResult.Groups["secondusername"].Value;

                if (followers.ContainsKey(username1))
                {
                    followers[username1].Add(username2);
                }
                else
                {
                    var list = new List<string>();
                    list.Add(username2);
                    followers.Add(username1, list);
                }
            }

        }
    }

    public class CommandWall : ICommand
    {
        List<Post> posts = null;
        IConsoleWriter writer = null;
        private Dictionary<string, List<string>> followers = null;
        public CommandWall(List<Post> posts, Dictionary<string, List<string>> followers, IConsoleWriter writer)
        {
            this.posts = posts;
            this.writer = writer;
            this.followers = followers;
        }

        public void Process(string input)
        {

            var matchWallResult = Regex.Match(input, @"(?<username>\w+) wall");
            if (matchWallResult.Success)
            {
                var username = matchWallResult.Groups["username"].Value;
                WriteAllFoundPosts(username);

                if (followers.ContainsKey(username))
                {
                    var foundFollowers = followers[username];

                    foreach (var follower in foundFollowers)
                    {
                        WriteAllFoundPosts(follower);
                    }
                }

            }
        }

        private void WriteAllFoundPosts(string username)
        {
            var found = posts.FindAll(p => p.UserName.Equals(username));

            foreach (var post in found)
            {
                writer.WriteLine(post);
            }
        }
    }

    public class Post
    {
        public String UserName { get; set; }
        public String Message { get; set; }
        public DateTime When { get; set; }
    }

}