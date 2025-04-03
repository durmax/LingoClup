using SharedKernel;

namespace Domain.Users;

public static class UserErrors
{
    public static AppError NotFound(Guid userId) => AppError.NotFound(
        "Users.NotFound",
        $"The user with the Id = '{userId}' was not found");

    public static AppError Unauthorized() => AppError.Failure(
        "Users.Unauthorized",
        "You are not authorized to perform this action.");

    public static readonly AppError NotFoundByEmail = AppError.NotFound(
        "Users.NotFoundByEmail",
        "The user with the specified email was not found");

    public static readonly AppError EmailNotUnique = AppError.Conflict(
        "Users.EmailNotUnique",
        "The provided email is not unique");
}
