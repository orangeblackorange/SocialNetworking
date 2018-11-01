using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SocialNetworkingLibrary
{
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

}