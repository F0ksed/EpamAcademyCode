namespace OopTask.Exceptions
{
    public class GetAutoByParameterException: Exception
    {
        public GetAutoByParameterException() : base() { }
        public GetAutoByParameterException(string message) : base(message) { }
        public GetAutoByParameterException(string message, Exception innerException) : base(message, innerException) { }
    }
}
