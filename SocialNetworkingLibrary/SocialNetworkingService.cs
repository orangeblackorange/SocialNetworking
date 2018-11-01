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
        public Post Process(string input)
        {
            Post result = null;

            var matchResult = Regex.Match(input, @"(?<username>\w+) -> (?<message>([\w\s]*))");
            if (matchResult.Success)
            {
                var username = matchResult.Groups["username"].Value;
                var message = matchResult.Groups["message"].Value;
                result = new Post { UserName = username, Message = message };
            }

            return result;
        }
    }

    public class Post
    {
        public String UserName { get; set; }
        public String Message { get; set; }
    }

}
