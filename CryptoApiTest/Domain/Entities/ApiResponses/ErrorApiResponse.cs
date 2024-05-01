namespace Entities.ApiResponses
{
    public class ErrorApiResponse : BaseApiResponse
    {
        public ErrorApiResponse(string message = "") : base(false, message, null)
        {
        }
    }
}
