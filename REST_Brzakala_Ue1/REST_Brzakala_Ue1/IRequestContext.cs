using System;
using System.IO;
using System.Collections.Generic;


namespace REST_BRZAKALA_UE1
{
    public interface IRequestContext
    {
        string Method { get; }

        string Url { get; }

        string Version { get; }

        string ContentStr { get; }

        Dictionary<string, string> RequestBody { get; }

    }
}
