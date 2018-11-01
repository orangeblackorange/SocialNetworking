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

        private List<Post> posts;
        public SocialNetworkingService(List<Post> posts)
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
                this.posts.Add(new Post { UserName = username, Message = message });
            }
        }
    }

    public class Post
    {
        public String UserName { get; set; }
        public String Message { get; set; }
    }

}
