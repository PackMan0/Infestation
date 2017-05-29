namespace Infestation.Providers
{
    using System;

    public class ConsoleProvider: IInputOutputProvider
    {
        public void Write(string output)
        {
            Console.WriteLine(output);
        }

        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
