namespace ClashOfKings.Exceptions
{
    public class NonExistantNeighbourException:GameException
    {
        public NonExistantNeighbourException(string message) : base(message)
        {
        }
    }
}
