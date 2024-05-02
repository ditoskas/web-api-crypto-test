namespace Entities.ApiResponses
{
    public class BadRequestApiResult : ErrorApiResult
    {
        public BadRequestApiResult(object? data = null, string? message = ""): base(400, data, message)
        {
        }
    }
}
