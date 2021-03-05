namespace app.timesheet.com {
    public class ResponseClass<T>  {
        public T data { get; set; }

        public bool isError { get; set; }

        public ErrorType  errorType { get; set; }

        public string message { get; set; }

        public bool showError { get; set; }
    }
}