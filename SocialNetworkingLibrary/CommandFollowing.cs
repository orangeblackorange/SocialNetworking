using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SocialNetworkingLibrary
{
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

}