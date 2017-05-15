using POC_Channel9_bot.VideoData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC_Channel9_bot.Commands
{
    public interface ICommand
    {
        ResponseOption CanbeHandledbyMe(string text);

        string BuildAnswer(string question);
    }
}
