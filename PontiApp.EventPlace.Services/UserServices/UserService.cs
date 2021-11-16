using AutoMapper;
using PontiApp.Mappings;
using PontiApp.Models.DTOs;
using PontiApp.Models.Entities;
using PontiApp.Ponti.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using PontiApp.MessageSender;
using PontiApp.Models.Request;
using PontiApp.Models.Response;

namespace PontiApp.EventPlace.Services.UserServices
{
   

    public class UserService : IUserService
    // : IUserService
    {
        private readonly IHttpClientFactory _factory;
        private readonly BaseRepository<UserEntity> _userRepository;
        private readonly IMapper _mapper;
        private readonly MessagingService _service;

        public UserService(IMapper mapper, BaseRepository<UserEntity> userRepository, IHttpClientFactory factory, MessagingService service)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _factory = factory;
            _service = service;
        }
        public async Task Add(UserCreationDTO newUserDTO)
        {
            UserEntity user = _mapper.Map<UserCreationDTO, UserEntity>(newUserDTO);
            if (!UserExists(user.FbKey))
            {

                await _userRepository.Insert(user);
            }
            else return;
        }

        public async Task Delete(long id)
        {
            var user = _userRepository.GetByPredicate(user => user.FbKey == id).FirstOrDefault();
            await _userRepository.Delete(user);
        }

        public async Task<UserResponse> Get(long FbId)
        {
            return _mapper.Map<UserResponse>(_userRepository.GetByPredicate(user => user.FbKey == FbId).FirstOrDefault());
        }

        public async Task<List<UserResponse>> GetAllUser()
        {
            return _mapper.Map<List<UserResponse>>(await _userRepository.GetAll());
        }

        public async Task Update(UserRequest userRequest)
        {
            var user = _userRepository.GetByPredicate(user => user.FbKey == userRequest.fbId).First(); 
            user.Address = userRequest.Address;
            user.AverageRanking = userRequest.AverageRanking;
            user.Mail = userRequest.Mail;
            user.Name = userRequest.Name;
            user.PhoneNumber = userRequest.PhoneNumber;
            user.Surename = userRequest.Surename;

            await _userRepository.Update(user);
        }

        public bool UserExists(long FbKey) => _userRepository.GetByPredicate(user => user.FbKey == FbKey).Any();

        public async Task<bool> UserExists(int id) => await _userRepository.GetByID(id) is null;

        public async Task<UserEntity> GetUser(int id) => await _userRepository.GetByID(id);
        public UserCreationDTO GetUser(long fbId) => _mapper.Map<UserCreationDTO>(_userRepository.GetByPredicate(f => f.FbKey == fbId).FirstOrDefault());
        public void DeleteImage(string guid) => _service.SendDeleteMessage(guid);


    }
}
