using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Utilities
{
    public class ErrorHandlerMiddlware
    {

        private readonly RequestDelegate _request;
        public ErrorHandlerMiddlware(RequestDelegate request)
        {
            _request = request;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _request(context);
            }
            catch(Exception ex)
            {

            }
        }
    }
}
