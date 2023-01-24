namespace CORE_API.CustomMiddlewares
{
    /// <summary>
    /// The following class will be responsible
    /// to well organize the error message
    /// </summary>
    public class ErrorReponse
    {
        public int ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
    }

    /// <summary>
    /// Custom Middleware Logic class
    /// 1. This MUST be constrctor injeted with 'RequestDelegate' 
    /// 2. MUST have 'InvokeAsync()' method with input parameter as HttpContext 
    /// </summary>
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;
        /// <summary>
        /// The RequestDelegate will be resolved by the 'IApplicationBuilder'
        /// when this middleware is registered in the Pipeline
        /// </summary>
        /// <param name="next"></param>
        public ExceptionMiddleware(RequestDelegate next)
        {
                _next= next;    
        }
        /// <summary>
        /// THis method will be invoked using RequestDelegate
        /// when the Pipeline starts processing (aka Executing) HTTP Request
        /// THis method will contain the MIddleware LOgic
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // If there are no errors while Processing the Current Request
                // then Move to Next MIddleware in Pipeline
                await _next(context);
            }
            catch (Exception ex)
            { 
                // 1.  Handle the execption and read the Exception Message
                string msg = ex.Message;
                // 2.  Define a Custom Error COde
                context.Response.StatusCode= 500;
                // 3. Organize the Error Message using ErrorResponse class
                var errorResponse = new ErrorReponse()
                {
                     ErrorCode = context.Response.StatusCode,
                     ErrorMessage = msg
                };
                // 4. Serialize the HttpResponse in JSON form
                await context.Response.WriteAsJsonAsync(errorResponse);
            }
        }
    }

    /// <summary>
    /// THis is an extension class
    /// that will be used to register the Custom MIddleware class
    /// in HTTP Pipeline
    /// </summary>
    public static class ExceptionMiddlewareExtension
    {
        public static void UseException(this IApplicationBuilder builder)
        {
            ///UseMiddleware<T>()
            /// Here T is the Custom Middleware class
            /// T is costructor injected with RequestDelegate
            /// and having an INvoke() / INvokeAsync() method
            /// with input parameter as 'HttpContext'
            builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
