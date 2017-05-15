using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace POC_Channel9_bot.Sanitizers
{
    public class EscapeSanitizer : ISanitizer
    {
        public string Sanitize(string message)
        {
            return Regex.Escape(message);
        }
    }
}