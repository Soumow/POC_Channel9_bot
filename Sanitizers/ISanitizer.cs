using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC_Channel9_bot.Sanitizers
{
    interface ISanitizer
    {
        string Sanitize(string message);
    }
}
