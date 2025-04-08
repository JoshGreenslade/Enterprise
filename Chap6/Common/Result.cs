namespace Chap6.Common;

public class Result
{
    public bool IsSuccess { get; set; }
    public string? ErrorMessage { get; set; }

    public static Result Failed(string errorMessage)
    {
        return new Result { IsSuccess = false, ErrorMessage = errorMessage };
    }

    public static Result Ok()
    {
        return new Result { IsSuccess = true };
    }
}

public class Result<T> : Result
{
    public T? Data { get; set; }

    public Result(T data)
    {
        Data = data;
        IsSuccess = true;
    }
    public Result() { }

    public static Result<T> Ok(T data)
    {
        return new Result<T>(data) { IsSuccess = true, Data = data };
    }

    public static new Result<T> Failed(string errorMessage)
    {
        return new Result<T> { IsSuccess = false, ErrorMessage = errorMessage };
    }
}