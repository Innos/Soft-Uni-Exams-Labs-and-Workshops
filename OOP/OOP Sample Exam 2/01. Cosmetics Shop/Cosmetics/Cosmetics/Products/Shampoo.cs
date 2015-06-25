using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    class Shampoo : Product,IShampoo
    {

        public Shampoo(string name, string brand, decimal price, GenderType gender,uint milliliters,UsageType usage) : base(name, brand, price, gender)
        {
            this.Milliliters = milliliters;
            this.Usage = usage;
            this.Price = price*milliliters;
        }

        public uint Milliliters { get; private set; }
        public UsageType Usage { get; private set; }

        public override string Print()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.Print());
            result.AppendLine(string.Format("{0}Quantity: {1} ml", Indentation, this.Milliliters));
            result.Append(string.Format("{0}Usage: {1}", Indentation, this.Usage));

            return result.ToString();
        }
    }
}
