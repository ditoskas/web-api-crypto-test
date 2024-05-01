using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ApiResponses
{
    public class OkApiResult : ActionResult
    {
        private readonly OkApiResponse _response;
        public OkApiResult(object? data = null, string? message = "")
        {
            _response = new OkApiResponse(data, message);
        }

        public override async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(_response)
            {
                StatusCode = StatusCodes.Status200OK
            };

            await objectResult.ExecuteResultAsync(context);
        }
    }
}
