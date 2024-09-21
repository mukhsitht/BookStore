namespace Utilities.Model
{
    public class ApiResponseModel<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
        public ApiResponseModel(bool? success = null, string? message = null, T? data = default)
        {
            Success = success ?? false;
            Message = message;
            Data = data;
        }
    }
}
