namespace Phonebook.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PhoneEntry : IComparable<PhoneEntry>
    {
        public PhoneEntry(string name, SortedSet<string> phones)
        {
            this.Name = name;
            this.Phones = phones;
        }

        public string Name { get; set; }

        public SortedSet<string> Phones { get; set; }

        public int CompareTo(PhoneEntry other)
        {
            return string.Compare(this.Name, other.Name, StringComparison.InvariantCultureIgnoreCase);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('[');

            sb.Append(this.Name);
            sb.Append(": ");
            sb.Append(string.Join(", ", this.Phones));
            sb.Append(']');
            return sb.ToString();
        }
    }
}
