namespace Phonebook.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Phonebook.Interfaces;
    using Phonebook.Models;


    using Wintellect.PowerCollections;

    public class PhonebookRepository : IPhonebookRepository
    {
        private readonly Dictionary<string, PhoneEntry> phoneEntriesByName = new Dictionary<string, PhoneEntry>();

        private readonly MultiDictionary<string, PhoneEntry> phoneEntriesByPhone = new MultiDictionary<string, PhoneEntry>(false);

        private readonly OrderedSet<PhoneEntry> entries = new OrderedSet<PhoneEntry>();

        public bool AddPhone(string name, params string[] phones)
        {
            string nameToLower = name.ToLowerInvariant();
            bool nameDoesNotExist = !this.phoneEntriesByName.ContainsKey(nameToLower);
            if (nameDoesNotExist)
            {
                var entryToAdd = new PhoneEntry(name, new SortedSet<string>());
                this.phoneEntriesByName.Add(nameToLower, entryToAdd);
                this.entries.Add(entryToAdd);
            }

            var entry = this.phoneEntriesByName[nameToLower];

            foreach (var phone in phones)
            {
                this.phoneEntriesByPhone.Add(phone, entry);
            }

            entry.Phones.UnionWith(phones);
            return nameDoesNotExist;
        }

        public int ChangePhone(string oldPhone, string newPhone)
        {
            var found = this.phoneEntriesByPhone[oldPhone].ToList();
            foreach (var entry in found)
            {
                entry.Phones.Remove(oldPhone);
                this.phoneEntriesByPhone.Remove(oldPhone, entry);

                entry.Phones.Add(newPhone);
                this.phoneEntriesByPhone.Add(newPhone, entry);
            }

            return found.Count;
        }

        public PhoneEntry[] ListEntries(int startIndex, int count)
        {
            if (startIndex < 0 || startIndex + count > this.entries.Count)
            {
                throw new ArgumentException("Invalid range");
            }

            PhoneEntry[] list = new PhoneEntry[count];

            for (int i = startIndex; i < startIndex + count; i++)
            {
                list[i - startIndex] = this.entries[i];
            }

            return list;
        }
    }
}
