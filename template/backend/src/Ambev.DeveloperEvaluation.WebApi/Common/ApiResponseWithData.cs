namespace Ambev.DeveloperEvaluation.WebApi.Common;

public class ApiResponseWithData<T> : ApiResponse
{
    public T? Data { get; set; }

    public static ApiResponseWithData<T> Result(string message, T data)
    {
        return new ApiResponseWithData<T>
        {
            Success = true,
            Message = message,
            Data = data
        };
    }
}
