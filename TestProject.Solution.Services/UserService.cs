using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Solution.Data.DatabaseContext;
using TestProject.Solution.Data.Entity;
using TestProject.Solution.DTO;

namespace TestProject.Solution.Services
{
    public interface IUserService
    {
        ResultDto GetUserList();
        ResultDto GetUserById(long userId);
        ResultDto AddOrUpdateUser(UserDto user);

        ResultDto DeleteUser(long userId);

    }
    public class UserService: IUserService
    {
        private readonly TestProjectContext _context;
        public UserService(TestProjectContext context)
        {
            _context = context;
        }
        public ResultDto GetUserList()
        {
            var result=new ResultDto();
            try
            {
                var userList = _context.Users.Select(_ => new UserDto()
                {
                    Id = _.Id,
                    CountryId = _.CountryId,
                    Email = _.Email,
                    Gender = _.Gender,
                    Name = _.Name,
                    Created = _.Created,
                    CountryName = _.Country.Name

                }).ToList();
                if (result == null)
                {
                    result.IsSuccess = false;
                    result.Message = "User List is Empty";
                }
                else
                {
                    result.IsSuccess = true;
                    result.Message = "Successfully User data found.";
                    result.SuccessObject = userList;
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public ResultDto GetUserById(long userId)
        {
            var result=new ResultDto();
            try
            {
                var users = _context.Users.Where(_ => _.Id == userId).Select(s => new UserDto()
                {
                    Id = s.Id,
                    CountryId = s.CountryId,
                    Email = s.Email,
                    Gender = s.Gender,
                    Name = s.Name,
                    Created = s.Created,
                    CountryName = s.Country.Name
                }).FirstOrDefault();
                if (result == null)
                {
                    result.IsSuccess = false;
                    result.Message = "User Not Found";
                }
                else
                {
                    result.IsSuccess = true;
                    result.Message = "Successfully User data found.";
                    result.SuccessObject = users;
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public ResultDto AddOrUpdateUser(UserDto user)
        {
            var result = new ResultDto();
            try
            {
                if (user.Id == 0)
                {
                    var userdetails = new User()
                    {
                        Id = user.Id,
                        Name = user.Name,
                        CountryId = user.CountryId,
                        Created = user.Created,
                        Email = user.Email,
                        Gender = user.Gender,
                    };
                    _context.Users.Add(userdetails);
                    _context.SaveChanges();
                    result.IsSuccess = true;
                    result.Message = "Successfully user Added.";
                    result.SuccessObject = user;
                }
                else
                {
                    var userExist = _context.Users.FirstOrDefault(x => x.Id == user.Id);
                    if (userExist == null)
                    {
                        result.IsSuccess = false;
                        result.Message = "User Not Exists";
                        result.SuccessObject = user;
                    }
                    else
                    {
                        userExist.Created = user.Created;
                        userExist.Email = user.Email;
                        userExist.Gender = user.Gender;
                        userExist.Name = user.Name;
                        userExist.CountryId = user.CountryId;

                    }
                    _context.SaveChanges();
                    result.IsSuccess = true;
                    result.Message = "Successfully Data  updated.";
                    result.SuccessObject = user;
                }            
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                result.SuccessObject = user;
            }
            return result;
        }

        public ResultDto DeleteUser(long userId)
        {
            var result = new ResultDto();
            try
            {
                var userExists= _context.Users.FirstOrDefault(x => x.Id == userId);
                if(userExists == null)
                {
                    result.IsSuccess = false;
                    result.Message = "User Not Exists";
                }
                else
                {
                    _context.Users.Remove(userExists);
                    result.IsSuccess = true;
                    result.Message = "Deleted Successfully";
                    result.SuccessObject = userExists;
                }
            }catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;

            }
            return result;
        }
    }
}
