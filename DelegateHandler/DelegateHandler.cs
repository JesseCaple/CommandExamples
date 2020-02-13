using System;
using System.Collections.Generic;
using System.Text;

namespace CommandExamples
{
    public class DelegateHandler
    {
        private Dictionary<string, Action> actions;

        public DelegateHandler()
        {
            actions = new Dictionary<string, Action>();
            actions[".A"] = () =>
            {
                Console.WriteLine("Delegate: A!");
            };
            actions[".B"] = BMethod;
            actions[".C"] = BMethod;
        }

        public void Handle(string command)
        {
            actions.TryGetValue(command.ToUpper(), out Action action);
            action?.Invoke();
        }

        private void BMethod()
        {
            Console.WriteLine("Delegate: B!");
        }
    }
}
