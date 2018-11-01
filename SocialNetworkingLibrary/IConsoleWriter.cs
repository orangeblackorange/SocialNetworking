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
}

