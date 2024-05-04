namespace Entities.Exceptions
{
    /// <summary>
    /// Base class for all not found exceptions
    /// </summary>
    public abstract class NotFoundException : Exception
    {
        protected NotFoundException(string message)
        : base(message)
        { }
    }
}
