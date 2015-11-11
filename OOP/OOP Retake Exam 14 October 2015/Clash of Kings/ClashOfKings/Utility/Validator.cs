using System;

namespace ClashOfKings.Utility
{
    public static class Validator
    {
        public static void CheckForNull(object item, string itemName,string message = null)
        {
            if (item == null)
            {
                throw new ArgumentNullException(itemName,message);
            }
        }
    }
}
