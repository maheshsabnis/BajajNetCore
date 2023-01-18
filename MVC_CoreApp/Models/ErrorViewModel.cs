namespace MVC_CoreApp.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        // Modify the Model so have properties for ControllerName, ActionName, and ErrorMessage
        public string? ControllerName { get; set; }
        public string? ActionName { get; set; }
        public string? ErrorMessage { get; set; }
    }
}