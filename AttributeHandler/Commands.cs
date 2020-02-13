using System;
using System.Collections.Generic;
using System.Text;

namespace CommandExamples
{
    public class Commands
    {
        [CommandAttribute(".A")]
        public void commandA()
        {
            Console.WriteLine("Attribute: A!");
        }

        [CommandAttribute(".B", ".C")]
        public void commandB()
        {
            Console.WriteLine("Attribute: B!");
        }
    }
}
