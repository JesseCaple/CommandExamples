using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandExamples
{
    public class InterfaceHandler
    {
        private Dictionary<string, CommandInterface> interfaces;

        public InterfaceHandler()
        {
            interfaces = new Dictionary<string, CommandInterface>();
            var types = from type in Assembly.GetExecutingAssembly().GetTypes()
                        where type.GetInterfaces().Contains(typeof(CommandInterface))
                              && type.GetConstructor(Type.EmptyTypes) != null
                        select type;
            foreach (var type in types)
            {
                var instance = (CommandInterface) (Object)Activator.CreateInstance(type);
                foreach (var command in instance.Handles)
                {
                    interfaces.Add(command, instance);
                }
            } 
        }

        public void Handle(string command)
        {
            interfaces.TryGetValue(command.ToUpper(), out CommandInterface ci);
            ci?.Run();
        }
    }
}
