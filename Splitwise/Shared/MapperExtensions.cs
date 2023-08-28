using Splitwise.Dto;
using Splitwise.Models;
using Splitwise.Services;

namespace Splitwise.Shared;

public static class MapperExtensions
{
    public static UserDto CreateUserDto(this User user)
    {
        return new UserDto()
        {
            Email = user.Email,
            Mobile = user.Mobile,
            Name = user.Name,
            Id = user.Id
        };
    }

    public static User CreateUser(this UserCreateDto userCreateDto, int userId)
    {
        var user = new User(userId, userCreateDto.Email, userCreateDto.Name, userCreateDto.Mobile,
            userCreateDto.Password)
        {
            CreatedAt = DateTime.UtcNow
        };

        return user;
    }

    public static Expense CreateExpense(this ExpensePostDto expensePostDto, int expenseId)
    {
        return new Expense(expenseId) {ProcessedOn = DateTime.UtcNow};
    }

    public static ExpenseGetDto CreateExpenseGetDto(this Expense expense)
    {
        return new ExpenseGetDto(expense.Id);
    }
}