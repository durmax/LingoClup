using System.Diagnostics.CodeAnalysis;

namespace SharedKernel;

public class Result
{
    public Result(bool isSuccess, MyError error)
    {
        if (isSuccess && error != MyError.None ||
            !isSuccess && error == MyError.None)
        {
            throw new ArgumentException("Invalid error", nameof(error));
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public MyError Error { get; }

    public static Result Success() => new(true, MyError.None);

    public static Result<TValue> Success<TValue>(TValue value) =>
        new(value, true, MyError.None);

    public static Result Failure(MyError error) => new(false, error);

    public static Result<TValue> Failure<TValue>(MyError error) =>
        new(default, false, error);
}

public class Result<TValue> : Result
{
    private readonly TValue? _value;

    public Result(TValue? value, bool isSuccess, MyError error)
        : base(isSuccess, error)
    {
        _value = value;
    }

    [NotNull]
    public TValue Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("The value of a failure result can't be accessed.");

    public Result<TValue> ValidationFailure(MyError error) =>
        new(default, false, error);
}
