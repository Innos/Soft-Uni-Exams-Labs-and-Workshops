namespace ClashOfKings.Exceptions
{
    public class NegativeAmountException : GameException
    {
        public NegativeAmountException(string message) : base(message)
        {
        }
    }
}
