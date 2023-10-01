using AutoMapper;
using ForouzanTask.Application.DTOs.User;
using ForouzanTask.Application.DTOs.User.Role;
using ForouzanTask.Application.Extensions;
using ForouzanTask.Application.Generators;
using ForouzanTask.Application.Securities;
using ForouzanTask.Application.Services.Interfaces;
using ForouzanTask.Application.Statics;
using ForouzanTask.DataLayer.Context;
using ForouzanTask.DataLayer.Entities.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ForouzanTask.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private ForouzanTaskContext _context;
        private IMapper _mapper;
        public UserService(ForouzanTaskContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddUser(CreateUserDto user, Guid? userId)
        {

            TbUser newUser = new TbUser();
            if (user.Avatar != null)
            {
                newUser.Avatar = NameGenerator.GenerateUniqCode() +
                    Path.GetExtension(user.Avatar.FileName);

                var validFormats = new List<string>()
                {
                ".png",
                ".jpg",
                ".jpeg"
                };

                var result = user.Avatar.UploadFile(newUser.Avatar,
                    PathTools.UserAvatarServerPath, validFormats);
                if (!result)
                {
                    return false;
                }
            }
            newUser.CreateUserId = userId;
            newUser.UserName = user.UserName;
            newUser.Id = Guid.NewGuid();
            if (user.Password != null) newUser.Password = HashEncode.GetHashCode(HashEncode.GetHashCode(user.Password));
            newUser.PersonalId = NameGenerator.GenratePersonalCode();
            newUser.CreateDate = DateTime.Now;
            newUser.FullName = user.FullName;
            newUser.Mobile = user.Mobile;
            newUser.IsDelete = false;
            newUser.LastModifiedUserIp = GetIpAddress.GetIp();
            newUser.LastModifiedUserMac = GetMacAddress.GetClientMAC(newUser.LastModifiedUserIp);
            await _context.TbUsers.AddAsync(newUser);
            TbUserRole userRole = new TbUserRole()
            {
                Id = Guid.NewGuid(),
                RoleId = user.RoleId,
                UserId = newUser.Id,
                CreateDate = DateTime.Now,
                CreateUserId = userId,
                IsDelete = false,
                LastModifiedUserIp = GetIpAddress.GetIp(),
                LastModifiedUserMac = GetMacAddress.GetClientMAC(GetIpAddress.GetIp())
            };
            await _context.TbUserRoles.AddAsync(userRole);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<List<RoleListDto>> GetAllRoles()
        {
            var roles = await _context.TbRoles.ToListAsync();
            return _mapper.Map<List<RoleListDto>>(roles);
        }

        public async Task<List<UserListDto>> GetAllUsers(string? userName,
            string? mobile, string? fullName, Guid? userId)
        {
            var userList = new List<TbUser>();
            var userRoles = await _context.TbUserRoles.Where(u => u.UserId == userId)
                .Select(r => r.RoleId).ToListAsync();
            TbRole? manager = await _context.TbRoles.FirstOrDefaultAsync(r => r.IsManager);
            TbRole? employee = await _context.TbRoles.FirstOrDefaultAsync(r => r.IsEmployee);

            var users = _context.TbUsers.Where(u => !u.IsDelete);
            if (!userName.IsNullOrEmpty())
            {
                users = users.Where(u => u.UserName == userName);
            }
            if (!mobile.IsNullOrEmpty())
            {
                users = users.Where(u => u.Mobile == mobile);
            }
            if (!fullName.IsNullOrEmpty())
            {
                users = users.Where(u => u.FullName == fullName);
            }
            if (manager != null && userRoles.Contains(manager.Id))
            {
                userList = await users.ToListAsync();

            }
            List<UserListDto> list = new List<UserListDto>();
            foreach (var user in userList)
            {
                UserListDto userDto = new UserListDto()
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Mobile = user.Mobile,
                    Password = user.Password,
                    PersonalId = user.PersonalId,
                    UserName = user.UserName
                };
                list.Add(userDto);
            }
            return list;
        }

        public async Task<UserDto> GetUserById(Guid userId)
        {
            var users = await _context.TbUsers.SingleOrDefaultAsync(r => r.Id == userId);
            UserDto user = new UserDto();
            if (users != null)
            {
                user.Id = users.Id;
                user.CreateDate = users.CreateDate;
                user.FullName = users.FullName;
                user.UserName = users.UserName;
                user.Password = users.Password;
                user.PersonalId = users.PersonalId;
                user.Mobile = users.Mobile;
                user.Avatar = users.Avatar;
                user.LastModifiedUserIp = users.LastModifiedUserIp;
                user.LastModifiedUserMac = users.LastModifiedUserMac;
                user.ModifiedUserId = users.ModifiedUserId;
                user.CreateUserId = users.CreateUserId;
                user.IsDelete = users.IsDelete;
            }
            return user;
        }

        public async Task<bool> IsAdmin(Guid userId)
        {
            var userRole = await _context.TbUserRoles.SingleAsync(u => u.UserId == userId);
            var admin = await _context.TbRoles.SingleAsync(r => r.IsManager);
            if (userRole.RoleId == admin.Id)
                return true;
            return false;
        }

        public async Task<bool> IsExistMobile(string mobile)
        {
            return await _context.TbUsers.AnyAsync(u => u.Mobile == mobile);
        }

        public async Task<bool> IsExistUserName(string username)
        {
            return await _context.TbUsers.AnyAsync(u => u.UserName == username);
        }

        public async Task<bool> UpdateUser(UserDto userDto)
        {
            string pass ="";
            if (userDto.Password != null) { 
               pass = HashEncode.GetHashCode(HashEncode.GetHashCode(userDto.Password));}
            var user = await _context.TbUsers.SingleOrDefaultAsync(u => u.Id == userDto.Id);
            if (user == null) return false;
            user.UserName = userDto.UserName;
            user.FullName = userDto.FullName;
            user.Password = pass;
            user.Mobile = userDto.Mobile;
            user.IsDelete = userDto.IsDelete;
            user.PersonalId = userDto.PersonalId;
            _context.TbUsers.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
