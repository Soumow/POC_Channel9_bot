﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC_Channel9_bot.Commands
{
    interface ICommandDetector
    {
        ICommand DetectCommand(string question);
    }
}
