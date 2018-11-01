using System;

namespace SocialNetworkingLibrary
{
    public interface ITimeFormatter
    {
        string Format(DateTime timeInput, DateTime timeNow);
    }
}
