namespace Visitor.Visitors
{
    using CustomerService.Models;

    public class FreePurchaseVisitor : IVisitor
    {
        public void Visit(Customer customer)
        {
            customer.Purchases.Add(new Purchase("SteamOp", 0.0));
        }
    }
}
