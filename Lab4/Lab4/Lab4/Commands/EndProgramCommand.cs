﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Commands
{
    internal class EndProgramCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Program ended");
        }
    }
}
