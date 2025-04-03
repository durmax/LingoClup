namespace SharedKernel;

public record MyError
{
    public static readonly MyError None = new(string.Empty, string.Empty, ErrorType.Failure);
    public static readonly MyError NullValue = new(
        "General.Null",
        "Null value was provided",
        ErrorType.Failure);

    public MyError(string code, string description, ErrorType type)
    {
        Code = code;
        Description = description;
        Type = type;
    }

    public string Code { get; }

    public string Description { get; }

    public ErrorType Type { get; }

    public static MyError Failure(string code, string description) =>
        new(code, description, ErrorType.Failure);

    public static MyError NotFound(string code, string description) =>
        new(code, description, ErrorType.NotFound);

    public static MyError Problem(string code, string description) =>
        new(code, description, ErrorType.Problem);

    public static MyError Conflict(string code, string description) =>
        new(code, description, ErrorType.Conflict);
}
