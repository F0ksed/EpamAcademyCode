namespace OopTask.Exceptions
{
    public class UpdateAutoException : Exception
    {
        public UpdateAutoException(): base() { }
        public UpdateAutoException(string message): base(message) { }
        public UpdateAutoException(string message, Exception innerException): base(message, innerException) { }
    }
}
