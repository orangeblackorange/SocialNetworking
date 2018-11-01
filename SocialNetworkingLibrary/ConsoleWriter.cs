using System;

namespace SocialNetworkingLibrary
{
    public class ConsoleWriter : IConsoleWriter
    {
        ITimeFormatter formater = null;

        private ITextWriter writer = null;
        public ConsoleWriter(ITextWriter writer, ITimeFormatter formater)
        {
            this.writer = writer;
            this.formater = formater;
        }

        public string WriteLine(string line)
        {
            this.writer.WriteLine(line);
            return line;
        }

        public string WriteLine(Post post)
        {
            var result = string.Format("{0} -> {1} {2}", post.UserName, post.Message, formater.Format(post.When, DateTime.Now));
            this.writer.WriteLine(result);
            return result.Trim();
        }
    }
}

