namespace Infestation.CommandHendlers
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Enums;
    using Providers;

    public class Command : ICommand
    {

        private CommandTypes type;
        private List<string> parameters;
        private readonly IWriter writer;

        public Command(string input, IWriter writer)
        {
            this.Parameters = new List<string>();
            this.writer = writer;
            this.TranslateInput(input);
        }

        public CommandTypes Type
        {
            get
            {
                return this.type;
            }

            private set
            {
                this.type = value;
            }
        }

        public List<string> Parameters
        {
            get
            {
                return this.parameters;
            }

            private set
            {
                this.parameters = value;
            }
        }

        private void TranslateInput(string input)
        {
            var commandParams = input.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);



            if (indexOfFirstSeparator < 0)
            {
                this.Name = input;
                return;
            }

            this.Name = input.Substring(0, indexOfFirstSeparator);

            if (indexOfOpenComment >= 0)
            {
                this.Parameters.Add(input.Substring(indexOfOpenComment + CommentOpenSymbol.Length, indexOfCloseComment - CommentCloseSymbol.Length - indexOfOpenComment));
                input = regex.Replace(input, string.Empty);
            }

            this.Parameters.AddRange(input.Substring(indexOfFirstSeparator + 1).Split(new[] { SplitCommandSymbol }, StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
