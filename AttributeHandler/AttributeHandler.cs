using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandExamples
{
    public class AttributeHandler
    {
        private List<Object> instances;
        private Dictionary<string, Action> actions;

        public AttributeHandler()
        {
            instances = new List<Object>();
            actions = new Dictionary<string, Action>();
            var types = from type in Assembly.GetExecutingAssembly().GetTypes()
                        where type.IsClass 
                              && !type.IsAbstract 
                              && type.GetMethods().Any(
                                  m => m.GetCustomAttributes<CommandAttribute>().Any())
                              && type.GetConstructor(Type.EmptyTypes) != null
                        select type;
            foreach (var type in types)
            {
                var instance = (Object) Activator.CreateInstance(type);
                var methods = from method in type.GetMethods()
                              where method.GetCustomAttributes<CommandAttribute>().Any()
                                    && method.GetParameters().Length == 0
                                    && method.ReturnType == typeof(void)
                              select method;
                foreach (var method in methods)
                {
                    var action = (Action) method.CreateDelegate(typeof(Action), instance);
                    var attribute = method.GetCustomAttribute<CommandAttribute>();
                    foreach(var match in attribute.Matches)
                    {
                        actions.Add(match, action);
                    }
                }
                instances.Add(instance);
            }
        }

        public void Handle(string command)
        {
            actions.TryGetValue(command.ToUpper(), out Action action);
            action?.Invoke();
        }
    }
}
