using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    class Toothpaste : Product,IToothpaste
    {
        private const int minIngredientLength = 4;
        private const int maxIngredientLength = 12;

        private List<string> ingredients;
 
        public Toothpaste(string name, string brand, decimal price, GenderType gender,IList<string> ingredients ) : base(name, brand, price, gender)
        {
            this.IngredientsList = new List<string>(ingredients);
        }

        private List<string> IngredientsList
        {
            set
            {
                foreach (var ingredient in value)
                {
                    Validator.CheckIfStringIsNullOrEmpty(ingredient,string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty,"Each ingredient"));
                    Validator.CheckIfStringLengthIsValid(ingredient, maxIngredientLength, minIngredientLength,
                        string.Format(GlobalErrorMessages.InvalidStringLength, "Each ingredient",
                            minIngredientLength, maxIngredientLength));
                }
                this.ingredients = value;
            }
        }

        public string Ingredients
        {
            get
            {
                return string.Join(", ", this.ingredients);
            }
        }

        public override string Print()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.Print());
            result.Append(string.Format("{0}Ingredients: {1}", Indentation, this.Ingredients));

            return result.ToString();
        }
    }
}
