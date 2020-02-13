using System;
using System.Collections.Generic;
using System.Text;

namespace CommandExamples
{
    public class RegistrationHandler
    {

        Dictionary<string, string> commands = new Dictionary<string, string>();

        public void Register(string command, string result)
        {
            commands.Add(command.ToUpper(), result);
        }

        public void Handle(string command)
        {
            commands.TryGetValue(command.ToUpper(), out string result);
            if (result != null)
            {
                Console.WriteLine(result);
            }
        }
    }
}
