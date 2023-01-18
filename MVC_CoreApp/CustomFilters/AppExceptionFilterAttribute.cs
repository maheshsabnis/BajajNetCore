using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;

namespace MVC_CoreApp.CustomFilters
{
    public class AppExceptionFilterAttribute : IExceptionFilter
    {
        /// <summary>
        /// THis interface represents the Model object that is used in current Request
        /// </summary>
        IModelMetadataProvider modelProvier;

        /// <summary>
        /// Iject the IModelMetadataProvider to the current constructor
        /// </summary>
        public AppExceptionFilterAttribute(IModelMetadataProvider provider)
        {
            modelProvier = provider;
        }


        public void OnException(ExceptionContext context)
        {
            // Logic for Exception
            // 1. Handle the exception (Internal call to catch)
            context.ExceptionHandled = true;
            // 2. Receive the Exception Message
            string errorMessage = context.Exception.Message;
            // 3. Precess of Generating Result so that it will return Error Page

            var viewResult = new ViewResult();
            // 3.a. Set the Nae of the Veiw to which the NAvigation will takes place
            // Error.cshtml from 'Shared' sub-folder of the 'Views' folder
            viewResult.ViewName = "Error";

            // 3.a.1: Since ViewData needs an instance of ViewDataDictionary use it to set the values for ViewData object

            ViewDataDictionary vData = new ViewDataDictionary(modelProvier, context.ModelState);



            // 3.b. Set the Data that is to be Passed to Error View
            vData["ControllerName"] = context.RouteData.Values["controller"].ToString();
            vData["ActionName"] = context.RouteData.Values["action"].ToString();
            vData["ErrorMessage"] = errorMessage;

            // 3.c. Get the ViewData for the View
            viewResult.ViewData = vData;

            /// THis is the Error View with ViewData
            /// The action method which throws exception
            /// that will be handled by this Exception Filter
            /// and then it will take to the Error View
            context.Result = viewResult;

        }
    }
}
