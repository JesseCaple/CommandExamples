using System;
using System.Collections.Generic;
using System.Text;

namespace CommandExamples
{
    class CommandB : CommandInterface
    {
        public string[] Handles => new string[] { ".B", ".C" };

        public void Run()
        {
            Console.WriteLine("Interface: B!");
        }
    }
}
