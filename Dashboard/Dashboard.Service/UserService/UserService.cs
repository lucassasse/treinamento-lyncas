﻿using Dashboard.Repository.UserRepository;
using Domain.Models;
using Domain.Models.ViewModels;

namespace Dashboard.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _userRepository.GetAll();
        }


        public async Task<User> GetByIdAsync(int id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task<User> CreateAsync(UserViewModel user)
        {
            var obj = new User();

            obj.FullName = user.FullName;
            obj.Email = user.Email;
            obj.Password = user.Password;

            return await _userRepository.Create(obj);
        }

        public async Task<User> UpdateAsync(UserViewModel user, int id)
        {
            var obj = await _userRepository.GetById(id);

            obj.FullName = user.FullName;
            obj.Email = user.Email;
            obj.Password = user.Password;

            return await _userRepository.Update(obj);
        }

        public async Task<User> DeleteAsync(int id)
        {
            var user = await _userRepository.GetById(id);
            await _userRepository.Delete(user);
            return user;
        }
    }
}
