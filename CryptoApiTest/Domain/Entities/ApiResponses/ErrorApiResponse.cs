namespace Entities.ApiResponses
{
    public class ErrorApiResponse : BaseApiResponse
    {
        public ErrorApiResponse(object? data = null, string? message = "") : base(false, data, message)
        {
        }
    }
}
