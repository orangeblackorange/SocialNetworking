using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkingLibrary
{
    public class PrettyTimeFormatter
    {
        private DateTime referenceTime;
        public PrettyTimeFormatter(DateTime referenceTime)
        {
            this.referenceTime = referenceTime;
        }

        public string Format(DateTime timeInput)
        {
            string unit = "seconds";

            var seconds = (referenceTime - timeInput).TotalSeconds;
            var result = string.Format("({0} {1} ago)", seconds, unit);
            if (seconds > 60)
            {
                var minutes = (referenceTime - timeInput).TotalMinutes;
                unit = "minutes";
                result = string.Format("({0} {1} ago)", minutes, unit);
            }

            return result;
        }

    }
}
