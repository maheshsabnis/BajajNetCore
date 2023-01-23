namespace CORE_API.MOdels
{
    /// <summary>
    /// The Object that will be used to carry  actual response
    /// Generated from the API
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseObject<T>
    {
        /// <summary>
        /// LIst of REcords
        /// </summary>
        public IEnumerable<T>? Records { get; set; }
        /// <summary>
        /// SIngle Record
        /// </summary>
        public T? Record { get; set; }
        /// <summary>
        /// A Status Message taht defines the state of execution
        /// </summary>
        public string? StatusMessage { get; set; }
        /// <summary>
        /// THe STtaus code based on State of execution
        /// </summary>
        public int StatusCode { get; set; }
    }
}
