using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkingLibrary
{

    public interface ITimeFormatter
    {
        string Format(DateTime timeInput, DateTime timeNow);
    }



    public class PrettyTimeFormatter : ITimeFormatter
    {
        public string Format(DateTime timeInput, DateTime timeNow)
        {
            string unit = "seconds";

            int seconds = (int)(timeNow - timeInput).TotalSeconds;
            var result = string.Format("({0} {1} ago)", seconds, unit);
            if (seconds > 60)
            {
                int minutes = (int)(timeNow - timeInput).TotalMinutes;
                unit = "minutes";
                result = string.Format("({0} {1} ago)", minutes, unit);
            }

            return result;
        }

    }
}
