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
using PontiApp.GraphAPICalls;
using PontiApp.AuthService;
using PontiApp.Exceptions;

namespace PontiApp.User.Services
{
   

    public class UserService : IUserService
    {
        private readonly IHttpClientFactory _factory;
        private readonly BaseRepository<UserEntity> _userRepository;
        private readonly IMapper _mapper;
        private readonly MessagingService _service;
        private readonly IFbClient _fbClient;
        private readonly IJwtProcessor _jwtProcessor;

        public UserService(IMapper mapper, BaseRepository<UserEntity> userRepository, IHttpClientFactory factory, MessagingService service,
            IFbClient fbClient, IJwtProcessor jwtProcessor)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _factory = factory;
            _service = service;
            _fbClient = fbClient;
            _jwtProcessor = jwtProcessor;
        }
        //public async Task Add(UserCreationDTO newUserDTO)
        //{
        //    UserEntity user = _mapper.Map<UserCreationDTO, UserEntity>(newUserDTO);
        //    if (!UserExists(user.FbKey))
        //    {
        //        await _userRepository.Insert(user);
        //    }
        //    else return;
        //}

        public async Task<(string, UserCreationDTO)> AddUser(long fbkey, string accessToken)
        {
            UserCreationDTO user = new UserCreationDTO();
            if (!UserExists(fbkey))
            {
                user = await _fbClient.GetUser(accessToken, fbkey);
                user.MongoKey = Guid.NewGuid().ToString();
                await _service.SendAddMessage(user.MongoKey, user.PictureUrl);
                await _userRepository.Insert(_mapper.Map<UserCreationDTO, UserEntity>(user));
            }
            var token = _jwtProcessor.GenerateJwt(fbkey, accessToken);
            user = _mapper.Map< UserEntity, UserCreationDTO>(await _userRepository.GetByFbKey(fbkey));
            return  (token, user);
            

        }

        public async Task Delete(long id)
        {
            var user = _userRepository.GetByPredicate(user => user.FbKey == id).FirstOrDefault();
            if (user == null)
                throw new DoesNotExistsException();
            await _userRepository.Delete(user);
        }

        public async Task<UserResponse> Get(long FbId)
        {
            var user = _userRepository.GetByPredicate(user => user.FbKey == FbId).FirstOrDefault();
            if (user == null)
                throw new DoesNotExistsException("Such User Does Not Exists!");
            return _mapper.Map<UserResponse>(user);
        }

        public async Task<List<UserResponse>> GetAllUser()
        {
            var allUsers = await _userRepository.GetAll();
            if (allUsers.Count == 0 || allUsers == null)
                throw new DoesNotExistsException("No User Exists!");
            return _mapper.Map<List<UserResponse>>(allUsers);
        }

        public async Task Update(UserRequest userRequest)
        {
            var user = _userRepository.GetByPredicate(user => user.FbKey == userRequest.fbId).First();
            if (user == null)
                throw new DoesNotExistsException("Such User Does Not Exists!");
            user.Address = userRequest.Address;
            user.AverageRanking = userRequest.AverageRanking;
            user.Mail = userRequest.Mail;
            user.Name = userRequest.Name;
            user.PhoneNumber = userRequest.PhoneNumber;
            user.Surename = userRequest.Surename;

            await _userRepository.Update(user);
        }

        public bool UserExists(long FbKey) => _userRepository.GetByPredicate(user => user.FbKey == FbKey).Any();

        public async Task<bool> UserExists(int id) => await _userRepository.GetByID(id) is not null;

        public async Task<UserEntity> GetUser(int id) {
            var user = await _userRepository.GetByID(id);
            if(user == null)
                throw new DoesNotExistsException("Such User Does Not Exists!");
            return user;
        }
        public UserCreationDTO GetUser(long fbId) {
            var user = _userRepository.GetByPredicate(f => f.FbKey == fbId).FirstOrDefault();
            if (user == null)
                throw new DoesNotExistsException("Such User Does Not Exists!");
           return _mapper.Map<UserCreationDTO>(user);
        }
        public void DeleteImage(string guid) => _service.SendDeleteMessage(guid);


    }
}
