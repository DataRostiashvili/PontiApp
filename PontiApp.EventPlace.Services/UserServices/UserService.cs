using AutoMapper;
using PontiApp.Models.DTOs;
using PontiApp.Models.Entities;
using PontiApp.Ponti.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.EventPlace.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly BaseRepository<UserEntity> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, BaseRepository<UserEntity> userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task Add(UserDTO newUserDTO)
        {
            UserEntity user = _mapper.Map<UserEntity>(newUserDTO);
            await _userRepository.Insert(user);
        }

        public async Task Delete(UserDTO currUserDTO)
        {
            UserEntity user = _mapper.Map<UserEntity>(currUserDTO);
            await _userRepository.Delete(user);
        }

        public Task<UserDTO> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(UserDTO currUserDTO)
        {
            UserEntity user = _mapper.Map<UserEntity>(currUserDTO);
            await _userRepository.Insert(user);
        }
    }
}
