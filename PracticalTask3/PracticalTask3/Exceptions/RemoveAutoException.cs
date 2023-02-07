namespace PracticalTask3.Exceptions
{
    public class RemoveAutoException : Exception
    {
        public RemoveAutoException(): base() { }
        public RemoveAutoException(string message) : base(message) { }
        public RemoveAutoException(string message, Exception innerException) : base(message, innerException) { }
    }
}
