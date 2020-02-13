using System;

namespace CommandExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var simpleHandler = new SimpleHandler();
            var registrationHandler = new RegistrationHandler();
            registrationHandler.Register(".A", "Register: A!");
            registrationHandler.Register(".B", "Register: B!");
            registrationHandler.Register(".C", "Register: B!");
            var delegateHandler = new DelegateHandler();
            var interfaceHandler = new InterfaceHandler();
            var attributeHandler = new AttributeHandler();
            string command = ".C";
            simpleHandler.Handle(command);
            registrationHandler.Handle(command);
            delegateHandler.Handle(command);
            interfaceHandler.Handle(command);
            attributeHandler.Handle(command);
        }
    }
}
