using System;
using System.IO;
using System.Collections.Generic;

namespace REST_BRZAKALA_UE1
{
    public interface IResponse
    {
        Dictionary<int, string> AllMsg { get; }
        byte[] sendBytes { get; }
        string lastPart { get; }
        int msgCounter { get; }
        string responseMsg { get; }
    }
}
