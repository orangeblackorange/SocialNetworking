using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SocialNetworkingLibrary
{
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

}