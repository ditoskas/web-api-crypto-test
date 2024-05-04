namespace Entities.Exceptions
{
    /// <summary>
    /// Base class for all bad request exceptions
    /// </summary>
    public abstract class BadRequestException : Exception
    {
        protected BadRequestException(string message)
        : base(message)
        { }
    }
}
