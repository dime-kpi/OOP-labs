using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR.Commands
{
    internal class EndProgramCom : ICommand
    {
        public void Execute()
        {

        }

        public void ShowCommand(int i)
        {
            Console.WriteLine($"{i}) End programm");
        }
    }
}
