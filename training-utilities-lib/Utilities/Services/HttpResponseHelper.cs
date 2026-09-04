using Utilities.Models;

namespace Utilities.Services;

public static class HttpResponseHelper
{
    public static ApiError CreateError(
        string code,
        string message)
    {
        return new ApiError
        {
            Code = code,
            Message = message,
            Timestamp = DateTime.UtcNow
        };
    }


    public static OperationResult CreateSuccess(
        string message)
    {
        return new OperationResult
        {
            Success = true,
            Message = message
        };
    }
}