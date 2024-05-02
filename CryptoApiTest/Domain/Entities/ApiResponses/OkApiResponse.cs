namespace Entities.ApiResponses
{
    public class OkApiResponse : BaseApiResponse
    {
        public OkApiResponse(object? data, string? message = "") : base(true, data, message)
        {
        }
    }
}
