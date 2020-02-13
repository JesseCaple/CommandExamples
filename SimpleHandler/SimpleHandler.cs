using System;
using System.Collections.Generic;
using System.Text;

namespace CommandExamples
{
    public class SimpleHandler
    {
        public void Handle(string command)
        {
            command = command.ToUpper();
            if (command == ".A")
            {
                Console.WriteLine("Simple: A!");
            }
            else if (command == ".B" || command == ".C")
            {
                Console.WriteLine("Simple: B!");
            }
        }
    }
}
