using Microsoft.AspNetCore.Mvc;

namespace Entities.ApiResponses
{
    public class ErrorApiResult : ActionResult
    {
        private readonly ErrorApiResponse _response;
        protected int? StatusCodeToSend { get; set; }
        public ErrorApiResult(int? statusCode, object? data = null, string? message = "")
        {
            StatusCodeToSend = statusCode;
            _response = new ErrorApiResponse(data, message);
        }

        public override async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(_response)
            {
                StatusCode = StatusCodeToSend
            };

            await objectResult.ExecuteResultAsync(context);
        }
    }
}
