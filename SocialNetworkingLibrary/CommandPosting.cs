using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SocialNetworkingLibrary
{
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

}