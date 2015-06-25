using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    class Category : ICategory
    {
        private int minCategoryLength = 2;
        private int maxCategoryLength = 15;

        private string name;
        private List<IProduct> products;

        public Category(string name)
        {
            this.products = new List<IProduct>();
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;

            }
            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Category name"));
                Validator.CheckIfStringLengthIsValid(value, maxCategoryLength, minCategoryLength, string.Format(GlobalErrorMessages.InvalidStringLength, "Category name", minCategoryLength, maxCategoryLength));
                this.name = value;
            }

        }

        public void AddCosmetics(IProduct cosmetics)
        {
            this.products.Add(cosmetics);
            this.Sort();
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            if (!this.products.Contains(cosmetics))
            {
                throw new ArgumentException(string.Format("Product {0} does not exist in category {1}!", cosmetics.Name, this.Name));
            }
            this.products.Remove(cosmetics);
            this.Sort();
        }

        public string Print()
        {
            StringBuilder result = new StringBuilder();
            if (this.products.Count == 1)
            {
                result.AppendLine(string.Format("{0} category - {1} product in total", this.Name, this.products.Count));
            }
            else
            {
                result.AppendLine(string.Format("{0} category - {1} products in total", this.Name, this.products.Count));
            }
            
            foreach (var product in this.products)
            {
                result.AppendLine(product.Print());
            }
            result.Remove(result.Length - 2, 2);

            return result.ToString();
        }

        private void Sort()
        {
            this.products =
                this.products.OrderBy(product => product.Brand).ThenByDescending(product => product.Price).ToList();
        }
    }
}
