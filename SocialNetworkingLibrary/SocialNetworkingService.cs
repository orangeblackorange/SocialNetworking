using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkingLibrary
{
    public class SocialNetworkingService
    {

        private List<ICommand> commands;

        public SocialNetworkingService(List<ICommand> commands)
        {
            this.commands = commands;
        }

        public void Process(string input)
        {
            foreach (var command in commands)
            {
                command.Process(input);
            }
        }

    }

}