namespace Entities.ApiResponses
{
    public class UnprocessableEntityApiResult : ErrorApiResult
    {
        public UnprocessableEntityApiResult(object? data = null, string? message = ""): base(422, data, message)
        {
        }
    }
}
