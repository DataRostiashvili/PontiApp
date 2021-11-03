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

namespace PontiApp.EventPlace.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IHttpClientFactory _factory;
        private readonly BaseRepository<UserEntity> _userRepository;
        private readonly IMapper _mapper;
        private readonly MessagingService _service;

        public UserService(IMapper mapper, BaseRepository<UserEntity> userRepository, IHttpClientFactory factory,MessagingService service)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _factory = factory;
            _service = service;
        }
        public async Task Add(UserCreationDTO newUserDTO,string url)
        {
            UserEntity user = _mapper.Map<UserCreationDTO, UserEntity>(newUserDTO);
            if (!UserExists(user.FbKey))
            {
                var guid = Guid.NewGuid().ToString();
                user.MongoKey = guid;
                var client = _factory.CreateClient("mongoClient");
                var resp = await client.GetByteArrayAsync(url);
                _service.SendAddMessage("sirbiladze", resp);
                await _userRepository.Insert(user);
            }
            else return;
        }

        public async Task Delete(UserDTO currUserDTO)
        {
            UserEntity user = _mapper.Map<UserEntity>(currUserDTO);
            await _userRepository.Delete(user);
        }

        public async Task<UserDTO> Get(int id)
        {
            return _mapper.Map<UserDTO>(await _userRepository.GetByID(id));
        }

        public async Task<List<UserDTO>> GetAllUser()
        {
            return _mapper.Map<List<UserDTO>>(await _userRepository.GetAll());
        }

        public async Task Update(UserDTO currUserDTO)
        {
            UserEntity user = _mapper.Map<UserEntity>(currUserDTO);
            await _userRepository.Update(user);
        }

        public  bool UserExists(long FbKey) =>  _userRepository.GetByPredicate(user => user.FbKey == FbKey).Any();

        public async Task<bool> UserExists(int id) => await _userRepository.GetByID(id) is null;

        public async Task<UserEntity> GetUser(long id) => await _userRepository.GetByID(id);
        public void DeleteImage(string guid) => _service.SendDeleteMessage(guid);

    }
}
