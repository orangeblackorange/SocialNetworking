namespace SocialNetworkingLibrary
{
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
}

