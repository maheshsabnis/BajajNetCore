using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace MVC_CoreApp.CustomFilters
{
    public class LogFilterAttribute : ActionFilterAttribute
    {
        private void LogRequest(string currentState, RouteData route)
        {
            string controller = route.Values["controller"].ToString();
            string action = route.Values["action"].ToString();

            string logMessage = $"Current state of Exeution is {currentState} in {action} action method of the {controller} controller";

            Debug.WriteLine(logMessage);

        }


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            LogRequest("On Action Executing", context.RouteData);
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            LogRequest("On Action Executed", context.RouteData);
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            LogRequest("On Result Executing", context.RouteData);
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            LogRequest("On Result Executed", context.RouteData);
        }
    }
}
