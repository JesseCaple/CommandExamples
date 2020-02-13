using System;
using System.Collections.Generic;
using System.Text;

namespace CommandExamples
{
    class CommandA : CommandInterface
    {
        public string[] Handles => new string[] { ".A" };

        public void Run()
        {
            Console.WriteLine("Interface: A!");
        }
    }
}
