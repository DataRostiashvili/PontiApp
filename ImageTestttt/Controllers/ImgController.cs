using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PontiApp.MessageSender;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageTestttt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImgController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ConnectionFactory _factory;
        private readonly ILogger<MessagingService> _logger;
        private readonly MessagingService _service;
        public IConnection Conn { get; set; }
        public IModel Channel { get; set; }

        public ImgController (IConfiguration config,ConnectionFactory factory,ILogger<MessagingService> logger,MessagingService service)
        {
            _config = config;
            _factory = factory;
            _factory.HostName = "localhost";
            _factory.UserName = "guest";
            _factory.Password = "guest";
            _factory.Port = 5672;
            _logger = logger;
            _service = service;
            Conn = _factory.CreateConnection();
            Channel = Conn.CreateModel();
            
        }
        [HttpPost]
        public async Task<ActionResult> Upload(string guid,IFormFileCollection files)
        {
            await _service.SendAddMessage(guid,files);
            return Ok();
        }
    }
}
