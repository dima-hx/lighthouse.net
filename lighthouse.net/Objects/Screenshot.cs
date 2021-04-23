using System;
using System.Collections.Generic;
using System.Text;

namespace lighthouse.net.Objects
{
    public struct Screenshot
    {
        public Screenshot(string data)
        {
            this.Base64Data = data;
        }
        public string Base64Data {get; }
    }
}
