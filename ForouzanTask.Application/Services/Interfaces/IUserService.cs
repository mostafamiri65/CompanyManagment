using ForouzanTask.Application.DTOs.User;
using ForouzanTask.Application.DTOs.User.Role;
using ForouzanTask.DataLayer.Entities.Common;

namespace ForouzanTask.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserListDto>> GetAllUsers(string? userName,
            string? mobile, string? fullName, Guid? userId);
        Task<List<RoleListDto>> GetAllRoles();
        Task<bool> AddUser(CreateUserDto user,Guid? userId);
        Task<bool> IsExistUserName(string username);
        Task<bool> IsExistMobile(string mobile);
        Task<bool> IsAdmin(Guid userId);
        Task<UserDto> GetUserById(Guid userId);
        Task<bool> UpdateUser(UserDto userDto);
    }
}
