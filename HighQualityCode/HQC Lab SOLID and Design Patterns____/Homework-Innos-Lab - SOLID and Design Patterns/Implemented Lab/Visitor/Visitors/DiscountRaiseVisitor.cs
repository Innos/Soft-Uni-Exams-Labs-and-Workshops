namespace Visitor.Visitors
{
    using CustomerService.Models;

    public class DiscountRaiseVisitor : IVisitor
    {
        public void Visit(Customer customer)
        {
            customer.Discount += 5;
        }
    }
}
