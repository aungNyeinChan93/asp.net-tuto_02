using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace One.WebApplication1.Filters.ActionFilters
{
    public class BlogGetOneActionFilter :ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var id = context.ActionArguments["id"] as int?;

            if(id is null && id <= 0)
            {
                context.ModelState.AddModelError("Blog Id", "Invalid Blog Id");
                context.Result = new BadRequestObjectResult(new ValidationProblemDetails(context.ModelState) { Status = 400});
            }
        }
    }
}
