using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public abstract class Product : IProduct
    {
        protected const string Indentation = "  * ";
        private const int minNameLength = 3;
        private const int maxNameLength = 10;
        private const int minBrandLength = 2;
        private const int maxBrandLength = 10;

        private string name;
        private string brand;

        protected Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;

            }
            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Product name"));
                Validator.CheckIfStringLengthIsValid(value, maxNameLength, minNameLength, string.Format(GlobalErrorMessages.InvalidStringLength, "Product name", minNameLength, maxNameLength));
                this.name = value;
            }

        }

        public string Brand
        {
            get
            {
                return this.brand;

            }
            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Product brand"));
                Validator.CheckIfStringLengthIsValid(value, maxBrandLength, minBrandLength, string.Format(GlobalErrorMessages.InvalidStringLength, "Product brand", minBrandLength, maxBrandLength));
                this.brand = value;
            }

        }

        public decimal Price { get; protected set; }

        public GenderType Gender { get; private set; }

        public virtual string Print()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(string.Format("- {0} - {1}:", this.Brand, this.Name));
            result.AppendLine(string.Format("{0}Price: ${1}", Indentation, this.Price));
            result.AppendLine(string.Format("{0}For gender: {1}", Indentation, this.Gender));

            return result.ToString();
        }

    }
}
