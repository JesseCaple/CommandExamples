using System;
using System.Collections.Generic;
using System.Text;

namespace CommandExamples
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class CommandAttribute : Attribute
    {
        public string[] Matches {get;}

        public CommandAttribute(params string[] matches)
        {
            Matches = matches;
        }
    }
}
