using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkingLibrary
{
    public interface IConsoleWriter
    {
        string WriteLine(string line);
        string WriteLine(Post post);
    }

    public interface ITextWriter
    {
        string WriteLine(string line);
    }

    public class TextWriterWrapper: ITextWriter
    {
        private System.IO.TextWriter textWriter;
        public TextWriterWrapper(System.IO.TextWriter textWriter)
        {
            this.textWriter = textWriter;
        }
    
        public string WriteLine(string line)
        {
            this.textWriter.WriteLine(line);
            return line;
        }
    }

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
            var result = string.Format("{0} -> {1} {2}", post.UserName, post.Message, formater.Format(post.When));
            this.writer.WriteLine(result);
            return result.Trim();
        }
    }
}

