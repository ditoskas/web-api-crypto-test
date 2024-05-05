using Entities.ApiResponses;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api2.ActionFilters
{
    /// <summary>
    /// Validate that the expected information from the POST body exists and are valid
    /// </summary>
    public class ValidationFilterAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var action = context.RouteData.Values["action"];
            var controller = context.RouteData.Values["controller"];

            var param = context.ActionArguments.SingleOrDefault(x => x.Value.ToString().Contains("Dto")).Value;

            if (param is null)
            {
                context.Result = new BadRequestApiResult(null, $"Object is null. Controller: {controller}, action: {action}");
                return;
            }

            if (!context.ModelState.IsValid)
            {
                context.Result = new UnprocessableEntityApiResult(context.ModelState, "Validation failed");
            }
        }
    }
}
