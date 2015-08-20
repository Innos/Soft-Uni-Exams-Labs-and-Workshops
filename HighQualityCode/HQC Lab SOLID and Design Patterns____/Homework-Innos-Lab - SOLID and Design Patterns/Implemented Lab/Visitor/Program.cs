namespace CustomerService
{
    using CustomerService.Data;
    using CustomerService.Models;

    using Visitor.Visitors;

    public class Program
    {
        public static void Main()
        {
            var repository = new CustomerRepository();
            var discountVisitor = new DiscountRaiseVisitor();
            var freePurchaseVisitor = new FreePurchaseVisitor();

            var premiumCustomers = repository.GetPremiumCustomers();
            foreach (var premiumCustomer in premiumCustomers)
            {
                premiumCustomer.Accept(discountVisitor);
            }

            var allCustomers = repository.GetAll();
            foreach (var customer in allCustomers)
            {
                customer.Accept(freePurchaseVisitor);
            }
        }
    }
}
