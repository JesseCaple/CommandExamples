using System;
using System.Collections.Generic;
using System.Text;

namespace CommandExamples
{
    interface CommandInterface
    {
        public string[] Handles { get; }

        public void Run();

    }
}
