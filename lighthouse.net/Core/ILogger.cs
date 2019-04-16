using System;
using System.Collections.Generic;
using System.Text;

namespace lighthouse.net.Core
{
    internal interface ILogger
    {
        bool Append(string content);
    }
}
