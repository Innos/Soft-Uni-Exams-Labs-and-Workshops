namespace Visitor.Visitors
{
    public interface IVisitable
    {
        void Accept(IVisitor visitor);
    }
}
