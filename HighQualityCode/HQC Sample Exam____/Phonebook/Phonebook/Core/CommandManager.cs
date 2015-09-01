namespace Phonebook.Core
{
    using System;
    using System.Linq;

    using System.Text.RegularExpressions;

    using Phonebook.Data;
    using Phonebook.Interfaces;
    using Phonebook.Models;

    public class CommandManager
    {
        private const string Code = "+359";

        private const string ReplacePattern = @"[^\+,\da-zA-Z]+";

        private const string DoubleZeroPlusAdder = @"^(?:0{2,})(\d+)$";

        private const string ZeroPattern = @"^(\+?)(?:0+)(\d+)$";

        private const string CodeAddPattern = @"^(\d+)$";

        public CommandManager(IPhonebookRepository repository)
        {
            this.Repository = repository;
        }

        public CommandManager()
            : this(new PhonebookRepository())
        {
        }

        private IPhonebookRepository Repository { get; set; }

        public string ProcessCommand(string command)
        {
            int bracketIndex = command.IndexOf('(');
            string action = command.Substring(0, bracketIndex);
            string information = command.Substring(bracketIndex + 1, command.Length - bracketIndex - 2);

            string[] parameters = information.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            switch (action)
            {
                case "AddPhone":
                    if (parameters.Length >= 2 && parameters.Length <= 11)
                    {
                        return this.AddPhone(parameters);
                    }
                    return string.Empty;

                case "ChangePhone":
                    return this.ChangePhone(parameters);

                case "List":
                    return this.List(parameters);
                default:
                    return string.Empty;
            }
        }

        private string AddPhone(string[] parameters)
        {
            string name = parameters[0];
            string[] phones = parameters.Skip(1).ToArray();
            phones = this.CanonizePhones(phones);

            var phoneAdded = this.Repository.AddPhone(name, phones);
            return phoneAdded ? "Phone entry created" : "Phone entry merged";
        }

        private string ChangePhone(string[] parameters)
        {
            parameters = this.CanonizePhones(parameters);
            string oldPhone = parameters[0];
            string newPhone = parameters[1];
            var phonesChanged = this.Repository.ChangePhone(oldPhone, newPhone);

            return string.Format("{0} numbers changed", phonesChanged);
        }

        private string List(string[] parameters)
        {
            int startIndex = int.Parse(parameters[0]);
            int count = int.Parse(parameters[1]);

            var phoneEntries = this.Repository.ListEntries(startIndex, count);

            return string.Join<PhoneEntry>(Environment.NewLine, phoneEntries);
        }

        private string[] CanonizePhones(string[] phones)
        {
            phones = phones.Select(p => p = Regex.Replace(p, ReplacePattern, string.Empty)).ToArray();
            phones = phones.Select(p => p = Regex.Replace(p, DoubleZeroPlusAdder, "+$1")).ToArray();
            phones = phones.Select(p => p = Regex.Replace(p, ZeroPattern, "$1$2")).ToArray();
            phones = phones.Select(p => p = Regex.Replace(p, CodeAddPattern, Code + "$1")).ToArray();

            return phones;
        }
    }
}
